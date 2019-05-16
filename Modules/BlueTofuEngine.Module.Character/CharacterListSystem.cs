using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Module.Base.Utils;
using BlueTofuEngine.Module.Stats;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.GameData;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterListSystem : ISystem
    {
        public void OnNotification(IEntity entity, SystemEventArgs args)
        {
            switch (args)
            {
                case SendCharacterListEventArgs sclea:
                    SendCharacterList(entity);
                    break;

                case CreateCharacterRequestEventArgs ccrea:
                    CreateCharacter(entity, ccrea);
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }

        #region Network

        private void SendCharacterList(IEntity entity)
        {
            var accountCharacters = UserDataService.Instance.GetAll<CharacterUserData>(x => x.AccountId == entity.Account().AccountId);
            var listMessage = new CharactersListMessage();
            foreach (var accountCharacter in accountCharacters)
            {
                var character = EntityFactory.Instance.CreateCharacter();
                character.Character().CharacterId = accountCharacter.CharacterId;
                character.Character().Breed = (Breeds)accountCharacter.BreedId;
                character.Character().Gender = accountCharacter.Gender ? Gender.Female : Gender.Male;

                var characterStats = UserDataService.Instance.Get<CharacterStatsUserData>(accountCharacter.CharacterId);
                character.Stats().Stats = StatCollection.FromUserData(characterStats);
                character.Stats().Stats[StatType.Level].Set(StatPartType.Base, accountCharacter.Level);

                var breedData = GameDataManager<Breed>.Instance.Get(accountCharacter.BreedId);
                var breedLook = EntityLookParser.Parse(accountCharacter.Gender ? breedData.FemaleLook : breedData.MaleLook);
                var headData = GameDataManager<Head>.Instance.Get(accountCharacter.HeadId);
                character.Look().Name = accountCharacter.Name;
                character.Look().BonesId = breedLook.BonesId;
                character.Look().AddSkin(breedLook.Skins.First());
                character.Look().AddSkin(short.Parse(headData.Skin));
                character.Look().IndexedColors.AddRange(accountCharacter.Colors.Split(',').Select(x => int.Parse(x)));
                character.Look().Scales.AddRange(breedLook.Scales);

                var infos = new CharacterBaseInformations();
                infos.Initialize(character);
                listMessage.Characters.Add(infos);
            }
            entity.Send(listMessage);
        }

        private void SendCharacterCreationResult(IEntity entity, CharacterCreationResult result)
        {
            entity.Send(new CharacterCreationResultMessage(result));
        }

        private void CreateCharacter(IEntity entity, CreateCharacterRequestEventArgs e)
        {
            var accountCharacters = UserDataService.Instance.GetAll<CharacterUserData>(x => x.AccountId == entity.Account().AccountId);
            if (accountCharacters.Count() >= 5)
            {
                SendCharacterCreationResult(entity, CharacterCreationResult.TooManyCharacters);
                return;
            }
            if (UserDataService.Instance.Get<CharacterUserData>(x => x.Name.Equals(e.Name, StringComparison.OrdinalIgnoreCase)) != null)
            {
                SendCharacterCreationResult(entity, CharacterCreationResult.NameAlreadyExists);
                return;
            }

            var breedData = GameDataManager<Breed>.Instance.Get((int)e.Breed);
            var colors = new List<int>();
            var referenceColors = e.Sex == Gender.Male ? breedData.MaleColors : breedData.FemaleColors;
            for (int i = 0; i < e.Colors.Count(); i++)
            {
                if (e.Colors.ElementAt(i) == -1)
                    colors.Add(referenceColors.ElementAt(i));
                else
                    colors.Add(e.Colors.ElementAt(i));
            }

            var newCharacter = new CharacterUserData
            {
                AccountId = entity.Account().AccountId,
                BreedId = (int)e.Breed,
                CharacterId = (uint)UserDataService.Instance.GetAll<CharacterUserData>().Count() + 1,
                Level = 1,
                Name = e.Name,
                Gender = e.Sex == Gender.Female,
                Colors = string.Join(",", colors),
                HeadId = e.CosmeticId
            };
            UserDataService.Instance.Add(newCharacter);
            var newCharacterStats = CharacterStatsUserData.FromData(new StatCollection());
            newCharacterStats.CharacterId = newCharacter.CharacterId;
            UserDataService.Instance.Add(newCharacterStats);

            SendCharacterCreationResult(entity, CharacterCreationResult.Ok);
        }
        
        #endregion
    }
}

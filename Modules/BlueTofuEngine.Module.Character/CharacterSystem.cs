using BlueTofuEngine.Core.Database;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Character
{
    public class CharacterSystem : ISystem
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
            entity.Send(new CharactersListMessage());
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
        }
        
        #endregion
    }
}

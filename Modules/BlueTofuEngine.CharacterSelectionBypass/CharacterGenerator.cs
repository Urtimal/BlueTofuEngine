using BlueTofuEngine.Core;
using BlueTofuEngine.Core.Serialization;
using BlueTofuEngine.Module.GameContext;
using BlueTofuEngine.Module.Stats;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Game;
using BlueTofuEngine.World.GameData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass
{
    public class CharacterGenerator : Singleton<CharacterGenerator>
    {
        public List<Breed> Breeds { get; set; }
        public List<Head> Heads { get; set; }

        public CharacterGenerator()
        {
            Breeds = new List<Breed>();
            Heads = new List<Head>();
        }

        public IEntity Generate(int breedId = -1)
        {
            var rand = new Random();
            var breed = breedId == -1 ? Breeds.ElementAt(rand.Next(0, Breeds.Count)) : Breeds.FirstOrDefault(x => x.Id == breedId);
            byte gender = (byte)(rand.Next(100) >= 50 ? 1 : 0);
            var possibleHeads = Heads.Where(x => x.Breed == breed.Id && x.Gender == gender);
            var head = possibleHeads.ElementAt(rand.Next(0, possibleHeads.Count()));

            var look = EntityLookParser.Parse(gender == 0 ? breed.MaleLook : breed.FemaleLook);
            look.Skins.Add(short.Parse(head.Skin));
            look.IndexedColors.AddRange(gender == 0 ? breed.MaleColors : breed.FemaleColors);

            var entity = EntityFactory.Instance.CreateCharacter();
            var entityLook = entity.GetComponent<LookComponent>();
            var entityFighter = entity.GetComponent<FighterComponent>();
            var entityPlayable = entity.GetComponent<CharacterComponent>();
            var entityStats = entity.Stats();

            entityLook.EntityName = "ByPass" + Guid.NewGuid().ToString().Substring(0, 4);
            entityLook.Look = look;
            entityFighter.Level = 1;
            entityPlayable.BreedId = breed.Id;
            entityPlayable.Gender = gender == 1;
            entityStats.Stats = new StatCollection();

            return entity;
        }
    }
}

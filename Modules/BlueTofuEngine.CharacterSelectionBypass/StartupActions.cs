using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.World.GameData;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.CharacterSelectionBypass
{
    public static class StartupActions
    {
        public static void LoadData()
        {
            var breedLoader = GameDataManager<Breed>.Instance;
            var headLoader = GameDataManager<Head>.Instance;

            int abandonCounter = 0;
            int id = 1;
            while (true)
            {
                var breed = breedLoader.Get(id);
                if (breed == null)
                {
                    abandonCounter++;
                    if (abandonCounter > 10)
                        break;
                }
                else
                    CharacterGenerator.Instance.Breeds.Add(breed);
                id++;
            }
            id = 1;
            abandonCounter = 0;
            while (true)
            {
                var head = headLoader.Get(id);
                if (head == null)
                {
                    abandonCounter++;
                    if (abandonCounter > 10)
                        break;
                }
                else
                    CharacterGenerator.Instance.Heads.Add(head);
                id++;
            }
        }
    }
}

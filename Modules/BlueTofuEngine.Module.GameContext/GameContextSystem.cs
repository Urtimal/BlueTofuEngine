using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Module.GameContext.Core;
using BlueTofuEngine.Module.GameContext.Messages;
using BlueTofuEngine.Module.Stats.Messages;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.Extensions;
using BlueTofuEngine.World.Game.GameContext;
using BlueTofuEngine.World.GameData;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueTofuEngine.Module.GameContext
{
    public class GameContextSystem : ISystem
    {
        public void OnNotification(IEntity entity, SystemEventArgs args)
        {
            switch (args)
            {
                case GameContextCreateRequestEventArgs gccrea:
                    var breedId = entity.Playable().BreedId;
                    var breedData = GameDataManager<Breed>.Instance.Get(breedId);
                    CreateRoleplayContext(entity, breedData.SpawnMap);
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }

        #region Handlers
        
        private void CreateRoleplayContext(IEntity entity, int map)
        {
            entity.Send(new GameContextDestroyMessage());
            Task.Delay(TimeSpan.FromMilliseconds(100)).Wait();
            entity.Send(new GameContextCreateMessage(GameContextType.RolePlay));

            entity.Map().MapId = map;
            entity.Map().CellId = 256;
            entity.Map().Direction = 1;
            entity.Send(new CurrentMapMessage(map));

            entity.Send(new CharacterStatsListMessage(entity));
        }

        #endregion
    }
}

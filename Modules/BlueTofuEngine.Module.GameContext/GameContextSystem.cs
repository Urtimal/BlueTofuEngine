using BlueTofuEngine.Core.GameData;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.GameContext.Data;
using BlueTofuEngine.Module.GameContext.Messages;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Components;
using BlueTofuEngine.World.Context;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Events;
using BlueTofuEngine.World.GameData;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    CreateRoleplayContext(entity, entity.Location().MapId);
                    break;
                case ChangeMapEventArgs cmea:
                    ChangeMap(entity, cmea.MapId, cmea.CellId, cmea.Dir);
                    break;
                case SpawnEntityOnMapEventArgs esomea:
                    SpawnEntityOnMap(esomea.Entity);
                    break;
                case RemoveEntityOnMapEventArgs eromea:
                    RemoveEntityOnMap(eromea.Entity);
                    break;
                case MoveEntityOnMapEventArgs meomea:
                    MoveEntity(meomea.Entity, meomea.KeyMovements);
                    break;
            }
        }

        public void OnTick(float deltaTime)
        {
        }

        #region Handlers
        
        private void CreateRoleplayContext(IEntity entity, long map)
        {
            entity.Send(new GameContextDestroyMessage());
            Task.Delay(TimeSpan.FromMilliseconds(100)).Wait();
            entity.GameContext().Type = GameContextType.RolePlay;
            entity.Send(new GameContextCreateMessage(GameContextType.RolePlay));

            ChangeMap(entity, entity.Location().MapId, entity.Location().CellId, entity.Location().Direction);
        }

        private void ChangeMap(IEntity entity, long mapId, int cellId, Direction direction)
        {
            if (entity.Context != null)
                RemoveEntityOnMap(entity);
            
            entity.Location().MapId = mapId;
            entity.Location().CellId = (ushort)cellId;
            entity.Location().Direction = direction;
            SpawnEntityOnMap(entity);
            entity.Send(new CurrentMapMessage(mapId));
        }

        private void SpawnEntityOnMap(IEntity entity)
        {
            var mapContext = MapManager.Instance.GetMapContext(entity.Location().MapId);
            mapContext.Send(new GameRolePlayShowActorMessage(entity));
            mapContext.AddEntity(entity);
        }

        private void RemoveEntityOnMap(IEntity entity)
        {
            if (entity.Context == null)
                return;

            entity.Context.RemoveEntity(entity.Id);
            entity.Context.Send(new GameContextRemoveElementMessage(entity.ContextualId));
            entity.Context = null;
        }

        private void MoveEntity(IEntity entity, IEnumerable<uint> keyMovements)
        {
            entity.Location().NextCellId = (ushort)(keyMovements.Last() & 0x0FFF);
            entity.Location().NextDirection = (Direction)((keyMovements.Last() & 0xF000) >> 12);
            var message = new GameMapMovementMessage();
            message.Entity = entity;
            message.Keys.AddRange(keyMovements);
            entity.Context.Send(message);
        }

        #endregion
    }
}

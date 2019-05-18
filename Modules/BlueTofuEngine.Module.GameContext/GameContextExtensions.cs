using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Module.Base;
using BlueTofuEngine.Module.Character;
using BlueTofuEngine.Module.GameContext;
using BlueTofuEngine.World;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Systems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine
{
    public static class GameContextExtensions
    {
        public static void UseGameContext(this IAppBuilder app)
        {
            NetworkMessageRepository.Instance.SearchMessagesInAssembly(Assembly.GetExecutingAssembly());
            NetworkMessageHandlerService.Instance.SearchHandlersInAssembly(Assembly.GetExecutingAssembly());
            SystemManager.Instance.Add<GameContextSystem>();
            UserDataService.Instance.RegisterModelCreation(GameContextModelCreation);
            ActionQueueManager.Instance.AddActionToQueue(ActionQueues.CharacterLoading, OnCharacterLoading);
            ActionQueueManager.Instance.AddActionToQueue(ActionQueues.ClientDisconnected, OnClientDisconnected);
        }

        private static void GameContextModelCreation(ModelBuilder builder)
        {
            builder.Entity<CharacterLocationUserData>()
                   .ToTable("CharacterLocations");
            builder.Entity<CharacterLocationUserData>()
                   .HasKey(x => new { x.CharacterId });
        }

        private static void OnCharacterLoading(IEntity entity)
        {
            var location = UserDataService.Instance.Get<CharacterLocationUserData>(entity.Character().CharacterId);
            if (location == null)
            {
                location = new CharacterLocationUserData
                {
                    CharacterId = entity.Character().CharacterId,
                    MapId = 191105026, // zaap astrub
                    Cell = 255,
                    Direction = (int)Direction.DownRight
                };
                UserDataService.Instance.Add(location);
            }

            entity.AddComponent<LocationComponent>();
            entity.Location().MapId = location.MapId;
            entity.Location().CellId = (ushort)location.Cell;
            entity.Location().Direction = (Direction)location.Direction;

            entity.AddComponent<GameContextComponent>();
            entity.GameContext().ContextualId = entity.Character().CharacterId;
        }

        private static void OnClientDisconnected(IEntity entity)
        {
            if (!entity.HasComponent<GameContextComponent>() || entity.Context == null)
                return;

            var characterLocation = UserDataService.Instance.Get<CharacterLocationUserData>(entity.Character().CharacterId);
            characterLocation.MapId = entity.Location().MapId;
            characterLocation.Cell = entity.Location().CellId;
            characterLocation.Direction = (byte)entity.Location().Direction;
            UserDataService.Instance.Update(characterLocation);

            entity.Notify(new RemoveEntityOnMapEventArgs(entity));
        }
    }
}

using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Module.Character;
using BlueTofuEngine.World.Systems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine
{
    public static class CharacterExtensions
    {
        public static void UseCharacters(this IAppBuilder app)
        {
            NetworkMessageRepository.Instance.SearchMessagesInAssembly(Assembly.GetExecutingAssembly());
            NetworkMessageHandlerService.Instance.SearchHandlersInAssembly(Assembly.GetExecutingAssembly());
            SystemManager.Instance.Add<CharacterListSystem>();
            SystemManager.Instance.Add<CharacterSystem>();
            UserDataService.Instance.RegisterModelCreation(CharactersModelCreation);
        }

        private static void CharactersModelCreation(ModelBuilder builder)
        {
            builder.Entity<CharacterUserData>()
                   .ToTable("Characters");
            builder.Entity<CharacterUserData>()
                   .HasKey(x => new { x.CharacterId });
        }
    }
}

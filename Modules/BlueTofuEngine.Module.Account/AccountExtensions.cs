using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Module.Account;
using BlueTofuEngine.World.Systems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace BlueTofuEngine
{
    public static class AccountExtensions
    {
        public static void UseAccounts(this IAppBuilder app)
        {
            NetworkMessageRepository.Instance.SearchMessagesInAssembly(Assembly.GetExecutingAssembly());
            SystemManager.Instance.Add<AccountSystem>();
            UserDataService.Instance.RegisterModelCreation(AccountsModelCreation);
        }

        public static void AccountsModelCreation(ModelBuilder builder)
        {
            builder.Entity<AccountUserData>()
                   .ToTable("Accounts");
            builder.Entity<AccountUserData>()
                   .HasKey(x => new { x.Id, x.AccountId, x.Username });

            builder.Entity<AccountCapabilityUserData>()
                   .ToTable("AccountCapabilities");
            builder.Entity<AccountCapabilityUserData>()
                   .HasKey(x => new { x.AccountId });
        }
    }
}

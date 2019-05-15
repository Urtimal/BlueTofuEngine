using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Module.Account;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlueTofuEngine
{
    public static class AccountExtensions
    {
        public static void UseAccounts(this IAppBuilder app)
        {
            UserDataService.Instance.RegisterModelCreation(AccountsModelCreation);
        }

        public static void AccountsModelCreation(ModelBuilder builder)
        {
            builder.Entity<AccountUserData>()
                   .HasKey(x => new { x.Id, x.AccountId, x.Username });
            builder.Entity<AccountUserData>()
                   .Property(x => x.AccountId)
                   .ValueGeneratedOnAdd();
        }
    }
}

using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Database;
using BlueTofuEngine.Module.Stats;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine
{
    public static class StatsExtensions
    {
        public static void UseStats(this IAppBuilder app)
        {
            UserDataService.Instance.RegisterModelCreation(StatsModelCreation);
        }

        private static void StatsModelCreation(ModelBuilder builder)
        {
            builder.Entity<CharacterStatsUserData>()
                   .ToTable("CharacterStats");
            builder.Entity<CharacterStatsUserData>()
                   .HasKey(x => new { x.CharacterId });
        }
    }
}

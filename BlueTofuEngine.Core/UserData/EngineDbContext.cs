using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.Database
{
    public class EngineDbContext : DbContext
    {
        private readonly IEnumerable<Action<ModelBuilder>> _builderActions;

        public EngineDbContext(DbContextOptions<EngineDbContext> options, IEnumerable<Action<ModelBuilder>> builderActions) : base(options)
        {
            _builderActions = builderActions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var action in _builderActions)
                action(modelBuilder);
        }
    }
}

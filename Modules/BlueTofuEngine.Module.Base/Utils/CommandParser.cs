using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.Module.Base
{
    public static class CommandParser
    {
        public static IEnumerable<IEntity> ParseTarget(string target, IEntity entity)
        {
            var list = new List<IEntity>();

            var targets = target.Split(',');
            foreach (var t in targets)
            {
                if (t.First() == '%')
                {
                    if (t == "%me%")
                    {
                        if (entity == null)
                        {
                            Console.WriteLine("%me% cannot be used on console");
                            return null;
                        }
                        list.Add(entity);
                    }
                    else if (t == "%map%")
                    {
                        if (entity == null)
                        {
                            Console.WriteLine("%map% cannot be used on console");
                            return null;
                        }
                        list.AddRange(EntityManager.Instance.Players.Where(x => x.Context.Id == entity.Context.Id));
                    }
                    else if (t == "%all%")
                        list.AddRange(EntityManager.Instance.Players);
                }
                else if (t.First() == '#' && t.Length > 1 && int.TryParse(t.Substring(1), out int entityId))
                {
                    if (entity != null)
                    {
                        var e = entity.Context.Entities.FirstOrDefault(x => x.ContextualId == entityId);
                        if (e != null)
                            list.Add(e);
                    }
                }
                else
                {
                    var player = EntityManager.Instance.Players.FirstOrDefault(x => x.Look().Name.Equals(t, StringComparison.OrdinalIgnoreCase));
                    if (player != null)
                        list.Add(player);
                }
            }

            return list.Distinct();
        }
    }
}

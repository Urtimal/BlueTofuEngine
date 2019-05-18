using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueTofuEngine.World
{
    public static class CommandParser
    {
        public static IEnumerable<IEntity> ParseTarget(string target, IEntity entity)
        {
            var list = new List<IEntity>();
            if (target == "%me%")
            {
                if (entity == null)
                {
                    Console.WriteLine("%me% cannot be used on console");
                    return null;
                }
                list.Add(entity);
            }
            else if (target == "%map%")
            {
                if (entity == null)
                {
                    Console.WriteLine("%map% cannot be used on console");
                    return null;
                }
                list.AddRange(EntityManager.Instance.Players.Where(x => x.Context.Id == entity.Context.Id));
            }
            else if (target == "%all%")
                list.AddRange(EntityManager.Instance.Players);

            return list;
        }
    }
}

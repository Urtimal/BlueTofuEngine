using BlueTofuEngine.World.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World.Queue
{
    public class ActionQueue
    {
        private readonly List<Action<IEntity>> _actions;

        public ActionQueue()
        {
            _actions = new List<Action<IEntity>>();
        }

        public void AddAction(Action<IEntity> action)
        {
            _actions.Add(action);
        }

        public void Execute(IEntity entity, Action<IEntity> callback = null)
        {
            foreach (var action in _actions)
                action.Invoke(entity);
            callback?.Invoke(entity);
        }
    }
}

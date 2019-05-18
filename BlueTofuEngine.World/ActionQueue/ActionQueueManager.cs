using BlueTofuEngine.Core;
using BlueTofuEngine.World.Entities;
using BlueTofuEngine.World.Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.World
{
    public class ActionQueueManager : Singleton<ActionQueueManager>
    {
        private readonly Dictionary<string, ActionQueue> _queues;

        public ActionQueueManager()
        {
            _queues = new Dictionary<string, ActionQueue>();
        }

        public void AddActionToQueue(string queueName, Action<IEntity> action)
        {
            if (!_queues.ContainsKey(queueName))
                _queues.Add(queueName, new ActionQueue());
            _queues[queueName].AddAction(action);
        }

        public void Execute(string queueName, IEntity entity, Action<IEntity> callback = null)
        {
            if (_queues.ContainsKey(queueName))
                _queues[queueName].Execute(entity, callback);
            else
                callback?.Invoke(entity);
        }
    }
}

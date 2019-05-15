using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.Module.BaseApproach;
using BlueTofuEngine.Module.StandardApproach;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine
{
    public static class ApproachExtensions
    {
        public static void UseStandardApproach(this IAppBuilder app)
        {
            NetworkMessageRepository.Instance.SearchMessagesInAssembly(Assembly.GetAssembly(typeof(HelloGameMessage)));
            NetworkMessageHandlerService.Instance.SearchHandlersInAssembly(Assembly.GetExecutingAssembly());
            SystemManager.Instance.Add<ApproachSystem>();
        }
    }
}

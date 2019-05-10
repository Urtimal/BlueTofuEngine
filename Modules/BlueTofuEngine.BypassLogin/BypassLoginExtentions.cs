using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Network.Message;
using BlueTofuEngine.World.Systems;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine.BypassLogin
{
    public static class BypassLoginExtentions
    {
        public static void UseBypassLogin(this IAppBuilder app)
        {
            NetworkMessageRepository.Instance.SearchMessagesInAssembly(Assembly.GetExecutingAssembly());
            NetworkMessageHandlerService.Instance.SearchHandlersInAssembly(Assembly.GetExecutingAssembly());
            SystemManager.Instance.Add<ByPassLoginSystem>();
        }
    }
}

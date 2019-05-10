using BlueTofuEngine.Core.AppBuilder;
using BlueTofuEngine.Core.Network.Message;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BlueTofuEngine.GameServer
{
    public static class CommonBasicExtensions
    {
        public static void UseCommonBasic(this IAppBuilder app)
        {
            NetworkMessageRepository.Instance.SearchMessagesInAssembly(Assembly.GetExecutingAssembly());
            NetworkMessageHandlerService.Instance.SearchHandlersInAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

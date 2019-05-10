using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace BlueTofuEngine.Core
{
    public static class ServiceProviderExtensions
    {
        public static void InvokeMethod(this IServiceProvider serviceProvider, Delegate method)
        {
            var methodParams = method.Method.GetParameters();
            var paramValues = new List<object>();
            foreach (var methodParam in methodParams)
                paramValues.Add(serviceProvider.GetRequiredService(methodParam.ParameterType));
            method.DynamicInvoke(paramValues.ToArray());
        }

        public static TObject InvokeCtor<TObject>(this IServiceProvider serviceProvider)
        {
            var ctor = typeof(TObject).GetConstructors().Single();
            var ctorParameters = ctor.GetParameters();
            var paramValues = new List<object>();
            foreach (var ctorParam in ctorParameters)
                paramValues.Add(serviceProvider.GetRequiredService(ctorParam.ParameterType));
            return (TObject)ctor.Invoke(paramValues.ToArray());
        }
    }
}

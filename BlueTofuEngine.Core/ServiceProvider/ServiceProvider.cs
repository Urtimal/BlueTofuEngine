using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core
{
    public static class GlobalServiceProvider
    {
        public static IServiceProvider Services { get; set; }
    }
}

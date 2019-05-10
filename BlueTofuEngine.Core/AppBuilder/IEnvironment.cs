using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core.AppBuilder
{
    public interface IEnvironment
    {
        TObject Get<TObject>();
    }
}

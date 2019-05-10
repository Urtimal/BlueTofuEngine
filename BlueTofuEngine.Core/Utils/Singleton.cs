using System;
using System.Collections.Generic;
using System.Text;

namespace BlueTofuEngine.Core
{
    public class Singleton<TSingletonType> where TSingletonType : class, new()
    {
        private static TSingletonType _instance = null;
        public static TSingletonType Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TSingletonType();
                return _instance;
            }
        }
    }
}

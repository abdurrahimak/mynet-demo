using System;

namespace MynetDemo.Core
{
    // singleton class without unity component
    public abstract class SingletonClass<T> where T : class
    {
        private static T _instance = null;
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = Activator.CreateInstance<T>();
                }
                return _instance;
            }
        }
    }
}

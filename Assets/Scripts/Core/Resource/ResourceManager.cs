using System.Collections.Generic;
using System;
using UnityEngine;

namespace MynetDemo.Core
{
    public class ResourceManager : SingletonClass<ResourceManager>
    {
        #region Fields

        private Dictionary<string, UnityEngine.Object> _resources;

        #endregion

        #region Installation

        public void Initialize()
        {
            LoadFromResourcesFolder();
        }

        private void LoadFromResourcesFolder()
        {
            _resources = new Dictionary<string, UnityEngine.Object>();
            var resources = Resources.LoadAll("");
            foreach (var resource in resources)
            {
                _resources.Add(resource.name, resource);
            }
        }

        #endregion

        #region Interface
        /// <summary>
        /// Get the object at runtime. Object must be in the Resources folder
        /// </summary>
        /// <typeparam name="T">Object Type. UnityEngine.GameObject or those derived from UnityEngine.Object class.</typeparam>
        /// <param name="name">Object name. The Name is must equal to the name in the Resources folder</param>
        /// <returns></returns>
        public T GetResource<T>(string name) where T : UnityEngine.Object
        {
            if (_resources.ContainsKey(name))
            {
                return _resources[name] as T;
            }
            else
            {
                throw new ArgumentNullException(name + ", Resource does not found in resources.");
            }
        }

        #endregion
    }
}
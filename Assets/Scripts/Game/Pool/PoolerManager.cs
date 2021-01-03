using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MynetDemo.Core;
using UnityEngine;

namespace MynetDemo.Game
{
    public class PoolerManager : SingletonComponent<PoolerManager>
    {
        private Dictionary<string, Queue<GameObject>> _poolDictionary;
        private PoolData _poolData;
        private int _creationCountForEmptyTag = 2;
        private GameObject _poolParentObject;

        private void Start()
        {
            CreatePoolParent();
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();
            _poolData = ResourceManager.Instance.GetResource<PoolData>("PoolData");
            foreach (var pool in _poolData.Pools)
            {
                CreateObjectToPool(pool, pool.Size);
            }
        }

        internal void Initialize()
        {
        }

        private void CreatePoolParent()
        {
            _poolParentObject = new GameObject("PoolParent");
            _poolParentObject.transform.SetParent(gameObject.transform);
            _poolParentObject.SetActive(false);
        }

        private Pool FindPool(string tag)
        {
            foreach (var pool in _poolData.Pools)
            {
                if (pool.Tag.Equals(tag))
                {
                    return pool;
                }
            }
            throw new System.ArgumentNullException();
        }

        private void CreateObjectToPool(Pool pool)
        {
            GameObject go = GameObject.Instantiate(pool.Prefab, _poolParentObject.transform);
            if (!_poolDictionary.ContainsKey(pool.Tag))
            {
                _poolDictionary.Add(pool.Tag, new Queue<GameObject>());
            }
            _poolDictionary[pool.Tag].Enqueue(go);
        }

        private void CreateObjectToPool(Pool pool, int size)
        {
            Debug.Log("Creating " + size + " item into pool");
            for (int i = 0; i < size; i++)
            {
                CreateObjectToPool(pool);
            }
        }

        public GameObject GetPoolObject(string poolTag, Transform parent = null)
        {
            if (!_poolDictionary.ContainsKey(poolTag) || _poolDictionary[poolTag].Count == 0)
            {
                var pool = FindPool(poolTag);
                CreateObjectToPool(pool, _creationCountForEmptyTag);
            }

            GameObject go = _poolDictionary[poolTag].Dequeue();
            go.transform.SetParent(parent);
            return go;
        }

        public GameObject GetPoolObjectForSeconds(string poolTag, float time, Transform parent = null)
        {
            GameObject go = GetPoolObject(poolTag, parent);
            StartCoroutine(GiveBackToPoolAfterSeconds(go, poolTag, time));
            return go;
        }

        public void AddObjectToPool(GameObject go, string poolTag)
        {
            if (!_poolDictionary.ContainsKey(poolTag))
            {
                _poolDictionary.Add(poolTag, new Queue<GameObject>());
            }
            _poolDictionary[poolTag].Enqueue(go);
            go.transform.SetParent(_poolParentObject.transform);
        }

        private IEnumerator GiveBackToPoolAfterSeconds(GameObject go, string poolTag, float time)
        {
            yield return new WaitForSeconds(time);
            AddObjectToPool(go, poolTag);
        }
    }
}

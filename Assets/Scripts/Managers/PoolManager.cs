using System.Collections.Generic;
using UnityEngine;

namespace Managers
{  
    public class PoolManager<T> : SingletonManager<PoolManager<T>> where T: MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [SerializeField] private int _size;

        private List<T> _freeList=new List<T>();
        private List<T> _usedList=new List<T>();
 
        public void Awake()
        {
            for (var i = 0; i < _size; i++)
            {
                var pooledObject = Instantiate(_prefab, transform);
                _freeList.Add(pooledObject);
            }
        }
        
        public T Get()
        {
            var numFree = _freeList.Count;
            if (numFree == 0)
                return null;

            var pooledObject = _freeList[numFree - 1];
            _freeList.RemoveAt(numFree - 1);
            _usedList.Add(pooledObject);
            return pooledObject;
        }
 
        public void ReturnObject(T pooledObject)
        {
            _usedList.Remove(pooledObject);
            _freeList.Add(pooledObject);
            
            var pooledObjectTransform = pooledObject.transform;
            pooledObjectTransform.localPosition = Vector3.zero;
        }
    }
}
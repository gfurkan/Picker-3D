using System.Collections.Generic;
using UnityEngine;

namespace Managers
{  
    public class PoolManager<T> : SingletonManager<PoolManager<T>> where T: MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [SerializeField] private int _size;

        private Queue<T> _freeList=new Queue<T>();
        private List<T> _usedList=new List<T>();
 
        public void Awake()
        {
            for (var i = 0; i < _size; i++)
            {
                var pooledObject = Instantiate(_prefab, transform);
                _freeList.Enqueue(pooledObject);
            }
        }
        
        public T Get()
        {
            var numFree = _freeList.Count;
            if (numFree == 0)
            {
                FillPoolIfEmpty();
                numFree = _freeList.Count;
            }
            var pooledObject = _freeList.Dequeue();
            _usedList.Add(pooledObject);
            return pooledObject;
        }
 
        public void ReturnObject(T pooledObject)
        {
            _usedList.Remove(pooledObject);
            _freeList.Enqueue(pooledObject);
            
            var pooledObjectTransform = pooledObject.transform;
            pooledObjectTransform.localPosition = Vector3.zero;
        }

        private void FillPoolIfEmpty()
        {
            for (var i = 0; i < 10; i++)
            {
                var pooledObject = Instantiate(_prefab, transform);
                _freeList.Enqueue(pooledObject);
            }
        }
    }
}
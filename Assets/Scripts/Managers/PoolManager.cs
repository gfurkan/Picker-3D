using System;
using System.Collections.Generic;
using Collectibles;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using IPoolable = Interfaces.IPoolable;

namespace Managers
{  
    public class PoolManager :  SingletonManager<PoolManager>
{
        #region Fields

        [SerializeField] private CollectibleController _collectiblePrefab;
        [SerializeField] private int _poolSize = 0;
        
        private Queue<CollectibleController> _pooledObjects = new Queue<CollectibleController>();
      
        #endregion
        
        #region Properties
        
        
        #endregion

        #region Unity Methods

        void Awake()
        {
             FillPool();
        }
        
        #endregion

        #region Private Methods
        

        void FillPool()
        {
            for (int i = 0; i < _poolSize; i++)
            {
               var obj= Instantiate(_collectiblePrefab,  transform);
               _pooledObjects.Enqueue(obj);
               obj.gameObject.SetActive(false);
            }
        }

        void FillPoolIfEmpty(int digitValue)
        {
            if (_pooledObjects.Count == 0)
            {
                for (int i = 0; i < digitValue; i++)
                {
                    var obj= Instantiate(_collectiblePrefab, transform);
                    _pooledObjects.Enqueue(obj);
                }
            }
           
        }
        #endregion

        #region Public Methods

        public CollectibleController GetObjectFromPool()
        {
            FillPoolIfEmpty(10);
            var obj=_pooledObjects.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void AddObjectToPool(CollectibleController obj)
        {
            obj.GetComponent<IPoolable>().OnObjectPooled();
            _pooledObjects.Enqueue(obj);
            obj.gameObject.SetActive(false);
        }
        
        #endregion
    }
  
}
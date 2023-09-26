using Interfaces;
using Managers;
using UnityEngine;

namespace Collectibles
{  
public class CollectibleController : MonoBehaviour,IPoolable
{
    #region Fields

    private bool _isCollectibleAvailable = false;
    private Rigidbody _rb;
    
    #endregion


    #region Unity Methods

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isCollectibleAvailable)
        {
            if (other.TryGetComponent(out ICollector obstacle))
            {
                obstacle.CollectObject(this);
                _isCollectibleAvailable = false;
            } 
        }
    }

    #endregion

    #region Public Methods

    public void OnObjectSpawned(Vector3 position,Transform parent)
    {
        _isCollectibleAvailable = true;
        transform.parent = parent;
        transform.localPosition = position;
        _rb.isKinematic = false;
    }
    
    public void OnObjectPooled()
    {
        _rb.isKinematic = true;
        _isCollectibleAvailable = false;
        PoolManager.Instance.AddObjectToPool(this);
    }
    

    #endregion
}
}
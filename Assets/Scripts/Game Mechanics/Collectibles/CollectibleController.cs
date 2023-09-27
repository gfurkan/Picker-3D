using Interfaces;
using Managers;
using Pools;
using UnityEngine;

namespace Collectibles
{  
public class CollectibleController : MonoBehaviour
{
    #region Fields

    private bool _isCollectibleAvailable = false;
    private Rigidbody _rb;
    
    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        LevelManager.OnLevelChanged += PoolObjectBack;
    }

    private void OnDisable()
    {
        LevelManager.OnLevelChanged -= PoolObjectBack;
    }

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
                obstacle.CollectObject();
                _isCollectibleAvailable = false;
            } 
        }
    }

    #endregion

    #region Public Methods

    public void OnObjectSpawned(Vector3 position,Transform parent)
    {
        _isCollectibleAvailable = true;
        transform.position = position;
        
        _rb.interpolation = RigidbodyInterpolation.Interpolate;
        _rb.isKinematic = false;
    }

    public void PoolObjectBack()
    {
        transform.localPosition = Vector3.zero;
        
        _rb.interpolation = RigidbodyInterpolation.None;
        _rb.isKinematic = true;
        
        _isCollectibleAvailable = false;
        CollectiblePoolController.Instance.ReturnObject(this);
    }
    

    #endregion
}
}
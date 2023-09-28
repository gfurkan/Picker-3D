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
    private bool _isSpawned = false;
    
    private Rigidbody _rb;
    
    #endregion


    #region Unity Methods

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += PoolObjectBack;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= PoolObjectBack;
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

    public void OnObjectSpawned(Vector3 position)
    {
        _isCollectibleAvailable = true;
        _isSpawned = true;
        
        _rb.interpolation = RigidbodyInterpolation.Interpolate;
        _rb.isKinematic = false;
        _rb.MovePosition(position);
    }

    public void PoolObjectBack(GameStates state)
    {
        if (state is GameStates.Fail || state is GameStates.Success)
        {
            if (_isSpawned)
            {
                _isSpawned = false;
                _rb.MovePosition(Vector3.back*25);
        
                _rb.interpolation = RigidbodyInterpolation.None;
                _rb.isKinematic = true;
        
                _isCollectibleAvailable = false;
                CollectiblePoolController.Instance.ReturnObject(this);
            } 
        }

    }
    

    #endregion
}
}
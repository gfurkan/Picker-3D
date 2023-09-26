using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

namespace Collectibles
{  
public class CollectibleController : MonoBehaviour,IPoolable
{
    #region Fields

    private Rigidbody _rb;
    
    #endregion

    #region Properties
    


    #endregion

    #region Unity Methods

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void Update()
    {
        
    }



    #endregion

    #region Private Methods


    
    #endregion

    #region Public Methods

    public void OnObjectSpawned(Vector3 position,Transform parent)
    {
        transform.parent = parent;
        transform.localPosition = position;
        _rb.isKinematic = false;
    }
    
    public void OnObjectPooled()
    {
        _rb.isKinematic = true;
    }
    
    #endregion
}
}
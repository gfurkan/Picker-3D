using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{  
public interface IPoolable
{
    #region Fields


    
    #endregion

    #region Properties
    


    #endregion

    #region Unity Methods

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

    public void OnObjectSpawned(Vector3 position,Transform parent);

    public void OnObjectPooled();

    #endregion
}
}
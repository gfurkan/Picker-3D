using UnityEngine;

namespace Interfaces
{  
public interface IPoolable
{
    #region Public Methods

    public void OnObjectSpawned(Vector3 position,Transform parent);

    public void OnObjectPooled();

    #endregion
}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{  
public interface ICollector
{

    #region Public Methods

    public void CollectObject(IPoolable obj);

    #endregion
}
}
using Managers;
using UnityEngine;

namespace Collectibles
{  
public class CollectibleCreator : MonoBehaviour
{
    #region Fields

    [SerializeField] private Vector2 _ballCounts;
    [SerializeField] private Vector2 _collectibleDistanceValues;
    
    private 
    #endregion

    #region Unity Methods

    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        CreateCollectibles();
     
    }

    #endregion

    #region Private Methods

    void CreateCollectibles()
    {
        for (int i = 0; i < _ballCounts.x; i++)
        {
            for (int j = 0; j < _ballCounts.y; j++)
            {
                var obj = PoolManager.Instance.GetObjectFromPool();
                Vector3 spawnPos =transform.position+(Vector3.right * i * _collectibleDistanceValues.x) + (Vector3.forward * j * _collectibleDistanceValues.y);
                obj.OnObjectSpawned(spawnPos,transform);
            }
        }
    }
    
    #endregion

}
}
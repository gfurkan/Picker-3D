using Pools;
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
        float XStartPosition = 0;
        if (_ballCounts.x % 2 is 0)
        {
            XStartPosition =- (((int)(_ballCounts.x / 2) * _collectibleDistanceValues.x)-(_collectibleDistanceValues.x/2));
        }
        else
        {
            XStartPosition =- (int)(_ballCounts.x / 2) * _collectibleDistanceValues.x;
        }

        for (int i = 0; i < _ballCounts.x; i++)
        {
            for (int j = 0; j < _ballCounts.y; j++)
            {
                var obj = CollectiblePoolController.Instance.Get();
                Vector3 spawnPos=Vector3.zero;
                spawnPos.x = XStartPosition;
                
                spawnPos +=transform.position+(Vector3.right * i * _collectibleDistanceValues.x) + (Vector3.forward * j * _collectibleDistanceValues.y);
                obj.OnObjectSpawned(spawnPos);
            }
        }
    }
    
    #endregion

}
}
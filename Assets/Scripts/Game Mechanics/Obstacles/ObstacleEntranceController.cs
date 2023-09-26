using Managers;
using UnityEngine;

namespace Obstacles
{  
public class ObstacleEntranceController : MonoBehaviour
{

    [SerializeField] private PoolObstacleController _obstacleController;
    
    #region Unity Methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SetGameWaiting();
            _obstacleController.ControlLevelFail();
            GetComponent<Collider>().enabled = false;
        }
    }

    #endregion

    #region Private Methods

    void SetGameWaiting()
    {
        GameManager.Instance.UpdateGameState(GameStates.Obstacle);
    }
    
    #endregion
    
}
}
using Managers;
using UnityEngine;

namespace Finish
{  
public class FinishController : MonoBehaviour
{
    #region Unity Methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.UpdateGameState(GameStates.Success);
            GetComponent<Collider>().enabled = false;
        }
    }

    #endregion
}
}
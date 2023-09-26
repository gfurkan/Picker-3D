using Settings;
using UnityEngine;

namespace Cam
{  
public class CameraMovement : MonoBehaviour
{
    #region Fields
    
    [SerializeField] private CameraSettings _cameraSettings;

    private Transform _player;
    private Vector3 _distance;
    
    #endregion

    #region Properties
    


    #endregion

    #region Unity Methods

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _distance = transform.position - _player.position;
    }
    void Update()
    {
        FollowPlayer();
    }

    #endregion

    #region Private Methods

    void FollowPlayer()
    {
        Vector3 destination = _player.position + _distance;
        destination.x = transform.position.x;
        
        transform.position =
            Vector3.Lerp(transform.position, destination, _cameraSettings.CameraMovementSpeed * Time.deltaTime);
    }
    
    #endregion

    #region Public Methods


    
    #endregion
}
}
using Managers;
using UnityEngine;

namespace Cam
{  
public class CameraMovement : MonoBehaviour
{
    #region Fields
    
    private Vector3 _startPosition;
    private Vector3 _distance;
    
    private Transform _player;
    private bool _isFollowEnabled = false;
    
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        LevelManager.OnLevelChanged += ResetPosition;
        GameManager.OnGameStateChanged += ControlMovement;
    }

    private void OnDisable()
    {
        LevelManager.OnLevelChanged -= ResetPosition;
        GameManager.OnGameStateChanged -= ControlMovement;
    }

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        
        _distance = transform.position - _player.position;
        _startPosition = transform.position;
    }
    void LateUpdate()
    {
        if (_isFollowEnabled)
        {
            FollowPlayer();
        }
  
    }

    #endregion

    #region Private Methods

    void FollowPlayer()
    {
        Vector3 destination = _player.position + _distance;
        destination.x = transform.position.x;
        transform.position = destination;
    }

    void ResetPosition()
    {
        transform.position = _startPosition;
    }

    void ControlMovement(GameStates state)
    {
        if (state is GameStates.Running)
        {
            _isFollowEnabled = true;
        }
        else if (state is GameStates.Idle || state is GameStates.Fail || state is GameStates.Success)
        {
            _isFollowEnabled = false;
        }
    }
    #endregion

}
}
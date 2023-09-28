using Managers;
using Settings;
using UnityEngine;

namespace Player
{  
public class PlayerMovement : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerMovementSettings _movementSettings;

    private Vector3 _startPosition;
    private Vector3 _movementSpeed;
    private Rigidbody _rb;

    private bool _isMovementEnabled = false;
    
    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += SetMovementControls;
        LevelManager.OnLevelChanged += ResetPosition;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= SetMovementControls;
        LevelManager.OnLevelChanged -= ResetPosition;
    }

    private void Awake()
    {
        _startPosition = transform.position;
        _rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if (_isMovementEnabled)
        {
            MovePlayer();
        }
    }

    #endregion

    #region Private Methods

    void MovePlayer()
    {
         float XSpeed = InputManager.Instance.directionVector.x*_movementSettings.SwerveMovementSpeed;
         float ZSpeed = _movementSettings.ForwardMovementSpeed;

         if (transform.position.x <= _movementSettings.SwerveClamp.x)
         {
             if (XSpeed < 0)
             {
                 XSpeed = 0;
             }
         }
         if (transform.position.x >= _movementSettings.SwerveClamp.y)
         {
             if ( XSpeed> 0)
             {
                 XSpeed = 0;
             }
         }
         _movementSpeed.x = XSpeed;
         _movementSpeed.y = 0;
         _movementSpeed.z = ZSpeed;

         _rb.velocity = _movementSpeed;
    }

    void SetMovementControls(GameStates state)
    {
        if (state is GameStates.Running)
        {
            _isMovementEnabled = true;
            _rb.isKinematic = false;
            _rb.interpolation = RigidbodyInterpolation.Interpolate;
        }
        else
        {
            _isMovementEnabled = false;
            _rb.velocity = Vector3.zero;
            _rb.isKinematic = true; 
            _rb.interpolation = RigidbodyInterpolation.None;
        }
    }
    void ResetPosition()
    {
        transform.position = _startPosition;
    }
    #endregion
    
}
}
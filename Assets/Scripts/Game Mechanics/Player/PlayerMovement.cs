using Managers;
using Settings;
using UnityEngine;

namespace Player
{  
public class PlayerMovement : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerMovementSettings _movementSettings;
    
    private Vector3 movementSpeed;
    private Rigidbody _rb;

    private bool _isMovementEnabled = false;
    
    #endregion

    #region Properties
    


    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        GameManager.OnGameStateChanged += SetMovementControls;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChanged -= SetMovementControls;
    }

    private void Awake()
    {
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
         movementSpeed.x = XSpeed;
         movementSpeed.y = 0;
         movementSpeed.z = ZSpeed;

         _rb.velocity = movementSpeed;
    }

    void SetMovementControls(GameStates state)
    {
        if (state is GameStates.Running)
        {
            ControlMovement(true);
        }
        else
        {
            ControlMovement(false);
            _rb.velocity = Vector3.zero;
        }
    }
    void ControlMovement(bool value)
    {
        _isMovementEnabled = value;
    }
    #endregion

    #region Public Methods


    
    #endregion
}
}
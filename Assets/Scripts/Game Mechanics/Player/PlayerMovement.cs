using System.Collections;
using System.Collections.Generic;
using Managers;
using Settings;
using UnityEngine;

namespace Player
{  
public class PlayerMovement : MonoBehaviour
{
    #region Fields

    [SerializeField] private PlayerMovementSettings _movementSettings;
    
    private Vector3 movementDirection;
    #endregion

    #region Properties
    


    #endregion

    #region Unity Methods

    void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
    }

    #endregion

    #region Private Methods

    void MovePlayer()
    {
        Vector3 movementPosition = Vector3.zero;
        
         float XPosition = Mathf.Clamp(transform.position.x + InputManager.Instance.directionVector.x*_movementSettings.SwerveMovementSpeed*Time.deltaTime, _movementSettings.SwerveClamp.x, _movementSettings.SwerveClamp.y);
         float ZPosition = transform.position.z + _movementSettings.ForwardMovementSpeed*Time.deltaTime;
         
         movementPosition.x = XPosition;
         movementPosition.y = transform.position.y;
         movementPosition.z = ZPosition;
         
         transform.position = movementPosition;
    }
    #endregion

    #region Public Methods


    
    #endregion
}
}
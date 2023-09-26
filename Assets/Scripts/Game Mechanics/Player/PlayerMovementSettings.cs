using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{  
    [CreateAssetMenu(fileName = "Player Movement Settings",menuName = "Scriptable Objects/Player/Player Movement")]
public class PlayerMovementSettings : ScriptableObject
{
    #region Fields

    [SerializeField] private float _forwardMovementSpeed = 0;
    [SerializeField] private float _swerveMovementSpeed = 0;
    [SerializeField] private Vector2 _swerveClamp;
    
    #endregion

    #region Properties
    
    public float ForwardMovementSpeed => _forwardMovementSpeed;
    public float SwerveMovementSpeed => _swerveMovementSpeed;
    public Vector2 SwerveClamp => _swerveClamp;

    #endregion
}
}
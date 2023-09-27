using UnityEngine;

namespace Settings
{  
    [CreateAssetMenu(fileName = "Player Movement Settings",menuName = "Scriptable Objects/Player/Player Movement")]
public class PlayerMovementSettings : ScriptableObject
{
    #region Fields

    [SerializeField] private Vector2 _swerveClamp;
    [SerializeField] private float _forwardMovementSpeed = 0;
    [SerializeField] private float _swerveMovementSpeed = 0;
    
    #endregion

    #region Properties
    
    public Vector2 SwerveClamp => _swerveClamp;
    public float ForwardMovementSpeed => _forwardMovementSpeed;
    public float SwerveMovementSpeed => _swerveMovementSpeed;

    #endregion
}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{  
    [CreateAssetMenu(fileName = "Camera Settings",menuName = "Scriptable Objects/Camera/Camera Settings")]
public class CameraSettings : ScriptableObject
{
    #region Fields

    [SerializeField] private float _cameraMovementSpeed = 0;

    #endregion

    #region Properties

    public float CameraMovementSpeed => _cameraMovementSpeed;

    #endregion
}
}
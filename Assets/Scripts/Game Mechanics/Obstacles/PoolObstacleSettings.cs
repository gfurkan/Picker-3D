using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{  
    [CreateAssetMenu(fileName = "Pool Obstacle Settings",menuName = "Scriptable Objects/Obstacle/Pool Obstacle")]
public class PoolObstacleSettings : ScriptableObject
{
    #region Fields

    [SerializeField] private float _obstacleCompleteDelay = 0;
    [SerializeField] private float _obstacleWaitingTime = 0;
    
    #endregion

    #region Properties
    
    public float ObstacleCompleteDelay => _obstacleCompleteDelay;
    public float ObstacleWaitingTime => _obstacleWaitingTime;

    #endregion
    
}
}
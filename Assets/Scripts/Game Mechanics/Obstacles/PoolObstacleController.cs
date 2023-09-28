using System.Collections;
using Interfaces;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Managers;
using Settings;

namespace Obstacles
{  
public class PoolObstacleController : MonoBehaviour,ICollector
{
    #region Fields

    [SerializeField] private PoolObstacleSettings _obstacleSettings;
    [SerializeField] private int _requiredCollectibleCount = 0;
    
    [SerializeField] private TextMeshPro _scoreText;
    [SerializeField] private Transform _floorPart;
    
    private int _collectedCollectibleCount = 0;
    private bool _isObstacleCompleted = false;
    private bool _isLevelFinished = false;
    
    #endregion

    #region Unity Methods

    private void Start()
    {
        _scoreText.text = _collectedCollectibleCount + " / " + _requiredCollectibleCount;
    }

    #endregion

    #region Private Methods

    IEnumerator CompleteObstacle()
    {
        if (_collectedCollectibleCount >= _requiredCollectibleCount)
        {
            _isObstacleCompleted = true;
            yield return new WaitForSeconds(_obstacleSettings.ObstacleCompleteDelay);
            
            Vector3 pos = new Vector3(_floorPart.transform.position.x, 0, _floorPart.transform.position.z);
            _floorPart.transform.DOMove(pos, 0.5f).OnComplete((() => GameManager.Instance.UpdateGameState(GameStates.Running)));
        }
    }

    IEnumerator SetLevelFailed()
    {
        yield return new WaitForSeconds(_obstacleSettings.ObstacleWaitingTime);
        if (!_isObstacleCompleted)
        {
            GameManager.Instance.UpdateGameState(GameStates.Fail);
        }

    }

    void ControlCollecting(GameStates state)
    {
        if (state is GameStates.Fail || state is GameStates.Success)
        {
            _isLevelFinished = true;
        }
        else
        {
            _isLevelFinished = false;
        }
    }
    #endregion

    #region Public Methods

    public void CollectObject()
    {
        if (!_isLevelFinished)
        {
            _collectedCollectibleCount++;
            _scoreText.text = _collectedCollectibleCount + " / " + _requiredCollectibleCount;

            if (!_isObstacleCompleted)
            {
                StartCoroutine(CompleteObstacle());
            }
        }
    }
    
    
    public void ControlLevelFail()
    {
        StartCoroutine(SetLevelFailed());
    }
    #endregion

   
}
}
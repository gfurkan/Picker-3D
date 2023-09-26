using System.Collections;
using System.Collections.Generic;
using Interfaces;
using TMPro;
using UnityEngine;
using DG.Tweening;
using Managers;

namespace Obstacles
{  
public class PoolObstacleController : MonoBehaviour,ICollector
{
    #region Fields

    [SerializeField] private int _requiredCollectibleCount = 0;
    [SerializeField] private float _obstacleCompleteDelay = 0;
    [SerializeField] private float _obstacleWaitingTime = 0;
    
    [SerializeField] private TextMeshPro _scoreText;
    [SerializeField] private Transform _floorPart;
    
    private int _collectedCollectibleCount = 0;
    private List<IPoolable> _collectedObjects = new List<IPoolable>();
    private bool _isObstacleCompleted = false;
    
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
            for (int i = 0; i < _collectedObjects.Count; i++)
            {
                _collectedObjects[i].OnObjectPooled();
                yield return new WaitForSeconds(_obstacleCompleteDelay/_collectedObjects.Count);
            }
            yield return new WaitForSeconds(_obstacleCompleteDelay);
            
            Vector3 pos = new Vector3(_floorPart.transform.position.x, 0, _floorPart.transform.position.z);
            _floorPart.transform.DOMove(pos, 0.5f).OnComplete((() => GameManager.Instance.UpdateGameState(GameStates.Running)));
        }
    }

    IEnumerator SetLevelFailed()
    {
        yield return new WaitForSeconds(_obstacleWaitingTime);
        if (!_isObstacleCompleted)
        {
            GameManager.Instance.UpdateGameState(GameStates.Fail);
            print(name);
        }

    }
    #endregion

    #region Public Methods

    public void CollectObject(IPoolable obj)
    {
        _collectedCollectibleCount++;
        _scoreText.text = _collectedCollectibleCount + " / " + _requiredCollectibleCount;
        _collectedObjects.Add(obj);

        if (!_isObstacleCompleted)
        {
            StartCoroutine(CompleteObstacle());
        }
    }
    
    
    public void ControlLevelFail()
    {
        StartCoroutine(SetLevelFailed());
    }
    #endregion

   
}
}
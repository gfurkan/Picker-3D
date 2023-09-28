using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{  
public class LevelManager : SingletonManager<LevelManager>
{
    #region Fields

    public static event Action OnLevelChanged;
    
    [SerializeField] private List<GameObject> levelPrefabs = new List<GameObject>();
    
    private GameObject currentLevel;
     
    #endregion

    #region Properties

    private int _levelIndex
    {
        get => PlayerPrefs.GetInt("levelIndex");
        set
        {
            PlayerPrefs.SetInt("levelIndex",value);
        }
    }
    private int _levelToPlay
    {
        get => PlayerPrefs.GetInt("levelToPlay");
        set
        {
            PlayerPrefs.SetInt("levelToPlay",value);
        }
    }
    #endregion
    #region Unity Methods

    private void Start()
    {
        LoadCurrentLevel();
    }

    #endregion
     
    #region Public Methods
     
    public void LoadCurrentLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel);
            currentLevel=Instantiate(levelPrefabs[_levelToPlay], Vector3.zero, Quaternion.identity);
        }
        else
        {
            currentLevel=Instantiate(levelPrefabs[_levelToPlay], Vector3.zero, Quaternion.identity);
        }
        GameManager.Instance.UpdateGameState(GameStates.Idle);
        UIManager.Instance.SetLevelText(_levelIndex);
        
        OnLevelChanged?.Invoke();
    }

    public void LoadNextLevel()
    {
        _levelIndex++;
        _levelToPlay = _levelIndex;

        if (_levelIndex > levelPrefabs.Count - 1)
        {
            _levelToPlay = Random.Range(0, levelPrefabs.Count);
        }
        
        Destroy(currentLevel);
        currentLevel=Instantiate(levelPrefabs[_levelToPlay], Vector3.zero, Quaternion.identity);
        
        GameManager.Instance.UpdateGameState(GameStates.Idle);
        UIManager.Instance.SetLevelText(_levelIndex);
        
        OnLevelChanged?.Invoke();
    }

    #endregion

}

}
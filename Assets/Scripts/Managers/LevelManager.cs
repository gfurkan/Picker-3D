using System;
using System.Collections.Generic;
using UnityEngine;

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
            currentLevel=Instantiate(levelPrefabs[_levelIndex%(levelPrefabs.Count)], Vector3.zero, Quaternion.identity);
        }
        else
        {
            currentLevel=Instantiate(levelPrefabs[_levelIndex%(levelPrefabs.Count)], Vector3.zero, Quaternion.identity);
        }
        GameManager.Instance.UpdateGameState(GameStates.Idle);
        UIManager.Instance.SetLevelText(_levelIndex);
        
        OnLevelChanged?.Invoke();
    }

    public void LoadNextLevel()
    {
        _levelIndex++;
        
        Destroy(currentLevel);
        currentLevel=Instantiate(levelPrefabs[_levelIndex%(levelPrefabs.Count)], Vector3.zero, Quaternion.identity);
        
        GameManager.Instance.UpdateGameState(GameStates.Idle);
        UIManager.Instance.SetLevelText(_levelIndex);
        
        OnLevelChanged?.Invoke();
    }

    #endregion

}

}
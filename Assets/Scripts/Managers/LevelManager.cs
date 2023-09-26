using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{  
public class LevelManager : SingletonManager<LevelManager>
{
    #region Fields

    [SerializeField] private List<GameObject> levelPrefabs = new List<GameObject>();
    
    private GameObject currentLevel;
     
    #endregion

    #region Properties

    private int _levelIndex
    {
        get => PlayerPrefs.GetInt("levelIndex");
        set
        {
            PlayerPrefs.SetInt("levelIndex",_levelIndex);
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
            currentLevel=Instantiate(levelPrefabs[_levelIndex], Vector3.zero, Quaternion.identity);
        }
        else
        {
            currentLevel=Instantiate(levelPrefabs[_levelIndex], Vector3.zero, Quaternion.identity);
        }
        
        GameManager.Instance.UpdateGameState(GameStates.Idle);
        UIManager.Instance.SetLevelText(_levelIndex);
    }

    public void LoadNextLevel()
    {
        if (_levelIndex < levelPrefabs.Count - 1)
        {
            _levelIndex++;
        }
        else
        {
            _levelIndex = 0;
        }
         
        Destroy(currentLevel);
        currentLevel=Instantiate(levelPrefabs[_levelIndex], Vector3.zero, Quaternion.identity);
        
        GameManager.Instance.UpdateGameState(GameStates.Idle);
        UIManager.Instance.SetLevelText(_levelIndex);
    }

    #endregion

}

}
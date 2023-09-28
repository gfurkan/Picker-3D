using System;

namespace Managers
{  
public class GameManager : SingletonManager<GameManager>
{
    #region Fields

    public static event Action<GameStates> OnGameStateChanged;
    private GameStates _currentGameState;
    
    #endregion

    #region Unity Methods

    private void OnEnable()
    {
        InputManager.OnClicked += EnableRunningState;
    }

    private void OnDisable()
    {
        InputManager.OnClicked -= EnableRunningState;
    }

    void Awake()
    {
        UpdateGameState(GameStates.Idle);
    }

    #endregion

    #region Private Methods

    void EnableRunningState()
    {
        if (_currentGameState is GameStates.Idle)
        {
            UpdateGameState(GameStates.Running);
        }
    }

    #endregion
    
    #region Public Methods

    public void UpdateGameState(GameStates state)
    {
        if (state != _currentGameState)
        {
            switch (state)
            {
                case GameStates.Idle:
                    
                    UIManager.Instance.ControlFailPanel(false);
                    UIManager.Instance.ControlSuccessPanel(false);
                    UIManager.Instance.ControlStartPanel(true);
                    
                    break;
                
                case GameStates.Running:
                    
                    UIManager.Instance.ControlStartPanel(false);
                    break;
                
                case GameStates.Fail:
                    
                    UIManager.Instance.ControlFailPanel(true);
                    break;
                
                case GameStates.Success:
                    
                    UIManager.Instance.ControlSuccessPanel(true);
                    break;
                
                case GameStates.Endgame:
                    
                    break;
            }

            _currentGameState = state;
            OnGameStateChanged?.Invoke(_currentGameState);
        }
    }
    
    #endregion
}
public enum GameStates
{
    Idle,Running,Obstacle,Endgame,Success,Fail
}
}
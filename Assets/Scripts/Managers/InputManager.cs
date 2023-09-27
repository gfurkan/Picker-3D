using System;
using UnityEngine;

namespace Managers
{  
public class InputManager : SingletonManager<InputManager>
{
    #region Fields

    public static event Action OnClicked;
    [SerializeField] private float swerveSensitivity = 0;
     
    private Vector3 mouseFirstPosition, _directionVector, mouseNextPosition;
    
    #endregion

    #region Properties

    public Vector3 directionVector => _directionVector;
    
    #endregion

    #region Unity Methods

    void Update()
    {
        CheckClick();
        SetInputs();
    }

    #endregion

    #region Private Methods

    void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnClicked?.Invoke();
        }
    }
    
    #endregion

    #region Public Methods

    void SetInputs()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseFirstPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            mouseNextPosition = Input.mousePosition;
            _directionVector = Camera.main.ScreenToViewportPoint(mouseNextPosition - mouseFirstPosition)*swerveSensitivity;
            
            mouseFirstPosition = mouseNextPosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _directionVector=Vector3.zero;
            mouseNextPosition = Vector3.zero;
            mouseFirstPosition = Vector3.zero;
        }
    }

    
    #endregion
}
}
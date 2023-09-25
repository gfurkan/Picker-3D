using System;
using UnityEngine;

namespace Managers
{  
public class InputManager : SingletonManager<InputManager>
{
    #region Fields

    public static event Action OnClicked;
    
    [SerializeField] private float sensivity = 100f, _x_Clamp=0;

    private float firstValue, currentValue, screenWidth, lastSumValue;

    private Vector3 touchPos;
    private bool handsUp, swipeDisable;
    
    #endregion

    #region Properties

    public float sumValue { get; private set; }
    
    #endregion

    #region Unity Methods

    void Update()
    {
        CheckClick();
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

    void CalculateSwerveValue()
    {
        if (swipeDisable)
        {
            return;
        }
            if (Input.GetMouseButton(0))
            {
                if (handsUp)
                {
                    firstValue = Input.mousePosition.x;
                    handsUp = false;
                }

                currentValue = Input.mousePosition.x;

                sumValue = currentValue - firstValue;
                sumValue /= screenWidth;
                sumValue *= sensivity;
                sumValue += lastSumValue;
            }
            else
            {
                lastSumValue = sumValue;
                handsUp = true;
            }

            if (sumValue > _x_Clamp)
            {
                sumValue = _x_Clamp;
                lastSumValue = _x_Clamp;
                handsUp = true;
            }
            else if (sumValue < -_x_Clamp)
            {
                sumValue = -_x_Clamp;
                lastSumValue = -_x_Clamp;
                handsUp = true;
            }
    }
    
    #endregion
}
}
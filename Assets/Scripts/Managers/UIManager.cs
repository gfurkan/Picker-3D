using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Managers
{  
public class UIManager : SingletonManager<UIManager>
{
    #region Fields

    [SerializeField] private Transform _failPanel, _successPanel;
    [SerializeField] private TextMeshProUGUI _levelText;
    
    #endregion

    #region Properties
    


    #endregion

    #region Unity Methods

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    #endregion

    #region Private Methods


    
    #endregion

    #region Public Methods

    public void ControlFailPanel(bool val)
    {
        if (val)
        {
            _failPanel.transform.DOScale(1, 0.25f);
        }
        else
        {
            _failPanel.transform.DOScale(0, 0.25f);
        }
    }
    
    public void ControlSuccessPanel(bool val)
    {
        if (val)
        {
            _successPanel.transform.DOScale(1, 0.25f);
        }
        else
        {
            _successPanel.transform.DOScale(0, 0.25f);
        }
    }

    public void SetLevelText(int levelIndex)
    {
        _levelText.text = "LEVEL " + (levelIndex + 1);
    }
    #endregion
}
}
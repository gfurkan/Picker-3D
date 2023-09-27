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

    #region Public Methods

    public void ControlFailPanel(bool val)
    {
        if (val)
        {
            _failPanel.transform.DOScale(1, 0.25f);
        }
        else
        {
            _failPanel.transform.DOScale(0, 0);
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
            _successPanel.transform.DOScale(0, 0);
        }
    }

    public void SetLevelText(int levelIndex)
    {
        _levelText.text = "LEVEL " + (levelIndex + 1);
    }
    #endregion
}
}
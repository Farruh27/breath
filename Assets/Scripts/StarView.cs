using System;
using UnityEngine;
using UnityEngine.UI;

public class StarView : MonoBehaviour, IDisposable
{
    [SerializeField] 
    private Button _button;
    
    [SerializeField] 
    private Image _selectedImage;
    
    [SerializeField] 
    private Image _notSelectedImage;

    private bool _isSelected;

    public Action<StarView> OnClickStar;

    public bool IsSelect => _isSelected;

    public void Init()
    {
        Dispose();
        _button.onClick.AddListener(ClickStar);
        ResetState();
    }

    public void Dispose()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void ResetState()
    {
        _isSelected = false;
        RefreshState();
    }

    public void SelectStar()
    {
        _isSelected = true;
        RefreshState();
    }
    
    private void ClickStar()
    {
        OnClickStar?.Invoke(this);
    }
    
    private void RefreshState()
    {
        _selectedImage.gameObject.SetActive(_isSelected);
        _notSelectedImage.gameObject.SetActive(!_isSelected);
    }
}

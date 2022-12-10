using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotIntensivityView : MonoBehaviour
{
    [SerializeField] 
    private IntensityType _intensityType;

    [SerializeField] 
    private TMP_Text _nameTypeLabel;
    
    [SerializeField] 
    private Image _imageNotSelected;

    [SerializeField] 
    private Image _imageSelected;

    [SerializeField] 
    private Color _colorSelected;
    
    [SerializeField] 
    private Color _colorNotSelected;

    [SerializeField]
    private Button _button;

    public IntensityType IntensityType => _intensityType;

    public Action<IntensityType> OnClickSlot;

    public void Init()
    {
        _button.onClick.AddListener(ClickSlot);
    }

    public void RefreshState(bool isSelected)
    {
        _imageSelected.gameObject.SetActive(isSelected);
        _imageNotSelected.gameObject.SetActive(!isSelected);

        _nameTypeLabel.color = isSelected ? _colorSelected : _colorNotSelected;
    }

    private void ClickSlot()
    {
        OnClickSlot?.Invoke(_intensityType);
    }
}

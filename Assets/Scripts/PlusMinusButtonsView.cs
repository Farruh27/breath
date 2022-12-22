using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlusMinusButtonsView : MonoBehaviour, IDisposable
{
    [SerializeField] 
    private Button _minusButton;
    
    [SerializeField] 
    private Button _plusButton;
    
    [SerializeField] 
    private TMP_Text _labelNumber;

    private int _minBorder;
    private int _maxBorder;
    private int _selectedCountLoop;

    public Action<int> OnChangeCount;
    
    public void Init(int minBorder, int maxBorder)
    {
        _minBorder = minBorder;
        _maxBorder = maxBorder;

        _selectedCountLoop = maxBorder / 20;
        
       _plusButton.onClick.AddListener(AddCounter);
       _minusButton.onClick.AddListener(MinusCounter);

       OnChangeCount?.Invoke(_selectedCountLoop);
       RefreshText();
    }

    public void Dispose()
    {
        _plusButton.onClick.RemoveAllListeners();
        _minusButton.onClick.RemoveAllListeners();
    }

    private void MinusCounter()
    {
        var newCountLoop = _selectedCountLoop - 1;
        _selectedCountLoop = Mathf.Clamp(newCountLoop, _minBorder, _maxBorder);
        OnChangeCount?.Invoke(_selectedCountLoop);
        RefreshText();
    }

    private void AddCounter()
    {
        var newCountLoop = _selectedCountLoop + 1;
        _selectedCountLoop = Mathf.Clamp(newCountLoop, _minBorder, _maxBorder);
        OnChangeCount?.Invoke(_selectedCountLoop);
        RefreshText();
    }

    private void RefreshText()
    {
        _labelNumber.text = _selectedCountLoop.ToString();
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsPracticeWindow : Window
{
    [SerializeField] 
    private TMP_Text _namePracticeLabel;
    
    [SerializeField] 
    private Image _iconPractice;
    
    [SerializeField] 
    private Button _startPracticeButton;
    
    [SerializeField] 
    private Button _closeWinodwButton;

    [SerializeField] 
    private IntensityButtonsView _intensityButtonsView;
    
    private PracticeInfoData _data;
    private int _intensityDuration;

    public Action OnCloseWindow;
    private Sequence _sequence;

    public void Init(PracticeInfoData practiceInfoData)
    {
        Dispose();
        _data = practiceInfoData;
        
        _intensityButtonsView.OnClickSlot += RefreshTimeIntensity;
        _intensityButtonsView.Init();
        
        SubscriptionButtons();
        RefreshUi();
    }

    private void SubscriptionButtons()
    {
        _closeWinodwButton.onClick.AddListener(CloseWindow);
    }

    private void CloseWindow()
    {
        Dispose();
        OnCloseWindow?.Invoke();
    }

    public override void Dispose()
    {
        _startPracticeButton.onClick.RemoveAllListeners();
        _closeWinodwButton.onClick.RemoveAllListeners();
        _intensityButtonsView.Dispose();
        _intensityButtonsView.OnClickSlot -= RefreshTimeIntensity;
    }

    private void RefreshUi()
    {
        _namePracticeLabel.text = _data.NamePractice;
        _iconPractice.sprite = _data.IconPractice;
    }

    private void RefreshAnimation()
    {
        var middleDuration = _intensityDuration / 2;
        
        _iconPractice.transform.localScale = Vector3.one;
        
        _sequence = DOTween.Sequence();
        _sequence.Append(_iconPractice.transform.DOScale(new Vector3(0.3f, 0.3f, 1), middleDuration));
        _sequence.Append(_iconPractice.transform.DOScale(new Vector3(1f, 1f, 1), middleDuration));
        _sequence.SetLoops(-1);
        _sequence.Restart();
    }

    private void RefreshTimeIntensity(IntensityType intensityType)
    {
        switch (intensityType)
        {
            case IntensityType.Slowly:
                _intensityDuration = _data.SlowlyDuration;
                break;
            case IntensityType.Normal:
                _intensityDuration = _data.NormalDuration;
                break;
            case IntensityType.Quickly:
                _intensityDuration = _data.QuicklyDuration;
                break;
        }
        
        RefreshAnimation();
    }
}

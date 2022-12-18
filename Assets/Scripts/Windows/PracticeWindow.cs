using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PracticeWindow : Window
{
    [SerializeField] 
    private TMP_Text _namePracticeLabel;
    
    [SerializeField] 
    private Transform _transformIcon;

    [SerializeField] 
    private Timer _timer;
    
    [SerializeField] 
    private Button _delayButton;
    
    [SerializeField] 
    private Button _closeButton;
    
    [SerializeField] 
    private Button _continuePracticeButton;
    
    [SerializeField] 
    private Button _settingsButton;

    private PracticeInfoData _practiceInfoData;
    private Sequence _sequence;
    
    public Action<PracticeInfoData> OnCloseWindow;
    public Action<PracticeInfoData> OnEndTime;

    public void Init(PracticeInfoData practiceInfoData, IntensityData intensityData, int timePractice)
    {
        Dispose();
        
        _practiceInfoData = practiceInfoData;
        
        _timer.Init(timePractice);
        _timer.OnEndTime += EndTime;
        
        SubscriptionButtons();
        RefreshUi(practiceInfoData);
        RefreshAnimation(intensityData);
    }

    private void EndTime()
    {
        OnEndTime?.Invoke(_practiceInfoData);
    }

    private void RefreshUi(PracticeInfoData practiceInfoData)
    {
        _namePracticeLabel.text = practiceInfoData.NamePractice;
    }

    private void RefreshAnimation(IntensityData data)
    {
        _transformIcon.localScale = Vector3.one * 0.7f;
        
        _sequence = DOTween.Sequence();
        _sequence.Append(_transformIcon.DOScale(Vector3.one, data.IntensityDurationInhale));
        _sequence.Append(_transformIcon.DOScale(Vector3.one, data.IntensityDelayInhale));
        _sequence.Append(_transformIcon.DOScale(Vector3.one * 0.7f, data.IntensityDurationExhale));
        _sequence.Append(_transformIcon.DOScale(Vector3.one * 0.7f, data.IntensityDelayExhale));
        
        _sequence.SetLoops(-1);
        _sequence.Restart();
    }

    private void SubscriptionButtons()
    {
        _closeButton.onClick.AddListener(CloseWindow);
        _settingsButton.onClick.AddListener(CloseWindow);
    }

    public override void Dispose()
    {
        _closeButton.onClick.RemoveAllListeners();
        _settingsButton.onClick.RemoveAllListeners();
        
        _timer.OnEndTime -= EndTime;
    }

    private void CloseWindow()
    {
        Dispose();
        OnCloseWindow?.Invoke(_practiceInfoData);
    }
}

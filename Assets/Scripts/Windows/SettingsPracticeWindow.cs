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
    private Transform _transformIcon;
    
    [SerializeField] 
    private Button _startPracticeButton;
    
    [SerializeField] 
    private Button _closeWinodwButton;

    [SerializeField] 
    private IntensityButtonsView _intensityButtonsView;

    [SerializeField] 
    private TimeScroller _timeScroller;

    private PracticeInfoData _data;
    
    private float _intensityDurationInhale;
    private float _intensityDelayInhale;
    private float _intensityDurationExhale;
    private float _intensityDelayExhale;

    private int _timePractice;

    public Action<PracticeInfoData, IntensityData, int> OnStartPractice;
    public Action OnCloseWindow;
    
    private Sequence _sequence;

    public void Init(PracticeInfoData data)
    {
        Dispose();
        _data = data;
        
        _intensityButtonsView.OnClickSlot += RefreshTimeIntensity;
        _intensityButtonsView.Init();
        
        _timeScroller.OnSelectedTime += SelectedTime;
        _timeScroller.Init(data.MinTimePractice, data.MaxTimePractice);
        
        SubscriptionButtons();
        RefreshUi();
    }

    private void SelectedTime(int time)
    {
        _timePractice = time;
    }

    private void SubscriptionButtons()
    {
        _startPracticeButton.onClick.AddListener(StartPractice);
        _closeWinodwButton.onClick.AddListener(CloseWindow);
    }

    private void StartPractice()
    {
        var intensityData = new IntensityData(_data.StartScaleLungs, _intensityDurationInhale, _intensityDelayInhale, 
            _intensityDurationExhale, _intensityDelayExhale);
        OnStartPractice?.Invoke(_data, intensityData, _timePractice);
        Dispose();
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
        
        _intensityButtonsView.OnClickSlot -= RefreshTimeIntensity;
        _intensityButtonsView.Dispose();
        
        _timeScroller.OnSelectedTime -= SelectedTime;
        _timeScroller.Dispose();
    }

    private void RefreshUi()
    {
        _namePracticeLabel.text = _data.NamePractice;
    }

    private void RefreshAnimation()
    {
        _transformIcon.localScale = Vector3.one * _data.StartScaleLungs;
        
        _sequence?.Kill();
        
        _sequence = TweenAnimationUtils.GetSequenceAnimationLungs(_transformIcon, _data.StartScaleLungs,
            _intensityDurationInhale,
            _intensityDelayInhale, _intensityDurationExhale, _intensityDelayExhale);
        
        _sequence.Restart();
    }

    private void RefreshTimeIntensity(IntensityType intensityType)
    {
        switch (intensityType)
        {
            case IntensityType.Slowly:
                _intensityDurationInhale = _data.SlowlyDurationInhale;
                _intensityDelayInhale = _data.SlowlyDelayInhale;
                _intensityDurationExhale = _data.SlowlyDurationExhale;
                _intensityDelayExhale = _data.SlowlyDelayExhale;
                break;
            
            case IntensityType.Normal:
                _intensityDurationInhale = _data.NormalDurationInhale;
                _intensityDelayInhale = _data.NormalDelayInhale;
                _intensityDurationExhale = _data.NormalDurationExhale;
                _intensityDelayExhale = _data.NormalDelayExhale;
                break;
            
            case IntensityType.Quickly:
                _intensityDurationInhale = _data.QuicklyDurationInhale;
                _intensityDelayInhale = _data.QuicklyDelayInhale;
                _intensityDurationExhale = _data.QuicklyDurationExhale;
                _intensityDelayExhale = _data.QuicklyDelayExhale;
                break;
        }
        
        RefreshAnimation();
    }
}

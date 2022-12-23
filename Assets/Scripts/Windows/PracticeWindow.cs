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
    private TMP_Text _numberLoopLabel;
    
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
    
    [SerializeField] 
    private GameObject _containerTimer;
    
    [SerializeField] 
    private GameObject _containerNumber;

    private int _currentCountLoop;
    private int _timePractice;
    
    private PracticeInfoData _practiceInfoData;
    private Sequence _sequence;
    
    public Action<PracticeInfoData> OnCloseWindow;
    public Action<PracticeInfoData> OnEndTime;
    private bool _playSquareBreathingPractice;

    public void Init(PracticeInfoData practiceInfoData, IntensityData intensityData, int timePractice)
    {
        Dispose();
        
        _practiceInfoData = practiceInfoData;
        _timePractice = timePractice;

        SubscriptionButtons();
        ChangeStateUi(practiceInfoData, intensityData, timePractice);
        RefreshUi(practiceInfoData);
    }

    private void ChangeStateUi(PracticeInfoData practiceInfoData, IntensityData intensityData, int timePractice)
    {
        switch (practiceInfoData.PracticeType)
        {
            case PracticeType.Antistress:
                AntistressState(intensityData, timePractice);
                break;
            
            case PracticeType.SquareBreathing:
                SquareBreathingState(intensityData, timePractice);
                break;
            
            case PracticeType.Wimhoff:
                break;
            
            case PracticeType.Buteyko:
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }   
    }

    private void AntistressState(IntensityData intensityData, int timePractice)
    {
        _containerTimer.SetActive(true);
        _containerNumber.SetActive(false);
        
        _timer.Init(timePractice);
        _timer.OnEndTime += EndTime;
        
        RefreshAnimation(intensityData);
    }
    
    private void SquareBreathingState(IntensityData intensityData, int timePractice)
    {
        _containerTimer.SetActive(false);
        _containerNumber.SetActive(true);

        _numberLoopLabel.text = timePractice.ToString();
        
        RefreshAnimation(intensityData, timePractice);
        _sequence.onComplete += EndSquareBreathingPractice;
        _playSquareBreathingPractice = true;
    }

    private void EndSquareBreathingPractice()
    {
        _playSquareBreathingPractice = false;
        EndTime();
    }

    private void Update()
    {
        if (!_playSquareBreathingPractice || _sequence == null || !_sequence.IsPlaying())
            return;
        
        var completedLoops = _sequence.CompletedLoops();
        
        if (_currentCountLoop == completedLoops)
            return;
        
        _currentCountLoop = completedLoops;
        var remainingCountLoops = _timePractice - _currentCountLoop;
        _numberLoopLabel.text = remainingCountLoops.ToString();
    }

    private void EndTime()
    {
        OnEndTime?.Invoke(_practiceInfoData);
    }

    private void RefreshUi(PracticeInfoData practiceInfoData)
    {
        _namePracticeLabel.text = practiceInfoData.NamePractice;
    }

    private void RefreshAnimation(IntensityData data, int countLoop = -1)
    {
        _transformIcon.localScale = Vector3.one * data.StartScaleLungs;
        
        _sequence?.Kill();
        _sequence = TweenAnimationUtils.GetSequenceAnimationLungs(_transformIcon, data, countLoop);
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

        _playSquareBreathingPractice = false;
    }

    private void CloseWindow()
    {
        Dispose();
        OnCloseWindow?.Invoke(_practiceInfoData);
    }
}

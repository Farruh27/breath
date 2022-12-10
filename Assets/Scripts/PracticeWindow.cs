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
    private Image _iconPractice;

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

    public void Init(PracticeInfoData practiceInfoData, int intensityDuration)
    {
        Dispose();
        
        _practiceInfoData = practiceInfoData;
        
        _timer.Init(practiceInfoData.MaxTimePractice);
        
        SubscriptionButtons();
        RefreshUi(practiceInfoData);
        RefreshAnimation(intensityDuration);
    }

    private void RefreshUi(PracticeInfoData practiceInfoData)
    {
        _namePracticeLabel.text = practiceInfoData.NamePractice;
        _iconPractice.sprite = practiceInfoData.IconPractice;
    }

    private void RefreshAnimation(int intensityDuration)
    {
        var middleDuration = intensityDuration / 2;
        
        _iconPractice.transform.localScale = Vector3.one;
        
        _sequence = DOTween.Sequence();
        _sequence.Append(_iconPractice.transform.DOScale(new Vector3(0.3f, 0.3f, 1), middleDuration));
        _sequence.Append(_iconPractice.transform.DOScale(new Vector3(1f, 1f, 1), middleDuration));
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
    }

    private void CloseWindow()
    {
        Dispose();
        OnCloseWindow?.Invoke(_practiceInfoData);
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class RatingWindow : Window
{
    [SerializeField] 
    private Button _closeButton;
    
    [SerializeField] 
    private StarsListView _starsListView;
    
    public Action OnCloseWindow;
    private PracticeInfoData _practiceInfoData;

    public void Init(PracticeInfoData practiceInfoData)
    {
        Dispose();

        _practiceInfoData = practiceInfoData;
        _starsListView.Init();
        SubscriptionButtons();
    }
    
    private void SubscriptionButtons()
    {
        _closeButton.onClick.AddListener(CloseWindow);
    }
    
    public override void Dispose()
    {
        _closeButton.onClick.RemoveAllListeners();
    }

    private void CloseWindow()
    {
        Dispose();
        _starsListView.Dispose();
        
        PlayerPrefs.SetInt($"{_practiceInfoData.Code}_{Const.StarKey}", _starsListView.IndexSelectStar);
        OnCloseWindow?.Invoke();
    }
}

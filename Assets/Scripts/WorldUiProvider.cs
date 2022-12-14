using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldUiProvider : MonoBehaviour
{
    [SerializeField] 
    private List<WindowData> _windows;
    
    [SerializeField] 
    private PracticesPreset _practicesPreset;

    private ChoosingPracticeWindow _choosingPracticeWindow;
    private SettingsPracticeWindow _settingsPracticeWindow;
    private PracticeWindow _practiceWindow;
    private RatingWindow _ratingWindow;
    
    private void Start()
    {
        FindWindows();
        SubscribesWindows();
        OpenChoosingPracticeWindow();
    }

    private void OnDestroy()
    {
        UnSubscribesWindows();
    }

    private void SubscribesWindows()
    {
        _choosingPracticeWindow.OnOpenSettingsPractice += OpenSettingsPractice;
        
        _settingsPracticeWindow.OnStartPractice += OpenPracticeWindow;
        _settingsPracticeWindow.OnCloseWindow += OpenChoosingPracticeWindow;
        
        _practiceWindow.OnCloseWindow += OpenSettingsPractice;
        _practiceWindow.OnEndTime += OpenRatingWindow;
        
        _ratingWindow.OnCloseWindow += OpenChoosingPracticeWindow;
    }

    private void UnSubscribesWindows()
    {
        _choosingPracticeWindow.OnOpenSettingsPractice -= OpenSettingsPractice;
        
        _settingsPracticeWindow.OnStartPractice -= OpenPracticeWindow;
        _settingsPracticeWindow.OnCloseWindow -= OpenChoosingPracticeWindow;
        
        _practiceWindow.OnCloseWindow -= OpenSettingsPractice;
        _practiceWindow.OnEndTime -= OpenRatingWindow;
        
        _ratingWindow.OnCloseWindow -= OpenChoosingPracticeWindow;
    }

    private void OpenChoosingPracticeWindow()
    {
        _choosingPracticeWindow.Init(_practicesPreset);
        ShowWindow(WindowType.ChoosingPractice, true);
        
    }

    private void OpenSettingsPractice(PracticeInfoData practiceInfoData)
    {
        _settingsPracticeWindow.Init(practiceInfoData);
        ShowWindow(WindowType.SettingsPractice, true);
    }
    
    private void OpenPracticeWindow(PracticeInfoData practiceInfoData, IntensityData intensityData, int timePractice)
    {
        _practiceWindow.Init(practiceInfoData, intensityData, timePractice);
        ShowWindow(WindowType.Practice, false);
    }
    
    private void OpenRatingWindow(PracticeInfoData practiceInfoData)
    {
        _ratingWindow.Init(practiceInfoData);
        ShowWindow(WindowType.RatingWindow, true);
    }

    private void FindWindows()
    {
        _choosingPracticeWindow = GetWindow(WindowType.ChoosingPractice) as ChoosingPracticeWindow;
        _settingsPracticeWindow = GetWindow(WindowType.SettingsPractice) as SettingsPracticeWindow;
        _practiceWindow = GetWindow(WindowType.Practice) as PracticeWindow;
        _ratingWindow = GetWindow(WindowType.RatingWindow) as RatingWindow;
    }
    
    private Window GetWindow(WindowType type)
    {
        var windowData = _windows.FirstOrDefault(window => window.WindowType == type);
        return windowData.Window;
    }
    
    private void ShowWindow(WindowType type, bool isShowDownPanel)
    {
        foreach (var window in _windows)
        {
            var isActiveWindow = window.WindowType == type || isShowDownPanel && type == WindowType.DownPanelWindow;
            window.Window.gameObject.SetActive(isActiveWindow);
        }
    }
}
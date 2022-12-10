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
    
    private void Start()
    {
        FindWindows();
        
        _choosingPracticeWindow.Init(_practicesPreset);
        ShowWindow(WindowType.ChoosingPractice, true);
        _choosingPracticeWindow.OnOpenSettingsPractice += OpenSettingsPractice;
    }

    private void OpenSettingsPractice(PracticeInfoData practiceInfoData)
    {
        _settingsPracticeWindow.Init(practiceInfoData);
        ShowWindow(WindowType.SettingsPractice, true);
    }

    private void FindWindows()
    {
        _choosingPracticeWindow = GetWindow(WindowType.ChoosingPractice) as ChoosingPracticeWindow;
        _settingsPracticeWindow = GetWindow(WindowType.SettingsPractice) as SettingsPracticeWindow;
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
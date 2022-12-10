using System;
using System.Collections.Generic;
using UnityEngine;

public class ChoosingPracticeWindow : Window
{
    [SerializeField]
    private List<SlotProgramView> _slotProgramViews;

    public Action<PracticeInfoData> OnOpenSettingsPractice;
    
    public void Init(PracticesPreset practicesPreset)
    {
        foreach (var slot in _slotProgramViews)
        {
            slot.Init(practicesPreset);
            slot.OnClickSlot += OpenSettingsPractice;
        }
    }

    private void OnDestroy()
    {
        foreach (var slot in _slotProgramViews)
            slot.OnClickSlot -= OpenSettingsPractice;
    }

    private void OpenSettingsPractice(PracticeInfoData practiceInfoData)
    {
        OnOpenSettingsPractice?.Invoke(practiceInfoData);
    }
}

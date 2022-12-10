using System;
using System.Collections.Generic;
using UnityEngine;

public class IntensityButtonsView : MonoBehaviour, IDisposable
{
    [SerializeField] 
    private List<SlotIntensivityView> _slots;

    public Action<IntensityType> OnClickSlot;
    
    public void Init()
    {
        InitSlots();
        RefreshSlots(IntensityType.Normal);
    }

    public void Dispose()
    {
        foreach (var slot in _slots)
            slot.OnClickSlot -= RefreshSlots;
    }

    private void InitSlots()
    {
        foreach (var slot in _slots)
        {
            slot.Init();
            slot.OnClickSlot += RefreshSlots;
        }
    }

    private void RefreshSlots(IntensityType intensityType)
    {
        foreach (var slot in _slots)
            slot.RefreshState(slot.IntensityType == intensityType);
        
        OnClickSlot?.Invoke(intensityType);
    }
}

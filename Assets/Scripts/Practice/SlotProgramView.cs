using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotProgramView : MonoBehaviour
{
    [SerializeField] 
    private PracticeType _practiceType;

    [SerializeField] 
    private Button _button;
    
    [SerializeField] 
    private Image _imagePractice;
    
    [SerializeField] 
    private TMP_Text _namePracticeLabel;
    
    [SerializeField] 
    private StarsListSlotView _starsListSlotView;

    public Action<PracticeInfoData> OnClickSlot;

    private PracticeInfoData _practiceData;

    public void Init(PracticesPreset practicesPreset)
    {
        RefreshSlot(practicesPreset);
        
        _starsListSlotView.Init(_practiceData);
        _button.onClick.AddListener(SubscribeButton);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void SubscribeButton()
    {
        OnClickSlot?.Invoke(_practiceData);
    }

    private void RefreshSlot(PracticesPreset practicesPreset)
    {
        _practiceData = PracticeFactory.GetPracticeData(_practiceType, practicesPreset);

        _imagePractice.sprite = _practiceData.IconPractice;
        _namePracticeLabel.text = _practiceData.NamePractice;
    }
}

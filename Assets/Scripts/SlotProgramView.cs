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

    public Action<PracticeInfoData> OnClickSlot;

    private PracticeInfoData _practiceData;

    public void Init(PracticesPreset practicesPreset)
    {
        RefreshSlot(practicesPreset);
        
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
        _practiceData = GetPracticeData(practicesPreset);

        _imagePractice.sprite = _practiceData.IconPractice;
        _namePracticeLabel.text = _practiceData.NamePractice;
    }

    private PracticeInfoData GetPracticeData(PracticesPreset practicesPreset)
    {
        switch (_practiceType)
        {
            case PracticeType.Antistress:
                var antistressData = practicesPreset.AntistressData;
                var practiceData = new PracticeInfoData(antistressData.NamePractice, antistressData.IconPractice, antistressData.MinTimePractice,
                    antistressData.MaxTimePractice, antistressData.SlowlyDuration, antistressData.NormalDuration, antistressData.QuicklyDuration);
                return practiceData;
            case PracticeType.SquareBreathing:
                return default;
            case PracticeType.Wimhoff:
                return default;
            case PracticeType.Buteyko:
                return default;
            default:
                return default;
        }
    }
}

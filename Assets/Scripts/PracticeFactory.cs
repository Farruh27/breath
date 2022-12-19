public static class PracticeFactory
{
    public static PracticeInfoData GetPracticeData(PracticeType practiceType, PracticesPreset practicesPreset)
    {
        switch (practiceType)
        {
            case PracticeType.Antistress:
                var data = practicesPreset.AntistressData;
                var practiceData = new PracticeInfoData(data.Code, data.NamePractice, data.IconPractice, data.MinTimePractice,
                    data.MaxTimePractice, data.StartScaleLungs, data.SlowlyDurationInhale, data.NormalDurationInhale, data.QuicklyDurationInhale, data.SlowlyDelayInhale,
                    data.SlowlyDurationExhale, data.SlowlyDelayExhale, data.NormalDelayInhale, data.NormalDurationExhale, data.NormalDelayExhale, data.QuicklyDelayInhale,
                    data.QuicklyDurationExhale, data.QuicklyDelayExhale);
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

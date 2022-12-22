using System;

public static class PracticeFactory
{
    public static PracticeInfoData GetPracticeData(PracticeType practiceType, PracticesPreset practicesPreset)
    {
        switch (practiceType)
        {
            case PracticeType.Antistress:
                return GetAntistressData(practicesPreset.AntistressData);
            
            case PracticeType.SquareBreathing:
                return GetSquareBreathingData(practicesPreset.SquareBreathingData);
            
            case PracticeType.Wimhoff:
                return default;
            
            case PracticeType.Buteyko:
                return default;
            
            default:
                return default;
        }
    }

    private static PracticeInfoData GetAntistressData(AntistressData antistressData)
    {
        var data = antistressData;
        var practiceData = new PracticeInfoData(data.PracticeType, data.Code, data.NamePractice, data.IconPractice, data.MinTimePractice,
            data.MaxTimePractice, data.StepTimePractice, data.StartScaleLungs, data.SlowlyDurationInhale, data.NormalDurationInhale, data.QuicklyDurationInhale, data.SlowlyDelayInhale,
            data.SlowlyDurationExhale, data.SlowlyDelayExhale, data.NormalDelayInhale, data.NormalDurationExhale, data.NormalDelayExhale, data.QuicklyDelayInhale,
            data.QuicklyDurationExhale, data.QuicklyDelayExhale);
        
        return practiceData;
    }
    
    private static PracticeInfoData GetSquareBreathingData(SquareBreathingData squareBreathingData)
    {
        var data = squareBreathingData;
        var practiceData = new PracticeInfoData(data.PracticeType, data.Code, data.NamePractice, data.IconPractice, data.MinTimePractice, data.MaxTimePractice,
            data.StepTimePractice, data.StartScaleLungs, data.MinTimeIntensityBreath, data.MaxTimeIntensityBreath);
        
        return practiceData;
    }
}

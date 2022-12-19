using UnityEngine;

public readonly struct PracticeInfoData
{
    public string Code { get; }
    public string NamePractice { get; }
    
    public Sprite IconPractice { get; }
    
    public int MinTimePractice { get; }
    public int MaxTimePractice { get; }
    
    public float StartScaleLungs { get; }

    public float SlowlyDurationInhale { get; }
    public float SlowlyDelayInhale  { get; }
    public float SlowlyDurationExhale { get; }
    public float SlowlyDelayExhale { get; }
    
    public float NormalDurationInhale { get; }
    public float NormalDelayInhale { get; }
    public float NormalDurationExhale { get; }
    public float NormalDelayExhale { get; }
    
    public float QuicklyDurationInhale { get; }
    public float QuicklyDelayInhale { get; }
    public float QuicklyDurationExhale { get; }
    public float QuicklyDelayExhale { get; }
    

    public PracticeInfoData(string code, string namePractice, Sprite iconPractice, int minTimePractice, 
        int maxTimePractice, float startScaleLungs, float slowlyDurationInhale, float normalDurationInhale, float quicklyDurationInhale, 
        float slowlyDelayInhale, float slowlyDurationExhale, float slowlyDelayExhale, float normalDelayInhale, 
        float normalDurationExhale, float normalDelayExhale, float quicklyDelayInhale, float quicklyDurationExhale, 
        float quicklyDelayExhale)
    {
        Code = code;
        NamePractice = namePractice;
        IconPractice = iconPractice;
        MinTimePractice = minTimePractice;
        MaxTimePractice = maxTimePractice;
        StartScaleLungs = startScaleLungs;
        SlowlyDurationInhale = slowlyDurationInhale;
        NormalDurationInhale = normalDurationInhale;
        QuicklyDurationInhale = quicklyDurationInhale;
        SlowlyDelayInhale = slowlyDelayInhale;
        SlowlyDurationExhale = slowlyDurationExhale;
        SlowlyDelayExhale = slowlyDelayExhale;
        NormalDelayInhale = normalDelayInhale;
        NormalDurationExhale = normalDurationExhale;
        NormalDelayExhale = normalDelayExhale;
        QuicklyDelayInhale = quicklyDelayInhale;
        QuicklyDurationExhale = quicklyDurationExhale;
        QuicklyDelayExhale = quicklyDelayExhale;
    }
}

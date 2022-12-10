using UnityEngine;

public readonly struct PracticeInfoData
{
    public string NamePractice { get; }
    
    public Sprite IconPractice { get; }
    
    public int MinTimePractice { get; }
    public int MaxTimePractice { get; }

    public int SlowlyDuration { get; }
    public int NormalDuration { get; }
    public int QuicklyDuration { get; }

    public PracticeInfoData(string namePractice, Sprite iconPractice, int minTimePractice, 
        int maxTimePractice, int slowlyDuration, int normalDuration, int quicklyDuration)
    {
        NamePractice = namePractice;
        IconPractice = iconPractice;
        MinTimePractice = minTimePractice;
        MaxTimePractice = maxTimePractice;
        SlowlyDuration = slowlyDuration;
        NormalDuration = normalDuration;
        QuicklyDuration = quicklyDuration;
    }
}

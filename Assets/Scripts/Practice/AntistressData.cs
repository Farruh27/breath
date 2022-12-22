using System;
using UnityEngine;

[Serializable]
public struct AntistressData
{
    public string Code;
    public string NamePractice;

    public PracticeType PracticeType;
    
    public Sprite IconPractice;
    
    public int MinTimePractice;
    public int MaxTimePractice;
    public int StepTimePractice;

    public float StartScaleLungs;
    
    public float SlowlyDurationInhale;
    public float SlowlyDelayInhale;
    public float SlowlyDurationExhale;
    public float SlowlyDelayExhale;
    
    public float NormalDurationInhale;
    public float NormalDelayInhale;
    public float NormalDurationExhale;
    public float NormalDelayExhale;
    
    public float QuicklyDurationInhale;
    public float QuicklyDelayInhale;
    public float QuicklyDurationExhale;
    public float QuicklyDelayExhale;
}
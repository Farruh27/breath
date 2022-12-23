using System;
using UnityEngine;

[Serializable]
public struct SquareBreathingData
{
    public string Code;
    public string NamePractice;
    
    public PracticeType PracticeType;
    
    public Sprite IconPractice;
    
    public int MinTimePractice;
    public int MaxTimePractice;
    public int StepTimePractice;

    public float StartScaleLungs;
    
    public int MinTimeIntensityBreath;
    public int MaxTimeIntensityBreath;

    public int MinNumberOfApproaches;
    public int MaxNumberOfApproaches;
}

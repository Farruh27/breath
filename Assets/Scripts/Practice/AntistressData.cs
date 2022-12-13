using System;
using UnityEngine;

[Serializable]
public struct AntistressData
{
    public string Code;
    public string NamePractice;
    
    public Sprite IconPractice;
    
    public int MinTimePractice;
    public int MaxTimePractice;

    public int SlowlyDuration;
    public int NormalDuration;
    public int QuicklyDuration;
}
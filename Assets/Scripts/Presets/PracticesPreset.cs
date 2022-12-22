using UnityEngine;

[CreateAssetMenu(fileName = "PracticesPreset", menuName = "ScriptableObjects/PracticesPreset")]
public class PracticesPreset : ScriptableObject
{
    [SerializeField] 
    private AntistressData _antistressData;

    public AntistressData AntistressData => _antistressData;

    [SerializeField] 
    private SquareBreathingData _squareBreathingData;

    public SquareBreathingData SquareBreathingData => _squareBreathingData;
}

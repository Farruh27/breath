using DG.Tweening;
using UnityEngine;

public static class TweenAnimationUtils
{
    public static Sequence GetSequenceAnimationLungs(Transform transformIcon, IntensityData data)
    {
        var sequence = GetSequenceAnimationLungs(transformIcon, data.StartScaleLungs, data.IntensityDurationInhale,
            data.IntensityDelayInhale, data.IntensityDurationExhale, data.IntensityDelayExhale);

        return sequence;
    }
    
    public static Sequence GetSequenceAnimationLungs(Transform transformIcon, float startScaleLungs, float intensityDurationInhale, 
        float intensityDelayInhale, float intensityDurationExhale, float intensityDelayExhale)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transformIcon.DOScale(Vector3.one, intensityDurationInhale));
        sequence.AppendInterval(intensityDelayInhale);
        sequence.Append(transformIcon.DOScale(Vector3.one * startScaleLungs, intensityDurationExhale));
        sequence.AppendInterval(intensityDelayExhale);
        
        sequence.SetLoops(-1);

        return sequence;
    }
}

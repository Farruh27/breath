using DG.Tweening;
using UnityEngine;

public static class TweenAnimationUtils
{
    public static Sequence GetSequenceAnimationLungs(Transform transformIcon, IntensityData data, int countLoop = -1)
    {
        var sequence = GetSequenceAnimationLungs(transformIcon, data.StartScaleLungs, data.IntensityDurationInhale,
            data.IntensityDelayInhale, data.IntensityDurationExhale, data.IntensityDelayExhale, countLoop);

        return sequence;
    }
    
    public static Sequence GetSequenceAnimationLungs(Transform transformIcon, float startScaleLungs, float intensityDurationInhale, 
        float intensityDelayInhale, float intensityDurationExhale, float intensityDelayExhale, int countLoop = -1)
    {
        var sequence = DOTween.Sequence();
        sequence.Append(transformIcon.DOScale(Vector3.one, intensityDurationInhale));
        sequence.AppendInterval(intensityDelayInhale);
        sequence.Append(transformIcon.DOScale(Vector3.one * startScaleLungs, intensityDurationExhale));
        sequence.AppendInterval(intensityDelayExhale);
        
        sequence.SetLoops(countLoop);

        return sequence;
    }
}

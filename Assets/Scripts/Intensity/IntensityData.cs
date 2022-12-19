public struct IntensityData
{
    public float StartScaleLungs { get; }
    
    public float IntensityDurationInhale { get; }

    public float IntensityDelayInhale { get; }

    public float IntensityDurationExhale { get; }

    public float IntensityDelayExhale { get; }
    

    public IntensityData(float startScaleLungs, float intensityDurationInhale, float intensityDelayInhale, float intensityDurationExhale, float intensityDelayExhale)
    {
        StartScaleLungs = startScaleLungs;
        IntensityDurationInhale = intensityDurationInhale;
        IntensityDelayInhale = intensityDelayInhale;
        IntensityDurationExhale = intensityDurationExhale;
        IntensityDelayExhale = intensityDelayExhale;
    }
}

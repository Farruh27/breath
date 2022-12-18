public struct IntensityData
{
    public float IntensityDurationInhale { get; }

    public float IntensityDelayInhale { get; }

    public float IntensityDurationExhale { get; }

    public float IntensityDelayExhale { get; }
    

    public IntensityData(float intensityDurationInhale, float intensityDelayInhale, float intensityDurationExhale, float intensityDelayExhale)
    {
        IntensityDurationInhale = intensityDurationInhale;
        IntensityDelayInhale = intensityDelayInhale;
        IntensityDurationExhale = intensityDurationExhale;
        IntensityDelayExhale = intensityDelayExhale;
    }
}

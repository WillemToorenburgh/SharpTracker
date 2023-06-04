using SharpTracker.TrackerCore.Audio;

namespace SharpTracker.TrackerCore.Instruments;

public class SampleInstrument : ITrackerInstrument
{
    public enum SamplePlaybackStyle
    {
        OneShot,
        Loop
    }
    public int SamplePlaybackStartTimeMilliseconds { get; set; }
    //TODO: This needs to be replaced with a provider that transparently handles different audio file types
    private CachedSound _cachedInstrument;

    private string _sampleFilePath;
    public string SampleFilePath
    {
        get => _sampleFilePath;
        set
        {
            _sampleFilePath = value;
            _cachedInstrument = new CachedSound(_sampleFilePath);
        }
    }

    public SampleInstrument(string sampleFilePath)
    {
        SampleFilePath = sampleFilePath;
        
    }

    public void Play(int note, AudioPlaybackEngine playbackEngine)
    {
        //TODO: add support for pitch and sample start point 
        playbackEngine.PlaySound(_cachedInstrument);
    }

    public void Stop()
    {
        
    }
}
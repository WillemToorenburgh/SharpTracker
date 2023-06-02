using System.IO;
using NAudio.Wave;

namespace SharpTracker.TrackerCore.Instruments;

public class SampleInstrument : BaseInstrument
{
    // maybe replace this with a way to load the sample into memory for rapid playback
    // NAudio may have this feature
    public string SampleFilePath;
    public int SamplePlaybackStartTimeMilliseconds;
    
    //TODO: This needs to be replaced with a provider that transparently handles different audio file types
    private WaveBuffer SampleBuffer;

    public SampleInstrument(string sampleFilePath)
    {
        SampleFilePath = sampleFilePath;
        SampleBuffer = new WaveBuffer();
    }
}
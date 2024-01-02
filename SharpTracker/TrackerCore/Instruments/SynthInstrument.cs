using System;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using SharpTracker.Services.Audio;

namespace SharpTracker.TrackerCore.Instruments;
public class SynthInstrument : ITrackerInstrument
{
    private bool _isPlaying;
    public bool IsPlaying { get => _isPlaying; set => _isPlaying = value; }

    private SignalGenerator signalGenerator = new();
    public void Play(int note, AudioPlaybackEngine playbackEngine)
    {

    }
    public void Stop()
    {
      
    }
}

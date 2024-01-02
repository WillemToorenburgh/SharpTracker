using System;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace SharpTracker.Services.Audio;

// Implementation lovingly stolen from Mark Heath
// https://markheath.net/post/fire-and-forget-audio-playback-with

public class AudioPlaybackEngine : IDisposable
{
    private readonly IWavePlayer _outputDevice;
    private readonly MixingSampleProvider _mixer;

    public AudioPlaybackEngine(int sampleRate = 44100, int channelCount = 2)
    {
        _outputDevice = new WaveOutEvent();
        _mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount))
        {
            ReadFully = true
        };
        _outputDevice.Init(_mixer);
        _outputDevice.Play();
    }

    public void PlaySound(string fileName)
    {
        var input = new AudioFileReader(fileName);
        AddMixerInput(new AutoDisposeFileReader(input));
    }

    public void PlaySound(CachedSound sound)
    {
        AddMixerInput(new CachedSoundSampleProvider(sound));
    }

    private void AddMixerInput(ISampleProvider input)
    {
        _mixer.AddMixerInput(ConvertToRightChannelCount(input));
    }

    private ISampleProvider ConvertToRightChannelCount(ISampleProvider input)
    {
        if (input.WaveFormat.Channels == _mixer.WaveFormat.Channels)
        {
            return input;
        }

        if (input.WaveFormat.Channels == 1 && _mixer.WaveFormat.Channels == 2)
        {
            return new MonoToStereoSampleProvider(input);
        }

        throw new NotImplementedException(
            $"Conversion of {input.WaveFormat.Channels} channels from sample to current player channel count {_mixer.WaveFormat.Channels} is not supported");
    }

    public void Dispose()
    {
        _outputDevice.Dispose();
        //TODO: determine if we need to dispose of 'this' as well as '_outputDevice' as suggested by the warning
        GC.SuppressFinalize(_outputDevice);
    }

    public static readonly AudioPlaybackEngine Instance = new AudioPlaybackEngine(44100, 2);
}
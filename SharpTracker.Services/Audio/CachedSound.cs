using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;

namespace SharpTracker.Services.Audio;

public class CachedSound
{
    public float[] AudioData { get; private set; }
    public WaveFormat CachedSoundWaveFormat { get; private set; }

    public CachedSound(string audioFilePath, int sampleStartPoint = 0)
    {
        using var audioFileReader = new AudioFileReader(audioFilePath);
        //TODO: This is where to add resampling functionality
        CachedSoundWaveFormat = audioFileReader.WaveFormat;
        var wholeFile = new List<float>((int)(audioFileReader.Length / 4));
        var readBuffer = new float[audioFileReader.WaveFormat.SampleRate * audioFileReader.WaveFormat.Channels];
        int samplesRead;
        while ((samplesRead = audioFileReader.Read(readBuffer, sampleStartPoint, readBuffer.Length)) > 0)
        {
            wholeFile.AddRange(readBuffer.Take(samplesRead));
        }

        AudioData = wholeFile.ToArray();
    }
}
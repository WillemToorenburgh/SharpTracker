using NAudio.Wave;

namespace SharpTracker.TrackerCore.Audio;

public class AutoDisposeFileReader : ISampleProvider
{
    private readonly AudioFileReader _reader;
    private bool _isDisposed;

    public AutoDisposeFileReader(AudioFileReader reader)
    {
        _reader = reader;
        this.WaveFormat = reader.WaveFormat;
    }


    public int Read(float[] buffer, int offset, int count)
    {
        if (_isDisposed) return 0;
        var read = _reader.Read(buffer, offset, count);
        if (read == 0)
        {
            _reader.Dispose();
            _isDisposed = true;
        }

        return read;
    }

    public WaveFormat WaveFormat { get; private set; }
}
namespace SharpTracker.TrackerCore.Instruments;

public interface ITrackerInstrument
{

    public bool IsPlaying { get; set; }

    //TODO: might need to replace note's type with an enum or something. NAudio might have something for us there
    public void Play(int note)
    {
    }

    public void Stop()
    {
    }
}
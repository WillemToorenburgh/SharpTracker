using System;
using System.Collections.Generic;

namespace SharpTracker.TrackerCore;

public class Pattern
{
    public string? Name;
    public List<Track> Tracks;
    public int Length = 32;

    //TODO: these next two perhaps become enums, or a reference to another library which has already done the work for me
    //TODO: it also may make more sense to have these exist at the project level and inherit the value of the parent, then allow overrides pattern-by-pattern
    public object? Scale;
    public object? Mode;

    public Pattern(List<Track>? tracks = null)
    {
        Tracks = tracks ?? new List<Track>(GlobalConsts.MaxTrackCount);
        // Always ensure we've got one track.
        if (Tracks.Count == 0) { Tracks.Add(new Track()); }
    }
}
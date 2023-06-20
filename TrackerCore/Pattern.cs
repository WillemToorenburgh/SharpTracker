using System;
using System.Collections.Generic;

namespace SharpTracker.TrackerCore;

public class Pattern
{
    public string? Name;
    public List<Track> Tracks;

    public Pattern(List<Track>? tracks)
    {
        Tracks = tracks ?? new List<Track>();
    }

    private int _length = 32;
    public int Length
    {
        get => _length;
        set => _length = Math.Clamp(value, 1, GlobalConsts.MaxPatternLength);
    }

    //TODO: these next two perhaps become enums, or a reference to another library which has already done the work for me
    public object? Scale { get; set;}
    public object? Mode { get; set;}
}
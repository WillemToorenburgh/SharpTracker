using System;
using System.Collections.Generic;

namespace SharpTracker.TrackerCore;

public class Pattern
{
    public string Name;
    public List<Track> Tracks;

    private int _length = 32;
    public int Length
    {
        get => _length;
        set => _length = Math.Clamp(value, 1, GlobalConsts.MaxPatternLength);
    }
}
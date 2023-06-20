using System;
using System.Collections.Generic;

namespace SharpTracker.TrackerCore;

public class Track
{
    // ### objects and values required from parent
    // placeholder for an object which will be passed to Steps to let them play their audio
    //TODO: determine if there should be one audio out provider for the whole program, or one per track
    public object AudioOutProvider;
    
    // ### child objects
    public List<Step> TrackSteps;
    
    // ### volume properties
    public bool IsMuted = false;

    private int _trackVolume = 100;
    public int TrackVolume
    {
        get => _trackVolume;
        set => _trackVolume = Math.Clamp(value, 0, GlobalConsts.MaxVolume);
    }

    //TODO: these next two perhaps become enums, or a reference to another library which has already done the work for me
    public object? Scale { get; set;}
    public object? Mode { get; set;}

    public Track(object audioOutProvider, List<Step>? trackCells)
    {
        TrackSteps = trackCells ?? new List<Step>(GlobalConsts.MaxPatternLength);
        AudioOutProvider = audioOutProvider;
    }
}
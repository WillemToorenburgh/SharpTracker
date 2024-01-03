using System;
using System.Collections.Generic;

namespace SharpTracker.TrackerCore;

public class Track
{
    // ### objects and values required from parent
    // placeholder for an object which will be passed to Steps to let them play their audio
    //TODO: determine if there should be one audio out provider for the whole program, or one per track
    public object? AudioOutProvider;
    
    // ### child objects
    public List<Step> Steps;
    
    // ### volume properties
    public bool IsMuted = false;

    public int TrackVolume = 100;

    public Track(List<Step>? trackCells = null)
    {
        Steps = trackCells ?? new List<Step>(GlobalConsts.MaxPatternLength);
    }
}
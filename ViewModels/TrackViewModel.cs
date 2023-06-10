using System;
using Avalonia.Collections;
using SharpTracker.TrackerCore;

namespace SharpTracker.ViewModels;

public class TrackViewModel
{
    // ### objects and values required from parent
    // placeholder for an object which will be passed to Steps to let them play their audio
    // This might be a mixer, as implemented in NAudio
    //TODO: determine if there should be one audio out provider for the whole program, or one per track
    public object AudioOutProvider;

    // ### child objects
    public AvaloniaList<Step> TrackSteps;

    // ### volume properties
    public bool IsMuted = false;

    private int _trackVolume = 100;
    public int TrackVolume
    {
        get => _trackVolume;
        set => _trackVolume = Math.Clamp(value, 0, GlobalConsts.MaxVolume);
    }

    public TrackViewModel(object audioOutProvider, AvaloniaList<Step>? trackCells)
    {
        AudioOutProvider = audioOutProvider;
        TrackSteps = trackCells ?? new AvaloniaList<Step>(GlobalConsts.MaxPatternLength);
    }
}
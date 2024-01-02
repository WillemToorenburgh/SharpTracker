using System;
using System.Linq;
using Avalonia.Collections;
using ReactiveUI;
using SharpTracker.TrackerCore;

namespace SharpTracker.ViewModels.TrackerCore;

public class TrackViewModel : ViewModelBase
{
    private Track _track;
    
    public TrackViewModel(Track? track = null)
    {
        _track = track ?? new Track();
        LoadSteps();
    }

    public AvaloniaList<StepViewModel> Steps { get; set; }

    public void LoadSteps()
    {
        // Create a new AvaloniaList of StepViewModels, and populate it with the StepViewModel representation of Steps
        Steps = new AvaloniaList<StepViewModel>(_track.TrackSteps.Select(step => new StepViewModel(step)));
    }

    public bool IsMuted
    {
        get => _track.IsMuted;
        set => _track.IsMuted = this.RaiseAndSetIfChanged(ref _track.IsMuted, value);
    }

    public int TrackVolume
    {
        get => _track.TrackVolume;
        //TODO: can't ref to a property that has a method setter, it seems. Need to maybe replicate the effects of RaiseAndSetIfChanged?
        // set => _track.TrackVolume = this.RaiseAndSetIfChanged(ref _track.TrackVolume, Math.Clamp(value, 0, GlobalConsts.MaxVolume));
    }
}
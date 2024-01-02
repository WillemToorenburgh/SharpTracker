using System;
using System.Linq;
using Avalonia.Collections;
using ReactiveUI;

using SharpTracker.TrackerCore;

namespace SharpTracker.ViewModels.TrackerCore;

public class PatternViewModel : ViewModelBase
{
    private Pattern _pattern;

    public PatternViewModel(Pattern? pattern = null)
    {
        _pattern = pattern ?? new Pattern();
        LoadTracks();
    }
    
    public string Name
    {
        get => _pattern.Name;
        set => _pattern.Name = this.RaiseAndSetIfChanged(ref _pattern.Name, value);
    }

    public int Length
    {
        get => _pattern.Length;
        //TODO: can't ref to a property that has a method setter, it seems. Need to maybe replicate the effects of RaiseAndSetIfChanged?
        // set => _pattern.Length = this.RaiseAndSetIfChanged(ref _pattern.Length, Math.Clamp(value, 1, GlobalConsts.MaxPatternLength));
    }

    public AvaloniaList<TrackViewModel> Tracks;

    public void LoadTracks()
    {
        // Create a new AvaloniaList of TrackViewModels, and populate it with the TrackViewModel representation of Tracks
        Tracks = new AvaloniaList<TrackViewModel>(_pattern.Tracks.Select(track => new TrackViewModel(track)));
    }
}
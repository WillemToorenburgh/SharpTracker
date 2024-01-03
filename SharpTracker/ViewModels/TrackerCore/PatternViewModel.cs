using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Collections;

using SharpTracker.TrackerCore;

namespace SharpTracker.ViewModels.TrackerCore;

public class PatternViewModel : ViewModelBase
{
    private Pattern _pattern;

    public ObservableCollection<TrackViewModel> Tracks { get; }

    public PatternViewModel(Pattern? pattern = null)
    {
        _pattern = pattern ?? new Pattern();
        // Create a new ObservableCollection of TrackViewModels, and populate it with the TrackViewModel representation of Tracks
        Tracks = new ObservableCollection<TrackViewModel>(_pattern.Tracks.Select(track => new TrackViewModel(track)));
    }
    
    public string Name
    {
        get => _pattern.Name;
        set => SetProperty(field: ref _pattern.Name, newValue: value);
    }

    public int Length
    {
        get => _pattern.Length;
        set => SetProperty(field: ref _pattern.Length, Math.Clamp(value, 1, GlobalConsts.MaxPatternLength));
    }

    public object Scale
    {
        get => _pattern.Scale;
        set => SetProperty(field: ref _pattern.Scale, newValue: value);
    }

    public object Mode
    {
        get => _pattern.Mode;
        set => SetProperty(field: ref _pattern.Mode, newValue: value);
    }

}
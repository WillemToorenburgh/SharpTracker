using System;
using System.Collections.ObjectModel;
using System.Linq;
using SharpTracker.TrackerCore;

namespace SharpTracker.ViewModels.TrackerCore;

public class TrackViewModel : ViewModelBase
{
    private Track _track;

    public ObservableCollection<StepViewModel> Steps { get; set; }

    public TrackViewModel(Track? track = null)
    {
        _track = track ?? new Track();
        // Create a new ObservableCollection of StepViewModels, and populate it with the StepViewModel representation of Steps
        Steps = new ObservableCollection<StepViewModel>(_track.Steps.Select(step => new StepViewModel(step)));
    }

    public bool IsMuted
    {
        get => _track.IsMuted;
        set => SetProperty(ref _track.IsMuted, value);
    }

    public int TrackVolume
    {
        get => _track.TrackVolume;
        set => SetProperty(ref _track.TrackVolume, Math.Clamp(value, 0, GlobalConsts.MaxVolume));
    }
}
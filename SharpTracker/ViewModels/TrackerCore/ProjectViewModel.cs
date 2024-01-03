using System;
using System.Collections.ObjectModel;
using System.Linq;

using SharpTracker.TrackerCore;
using SharpTracker.TrackerCore.Instruments;

namespace SharpTracker.ViewModels.TrackerCore;

public class ProjectViewModel : ViewModelBase
{
    private Project _project;
    
    //TODO: Figure out if ITrackerInstrument needs a viewmodel as well
    public ObservableCollection<ITrackerInstrument> Instruments { get; }
    // A list of ints that point to indices of patterns in the Patterns collection
    public ObservableCollection<int> Song { get; }
    public ObservableCollection<PatternViewModel> Patterns { get; }

    public int ProjectVolume
    {
        get => _project.Volume;
        set => SetProperty(ref _project.Volume, Math.Clamp(value, 0, GlobalConsts.MaxVolume));
    }

    public ProjectViewModel(Project? project = null)
    {
        _project = project ?? new Project();
        Song = new(_project.Song);
        Patterns = new ObservableCollection<PatternViewModel>(_project.Patterns.Select(pattern => new PatternViewModel(pattern)));
    }
}
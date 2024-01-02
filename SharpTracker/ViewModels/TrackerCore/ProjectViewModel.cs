using System;
using Avalonia.Collections;
using ReactiveUI;
using SharpTracker.TrackerCore;
using SharpTracker.TrackerCore.Instruments;

namespace SharpTracker.ViewModels.TrackerCore;

public class ProjectViewModel : ViewModelBase
{
    private Project _project;
    
    //TODO: Figure out if ITrackerInstrument needs a viewmodel as well
    public AvaloniaList<ITrackerInstrument> Instruments;
    public AvaloniaList<int> Song;
    public AvaloniaList<PatternViewModel> Patterns;

    public int ProjectVolume
    {
        get => _project.ProjectVolume;
        //TODO: can't ref to a property that has a method setter, it seems. Need to maybe replicate the effects of RaiseAndSetIfChanged?
        // set => this.RaiseAndSetIfChanged(ref _project.ProjectVolume, Math.Clamp(value, 0, GlobalConsts.MaxVolume));
    }
    
    // TODO: ProjectSettings needs a ViewModel
    public ProjectSettings ProjectSettings
    {
        get => _project.Settings;
        set => this.RaiseAndSetIfChanged(ref _project.Settings, value);
    }

    public ProjectViewModel(Project? project = null)
    {
        _project = project ?? new Project();
        Patterns = LoadCollection<Pattern, PatternViewModel>(_project.Patterns);
    }
}
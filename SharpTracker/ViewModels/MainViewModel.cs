using System.Collections.Generic;
using System.Collections.ObjectModel;

using SharpTracker.ViewModels.TrackerCore;

namespace SharpTracker.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ProjectViewModel Project { get; }

    public MainViewModel()
    {
        var project = new ProjectViewModel();
        Project = project;
    }
}

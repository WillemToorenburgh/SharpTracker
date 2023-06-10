using SharpTracker.TrackerCore;
using System.Collections.ObjectModel;

namespace SharpTracker.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public ObservableCollection<TrackViewModel> DummyTracks;

    public MainWindowViewModel()
    {
        DummyTracks = new ObservableCollection<TrackViewModel>
        {
            new TrackViewModel(new {}, default),
            new TrackViewModel(new {}, default)
        };
    }
}

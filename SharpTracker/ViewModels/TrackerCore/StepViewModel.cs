using ReactiveUI;
using SharpTracker.TrackerCore;

namespace SharpTracker.ViewModels.TrackerCore;

public class StepViewModel : ViewModelBase
{
    private Step _step;

    public StepViewModel(Step step)
    {
        _step = step;
    }

    public string? Note
    {
        get => _step.Note;
        set => this.RaiseAndSetIfChanged(ref _step.Note, value);
    }

    public int? Instrument
    {
        get => _step.Instrument;
        set => this.RaiseAndSetIfChanged(ref _step.Instrument, value);
    }
    
    public string? Effect1
    {
        get => _step.Effect1;
        set => this.RaiseAndSetIfChanged(ref _step.Effect1, value);
    }
    
    public string? Effect2
    {
        get => _step.Effect2;
        set => this.RaiseAndSetIfChanged(ref _step.Effect2, value);
    }
}
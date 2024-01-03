namespace SharpTracker.TrackerCore;

public class Step
{
    // This probably will need to be an enum of notes or something
    public string Note = "c4";
    // This will need to refer to an instance of an instrument class
    // Is int the right type for this?
    // Maybe it is, because the int can point to an index in the Project.Instruments list
    // This would allow swapping instruments very easily
    public int? Instrument = null;
    // These may need to be enums or bytes or something in the future
    public string? Effect1 = null;
    public string? Effect2 = null;
}
namespace SharpTracker.TrackerCore;

public class ProjectSettings
{
    public string? Name { get; set;}
    public string? Description { get; set;}
    public string? ArtistName { get; set;}
    //TODO: the setter of this field might need to do a lot of work. Or, perhaps, this ends up being a backing field that a ViewModel handles updating
    public int BeatsPerMinute { get; set;}
}
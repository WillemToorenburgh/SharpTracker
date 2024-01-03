using System;
using System.Collections.Generic;

using SharpTracker.TrackerCore.Instruments;

namespace SharpTracker.TrackerCore;

public class Project
{
    // Keep track of version this project was made under, in case changes need to be made in the future
    private int SharpTrackerProjectVersion = 1;
    
    // Contains project name, author name, number of tracks, etc
    // TODO: Implement ProjectSettings so that the UI can see it
    public ProjectSettings Settings { get; set; }
    public List<ITrackerInstrument>? Instruments { get; set; }
    // List of ints that point to indices of Patterns to compose a song
    public List<int> Song { get; set; }
    public List<Pattern> Patterns { get; set; }

    public Project()
    {
        Settings = new ProjectSettings();
        Instruments = new List<ITrackerInstrument>();
        Song = new List<int>();
        Patterns = new List<Pattern>();
    }

    //TODO: implement an NAudio Mixer provider to combine separate sources of audio to one output stream

    public int Volume = 100;
}

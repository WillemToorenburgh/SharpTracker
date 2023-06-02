using System;
using System.Collections.Generic;

using SharpTracker.TrackerCore.Instruments;

namespace SharpTracker.TrackerCore;

public class Project
{
    // Keep track of version this project was made under, in case changes need to be made in the future
    private int SharpTrackerProjectVersion = 1;
    
    // Contains project name, author name, number of tracks, etc
    public object ProjectSettings;
    public List<BaseInstrument> Instruments;
    // List of ints that point to indices of Patterns to compose a song
    public List<int> Song;
    public List<Pattern> Patterns;
    
    //TODO: implement an NAudio Mixer provider to combine separate sources of audio to one output stream
    
    private int _projectVolume = 100;
    public int ProjectVolume
    {
        get => _projectVolume;
        set => _projectVolume = Math.Clamp(value, 0, GlobalConsts.MaxVolume);
    }
}
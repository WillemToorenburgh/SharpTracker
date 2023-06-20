# SharpTracker

A noob's attempt at making a Tracker-style Digital Audio Workstation using multi-platform .Net 

## Plan:

1. Muck about with Avalonia (https://avaloniaui.net/GettingStarted) to make something resembling a vertical list with some buttons
2. Try generating a sine wave with NAudio
3. Sine wave at different notes
4. Note data in list

## LATER...

* Basic persistence
* Basic effects (volume change, note chance, sample playback direction, random pitch, etc)
* Check out ReactiveUI (https://www.reactiveui.net) to see if it makes sense to include/refactor into
* Implement basic MIDI support
* Implement VST support (VST2 and VST3, probably x64 only)
* (maybe) Support for some common tracker mod file formats
* Controller support

## Feature ideas

### Capture randomness results in a buffer, then allow user to commit the captured randomness into the pattern

Example: step 1 played, step 2 played, step 3 did not play, step 4 played

| Note | Instrument | FX 1 | FX 2 |
|------|------------|------|------|
| C3   | 01         | c 50 | ---- |
| D3   | 01         | c 50 | ---- |
| E3   | 01         | c 50 | ---- |
| F3   | 01         | c 50 | ---- |

Renders into: step 1 populated, step 2 populated, step 3 empty, step 4 populated

| Note | Instrument | FX 1 | FX 2 |
|------|------------|------|------|
| C3   | 01         | ---- | ---- |
| --   | --         | ---- | ---- |
| E3   | 01         | ---- | ---- |
| F3   | 01         | ---- | ---- |
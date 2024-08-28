using Godot;
using System;

public partial class MusicVolumeStart : HSlider
{
	double valueBefore;
	private AudioStreamPlayer menuMusic;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
    //checks if it's the first time the game has started
    if (globals.firstStart == true)
    {
      //if yes, set the volume for music
      globals.musicVolume = -13.0f;
    }
    this.Value = (double)globals.musicVolume + 80; //set the slider value
		valueBefore = this.Value; //save the current value
		menuMusic = GetParent().GetParent().GetNode<AudioStreamPlayer>("MenuMusic"); //initialize the menu music
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
    //detect if the slider value was changed
		if (Value != valueBefore)
		{
			ChangeVol();
		}
		valueBefore = Value; //save the new value
	}

	private void ChangeVol()
	{
    //set new music volume
		float volume = (float)this.Value - 80;
		globals.musicVolume = volume;
		menuMusic.VolumeDb = globals.musicVolume;
	}
}

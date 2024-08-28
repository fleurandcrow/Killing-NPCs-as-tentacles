using Godot;
using System;

public partial class MusicVolume : HSlider
{
	double valueBefore;
	private AudioStreamPlayer bgm;
	private AudioStreamPlayer newBgm;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//initialize all the variables
		this.Value = (double)globals.musicVolume + 80;
    valueBefore = Value;
		bgm = GetParent().GetParent().GetParent().GetNode<AudioStreamPlayer>("DefaultBGM");
		newBgm = GetParent().GetParent().GetParent().GetNode<AudioStreamPlayer>("BGMTooMany");
    bgm.VolumeDb = globals.musicVolume;
    newBgm.VolumeDb = globals.musicVolume;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//detect if the value of the slider has changed
		if (Value != valueBefore)
		{
			ChangeVol();
		}
		valueBefore = Value;
	}

	private void ChangeVol()
	{
		//changed the value according to the slider value with the volume equation
		float volume = (float)this.Value - 80;
		globals.musicVolume = volume;
		bgm.VolumeDb = globals.musicVolume;
		newBgm.VolumeDb = globals.musicVolume;
	}
}

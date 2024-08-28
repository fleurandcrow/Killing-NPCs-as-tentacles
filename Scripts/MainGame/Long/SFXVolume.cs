using Godot;
using System;

public partial class SFXVolume : HSlider
{
	//this is basically the music volume script except it's for the sfx
	double valueBefore;
	private AudioStreamPlayer bloodSfx;
	private AudioStreamPlayer screamSfx;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//initialize all the variables
    this.Value = (double)globals.sfxVolume + 80;
		valueBefore = Value;
		bloodSfx = GetParent().GetParent().GetParent().GetNode<AudioStreamPlayer>("NPCBloodSFX");
		screamSfx = GetParent().GetParent().GetParent().GetNode<AudioStreamPlayer>("NPCScreamSFX");
    bloodSfx.VolumeDb = globals.sfxVolume;
    screamSfx.VolumeDb = globals.sfxVolume;
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
		globals.sfxVolume = volume;
		bloodSfx.VolumeDb = globals.sfxVolume;
		screamSfx.VolumeDb = globals.sfxVolume;
	}
}

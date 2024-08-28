using Godot;
using System;

public partial class SFXVolumeStart : HSlider
{
	double valueBefore;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
    //detect if it's the game's first start
    if (globals.firstStart == true)
    {
      //if yes, set an sfx volume value
      globals.sfxVolume = -17.0f;
      globals.firstStart = false;
    }
    this.Value = globals.sfxVolume + 80; //set slider value
		valueBefore = Value; //save current value
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
    //check if slider value has been changed
		if (Value != valueBefore)
		{
			ChangeVol();
		}
		valueBefore = Value;
	}

	private void ChangeVol()
	{
    //change the sfx volume
		float volume = (float)this.Value - 80;
		globals.sfxVolume = volume;
	}
}

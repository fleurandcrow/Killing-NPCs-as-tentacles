using Godot;
using System;

public partial class globals : Node
{
	//create the global variables
	public static int killCount; //the NPC kill count
	public static float musicVolume; //the music volume
	public static float sfxVolume; //the SFX volume
	public static bool surpriseCalled = false; //has the surprise method been called?
  public static bool firstStart = true; //is this the first time on the start menu?
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

}

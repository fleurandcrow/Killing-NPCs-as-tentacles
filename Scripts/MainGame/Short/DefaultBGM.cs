using Godot;
using System;

public partial class DefaultBGM : AudioStreamPlayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//play the default bgm first time the scene is instantiated
		this.Playing = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

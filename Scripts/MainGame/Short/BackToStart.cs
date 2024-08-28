using Godot;
using System;

public partial class BackToStart : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += Back; //connect Pressed signal to Back method
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Back()
	{
		//reset kill count, unpause the game, go back to start menu
		globals.killCount = 0;
		GetTree().Paused = false;
		GetTree().ChangeSceneToFile("res://start_menu.tscn");
	}
}

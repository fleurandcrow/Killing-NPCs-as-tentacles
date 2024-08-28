using Godot;
using System;

public partial class StartButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += StartGame; //connect the Pressed signal to the StartGame method
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void StartGame()
	{
	//change scene to the main game scene
		GetTree().ChangeSceneToFile("res://main_scene.tscn");
	}
}

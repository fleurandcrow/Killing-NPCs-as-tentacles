using Godot;
using System;

public partial class GameSettingsButton : Button
{
	private Node pauseMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//initialize reference to the pause menu
		pauseMenu = GetParent().GetNode<Node>("PauseMenu");
		//Pressed signal for when the button is pressed
		Pressed += Toggle;
	}
	

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Toggle()
	{
		//toogle the visibility of the pause menu and of the paused status of the same
		foreach (var child in pauseMenu.GetChildren())
		{
			if (child is CanvasItem canvasItem)
			{
				canvasItem.Visible = !canvasItem.Visible;
				GetTree().Paused = !GetTree().Paused;
			}
		}
	}
}

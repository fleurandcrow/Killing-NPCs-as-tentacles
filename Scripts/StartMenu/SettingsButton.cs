using Godot;
using System;

public partial class SettingsButton : Button
{
	private Control settings;
	private Control startMenu;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{ 
    //intialize the variables
		settings = GetParent().GetParent().GetNode<Control>("Settings");
		startMenu = GetParent().GetParent().GetNode<Control>("StartMenu");
		Pressed += Settings; //connect the pressed signal to the settings method
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Settings()
	{
    //make the settings menu visible while making the start menu invisible
		settings.Visible = true;
		startMenu.Visible = false;
	}
}

using Godot;
using System;

public partial class BackButton : Button
{
	//this script is shared betweem the credits and settings
	private Control parent;
	private Control startMenu;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//initialize variables
		parent = GetParent<Control>();
		startMenu = GetParent().GetParent().GetNode<Control>("StartMenu");
		Pressed += GoBack;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void GoBack()
	{
		//make the parent invisible + enable start menu visible
		parent.Visible = false;
		startMenu.Visible = true;
	}
}

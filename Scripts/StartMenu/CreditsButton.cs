using Godot;
using System;

public partial class CreditsButton : Button
{
	private Control credits;
	private Control startMenu;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//initialize the variables
		credits = GetParent().GetParent().GetNode<Control>("Credits");
		startMenu = GetParent().GetParent().GetNode<Control>("StartMenu");
		Pressed += Credits;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Credits()
	{
		//make the credits visible and start menu invisible
		credits.Visible = true;
		startMenu.Visible = false;
	}
}

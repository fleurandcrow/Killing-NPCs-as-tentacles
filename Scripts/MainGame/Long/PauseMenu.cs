using Godot;
using System;

public partial class PauseMenu : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//set the pause menu invisible the first time when it enters the scene
		SetInvisible();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SetInvisible()
	{
		//make pausemenu not visible
		foreach (var child in this.GetChildren())
		{
			if (child is CanvasItem canvasItem)
			{
				canvasItem.Visible = false;
			}
		}
	}

}

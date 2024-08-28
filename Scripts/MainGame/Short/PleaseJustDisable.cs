using Godot;
using System;

public partial class PleaseJustDisable : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//auto disables the secret popup so it doesn't appear before the right time
		foreach (var child in this.GetChildren())
		{
			if (child is CanvasItem canvasItem)
			{
				canvasItem.Visible = false;
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

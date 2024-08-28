using Godot;
using System;

public partial class YesButton : Button
{
	private Node uhOh;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//initialize the variable that refers to the popup and the signal
		uhOh = GetParent<Node>();
		Pressed += Close;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Close()
	{
		//close the popup
		foreach (var child in uhOh.GetChildren())
		{
			if (child is CanvasItem canvasItem)
			{
				canvasItem.Visible = !canvasItem.Visible;
			}
		}
	}
}

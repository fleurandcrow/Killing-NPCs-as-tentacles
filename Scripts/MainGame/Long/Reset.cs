using Godot;
using System;

public partial class Reset : Button
{
	private Label killCount;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += ResetNPCs;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void ResetNPCs()
	{
		//reset NPCs and kills
		killCount = GetParent().GetParent().GetNode<Label>("KillCount");
		var npcs = GetTree().GetNodesInGroup("npc");
		foreach (var npc in npcs)
		{
			npc.QueueFree();
		}
		globals.killCount = 0;
		globals.surpriseCalled = false;
		killCount.Text = "Kill count: "+ Convert.ToString(globals.killCount);

		//reset the audio
		AudioStreamPlayer bgm = GetParent().GetParent().GetParent().GetNode<AudioStreamPlayer>("DefaultBGM");
		AudioStreamPlayer newBgm = GetParent().GetParent().GetParent().GetNode<AudioStreamPlayer>("BGMTooMany");
		newBgm.Playing = false;
		bgm.Playing = true;
	}
	
}

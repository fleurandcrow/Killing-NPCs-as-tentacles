using Godot;
using System;

public partial class collision_manager : Node2D
{
	private PackedScene npcScene;
	private Vector2 npcPos;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//initialize the npc variable and the initial npc's position
		npcScene = (PackedScene)GD.Load("res://npc.tscn");
		npcPos = this.GetNode<CharacterBody2D>("NPC").Position;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//spawns a new npc if the scene has no npcs
		bool hasNPC = GetTree().HasGroup("npc");
		if (hasNPC == false)
		{
			CharacterBody2D npc = (CharacterBody2D)npcScene.Instantiate();
			GetParent().AddChild(npc);
			npc.Position = npcPos;
		}
	}

}


using Godot;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

public partial class tentacle_move : CharacterBody2D
{
	//variables that get initialized later
	private PackedScene npcScene;
  private PackedScene bloodScene;
	private Vector2 pos;
	private Vector2 startY;
	private Vector2 npcPos;
	private Label killCount;
	private AnimatedSprite2D animation;
	private AudioStreamPlayer npcBloodSfx;
	private AudioStreamPlayer npcScreamSfx;
  private Camera2D camera;
	public int npcCount;

	//variables with set values
	private int maxNpc = 20;
	public const float Speed = 30.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		//initialize all the previously created variables
		npcScene = (PackedScene)GD.Load("res://npc.tscn");
	bloodScene = (PackedScene)GD.Load("res://blood.tscn");
		killCount = GetParent().GetNode("GUI").GetNode<Label>("KillCount");
		killCount.Text = "Kill count: "+ Convert.ToString(globals.killCount);
		animation = GetNode<AnimatedSprite2D>("TentaAnim");
		animation.Play("default", 1.0f, false);
		npcPos = GetParent().GetNode<CharacterBody2D>("NPC").Position;
		pos = this.Position;
		startY = pos;
		npcCount = 1;
		npcScreamSfx = GetParent().GetNode<AudioStreamPlayer>("NPCScreamSFX");
		npcBloodSfx = GetParent().GetNode<AudioStreamPlayer>("NPCBloodSFX");
	camera = GetParent().GetNode<Camera2D>("Camera");
	}
	public override void _PhysicsProcess(double delta)
	{
	//Handle player movement
		Vector2 velocity = Velocity;

		this.Position = Position.MoveToward(pos, Speed);
		
		Velocity = velocity;
		MoveAndSlide();

		//detect collision
		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			var collision = GetSlideCollision(i);
			var collider = (Node)collision.GetCollider();
			if (collider.IsInGroup("npc"))
			{
				//checks if it's an npc
				RemoveNPC(collider);
				globals.killCount++;
				killCount.Text = "Kill count: "+ Convert.ToString(globals.killCount);
				if (npcCount < maxNpc) //there's a maximum number of npcs allowed in the scene at a time to optimize ressource usage
				{
					NewNPC();
				}
			}
		}
	}

	public override async void _UnhandledInput(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent)
		{
			//handle the mouse input
			if (mouseEvent.Pressed)
			{
				//set position to mouse input position
   				pos = mouseEvent.Position;
				await ToSignal(GetTree().CreateTimer(0.7f), "timeout");
				pos = startY;
			}
		}
	}

	public async void NewNPC()
	{
		//Creates a new npc
		Random numberGen = new();
		for (int i = 0; i < numberGen.Next(1, 3); i++) //makes between 1 and 3 npcs
		{
			CharacterBody2D npc = (CharacterBody2D)npcScene.Instantiate();
			GetParent().AddChild(npc);
			npc.Position = npcPos;
			npcCount++;
			await ToSignal(GetTree().CreateTimer(1.5f), "timeout"); //cooldown or else they all are stacked over one another
		}
	}

	public async void RemoveNPC(Node npc)
	{
		//kill the NPC
		npc.QueueFree();
		npcCount--;
		//play the SFX
		animation.Play("kill", 1.0f, false);
		npcScreamSfx.Playing = true;
		await ToSignal(GetTree().CreateTimer(0.6f), "timeout"); //cooldown so the blood sfx plays after the screams >:)
	  //add the blood splatter!
	  Node2D blood = (Node2D)bloodScene.Instantiate(); //Instantiate the blood scene
	  GetParent().AddChild(blood); //Add blood to hierarchy
	  blood.Position = this.Position;
		npcBloodSfx.Playing = true;
	//play the default animation again
		animation.Play("default", 1.0f, false);
		if (globals.killCount > 200 && globals.surpriseCalled == false)
		{
			//when too much blood gets shed...
			TooManyKilled();
		}
	}

	private void TooManyKilled()
	{
		//If you haven't played, you're spoiling yourself here
		//Secret message when you kill too many npcs
		GD.Print("mecalled");
		Node uhOh = GetParent().GetNode("UhOh");
		AudioStreamPlayer bgm = GetParent().GetNode<AudioStreamPlayer>("DefaultBGM");
		AudioStreamPlayer newBgm = GetParent().GetNode<AudioStreamPlayer>("BGMTooMany");
		bgm.Playing = false;
		foreach (var child in uhOh.GetChildren())
		{
			//Make le popup visible
			if (child is CanvasItem canvasItem)
			{
				canvasItem.Visible = true;
			}
		}
		newBgm.Playing = true; //play the intense bgm
		globals.surpriseCalled = true;
	}

}

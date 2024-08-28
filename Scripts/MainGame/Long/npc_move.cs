using Godot;
using System;

public partial class npc_move : CharacterBody2D
{
	//Create the variables
  public const float Speed = 15.0f;
	public const float JumpVelocity = -400.0f;
	private AnimatedSprite2D animation;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _Ready()
	{
		//initialize the animation variables
	animation = GetNode<AnimatedSprite2D>("AnimatedNPC");
		animation.Play("walk", 1.0f, false);
	}

	

	public override void _PhysicsProcess(double delta)
	{
	//Make the NPCs move 
		Vector2 velocity = Velocity;

		Vector2 direction = new Vector2(Speed, 0);
		
		velocity.X = direction.X * Speed;
		
		Velocity = velocity;
		MoveAndSlide();

		for (int i = 0; i < GetSlideCollisionCount(); i++)
		{
			//detect NPC collision
			var collision = GetSlideCollision(i);
			var collider = (Node)collision.GetCollider();
			var colliderName = collider.Name;
			//if the NPC goes out of bounds, delete it to save ressources
			if (colliderName == "Boundary")
			{
				this.QueueFree();
			}
		}

	}
}

using Godot;
using System;

public partial class blood : Sprite2D
{
  public AnimationPlayer anim;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	//play the splash animation when the blood node enters the scene
	  anim = GetNode<AnimationPlayer>("Anim");
	  anim.Play("in", -1, 1.0f, false);
	  OutOfScene();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

  private async void OutOfScene()
  {
	//play the "out" animation after 0.5 seconds then removes blood from scene tree
	  await ToSignal(GetTree().CreateTimer(0.5f), "timeout");
	  anim.Play("out", -1, 1.0f, false);
	  await ToSignal(GetTree().CreateTimer(1.0f), "timeout");
	  this.QueueFree();
  }
}

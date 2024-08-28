using Godot;
using System;

public partial class TentaStart : Control
{
  //create the animatiom variable
  public AnimationPlayer anim;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	//start playing the start menu tentacles animation
	  anim = GetNode<AnimationPlayer>("TentaAnim");
	  anim.Play("tenta1", -1, 1.0f, false);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

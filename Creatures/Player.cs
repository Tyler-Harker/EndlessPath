using Godot;
using System;
using EndlessPath.Constants;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		
		Velocity = new Vector2(
			(Input.GetActionStrength(ControlConstants.MoveRight) - Input.GetActionStrength(ControlConstants.MoveLeft)) * 100,
			((Input.GetActionStrength(ControlConstants.MoveDown) - Input.GetActionStrength(ControlConstants.MoveUp)) * 100)
			);

		var animationPlayer = GetNode<Sprite2D>("character_1").GetNode<AnimationPlayer>("AnimationPlayer");
		// var animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
		if (Velocity.X > 0)
		{
			animationPlayer.CurrentAnimation = ControlConstants.MoveLeft;
		}
		else if (Velocity.X < 0)
		{
			animationPlayer.CurrentAnimation = ControlConstants.MoveRight;
		}
		else
		{
			animationPlayer.CurrentAnimation = "idle_left";
		}
		
		MoveAndSlide();
	}
}

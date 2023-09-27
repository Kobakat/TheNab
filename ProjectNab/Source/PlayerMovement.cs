using Godot;
using System;

public sealed partial class PlayerMovement : CharacterBody2D
{
	[Export] // SerializedField
	float movementSpeed = 200;
	[Export]
	Vector2 maxVelocity = new Vector2(10000, 1000);
	[Export]
	float jumpForce = 200;
	[Export]
	float gravity = 250;

	public sealed override void _Ready() // Start()
	{
		base._Ready();
	}

	public sealed override void _Process(double delta) // Update()
	{
		base._Process(delta);
		//Get horizontal input
		float horizontalInput = Input.GetActionStrength("Right") - Input.GetActionStrength("Left");


		Vector2 velocity = Velocity; // Get current velocity
		velocity.Y += (float)delta * gravity; // add gravity force
		velocity.X += horizontalInput * movementSpeed * (float)delta; // add horizontal force
		if (Input.IsActionJustPressed("Up") && IsOnFloor())
		{
			velocity.Y -= jumpForce;
		}
		Velocity = velocity.Clamp(-maxVelocity, maxVelocity); // Clamp

		MoveAndSlide();
	}

}

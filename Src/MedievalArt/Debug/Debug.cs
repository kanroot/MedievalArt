using Godot;
using System;

public class Debug : Control
{
	private Label position;

	public override void _Ready()
	{
		position = GetChild<Label>(0);
	}


	public override void _Process(float delta)
	{
		var x = GetGlobalMousePosition().x;
		var y = GetGlobalMousePosition().y;
		position.Text = $"X: {x.ToString()} Y: {y.ToString()}";
	}
}
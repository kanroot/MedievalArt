using Godot;

namespace MedievalArt.MedievalArt
{
	public class Camera2DMap : Camera2D
	{
		[Export()] private float speedCamera;
		[Export()] private Vector2 speedZoom;
		[Export()] public Vector2 minZoom;
		[Export()] public Vector2 maxZoom;
		[Export()] public bool CanMove { get; set; }
		[Export()] public bool CanZoom { get; set; }

		public override void _Ready()
		{
		}

		public override void _Process(float delta)
		{
			Move(delta);
			ChangeZoom(delta);
		}

		private void Move(float delta)
		{
			if (!CanMove) return;
			var position = new Vector2();
			if (Input.IsActionPressed("ui_left")) position += new Vector2(speedCamera * delta, 0) * -1;
			if (Input.IsActionPressed("ui_right")) position += new Vector2(speedCamera * delta, 0);
			if (Input.IsActionPressed("ui_up")) position += new Vector2(0, speedCamera * delta) * -1;
			if (Input.IsActionPressed("ui_down")) position += new Vector2(0, speedCamera * delta);

			Position += position;
		}

		private void ChangeZoom(float delta)
		{
			if (!CanZoom) return;
			if (Input.IsActionJustReleased("zoom_in"))
				if (Zoom > minZoom)
					Zoom -= speedZoom;
			if (Input.IsActionJustReleased("zoom_out"))
				if (Zoom < maxZoom)
					Zoom += speedZoom;
		}
	}
}
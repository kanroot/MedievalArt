using Godot;

namespace MedievalArt.MedievalArt
{
	public class Map : Control
	{
		private Control cameraControl;
		private Camera2D camera;
		private CanvasLayer debug;
		private VBoxContainer debugContainer;
		private Label debugCoordinates;
		private Label zoom;

		public override void _Ready()
		{
			cameraControl = GetNode<Control>("CameraControl");
			camera = cameraControl.GetNode<Camera2D>("Camera");
			debug = GetNode<CanvasLayer>("Debug");
			debugContainer = debug.GetNode<VBoxContainer>("DebugContainer");
			debugCoordinates = debugContainer.GetNode<Label>("Coordinates");
			zoom = debugContainer.GetNode<Label>("Zoom");
		}

		public override void _Process(float delta)
		{
			debugCoordinates.Text = "X: " + camera.GlobalPosition.x + " Y: " + camera.GlobalPosition.y;
			zoom.Text = "Zoom: " + camera.Zoom;
		}
	}
}
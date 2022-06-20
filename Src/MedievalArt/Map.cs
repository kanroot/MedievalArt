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

		public override void _Ready()
		{
			cameraControl = GetNode<Control>("CameraControl");
			camera = cameraControl.GetNode<Camera2D>("Camera");
			debug = GetNode<CanvasLayer>("Debug");
			debugContainer = debug.GetNode<VBoxContainer>("DebugContainer");
			debugCoordinates = debugContainer.GetNode<Label>("Coordinates");
		}

		public override void _Process(float delta)
		{
			debugCoordinates.Text = "X: " + camera.Position.x + " Y: " + camera.Position.y;
		}
	}
}
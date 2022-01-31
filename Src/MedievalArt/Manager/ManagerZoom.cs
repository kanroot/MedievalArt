using Godot;
using MedievalArt.Scenes;

namespace MedievalArt.MedievalArt.Manager
{
	public class ManagerZoom : Node
	{
		private Camera2DMap camera2DMap;
		private readonly Vector2 zoomLabelNamesKingdom = new Vector2(3, 3);
		private Ground ground;
		private Control kingdomLabel;
		public static ManagerZoom Instance { get; private set; }

		public override void _Ready()
		{
			Instance = this;
			camera2DMap = GetTree().CurrentScene.FindNode("Camera2DMap") as Camera2DMap;
			ground = GetTree().CurrentScene.FindNode("Ground") as Ground;
			kingdomLabel = GetTree().CurrentScene.FindNode("NameKingdom") as Control;
		}

		public override void _Process(float delta)
		{
			MouseZoom(delta);
		}


		private void HiddenLabel(Control label, float delta)
		{
			var modulateTemp = label.Modulate;
			if (camera2DMap?.minZoom >= camera2DMap?.Zoom || modulateTemp.a < 0)
				modulateTemp.a = 0;
			else
				modulateTemp.a -= delta * 5;
			label.Modulate = modulateTemp;
		}

		private void ShowLabel(Control label, float delta)
		{
			var modulateTemp = label.Modulate;
			if (camera2DMap?.Zoom >= zoomLabelNamesKingdom && camera2DMap?.Zoom < camera2DMap?.maxZoom)
				modulateTemp.a += delta * 5;

			if (camera2DMap?.maxZoom == camera2DMap?.Zoom || modulateTemp.a > 1) modulateTemp.a = 1;
			label.Modulate = modulateTemp;
		}

		private void MouseZoom(float delta)
		{
			if (Input.IsActionJustReleased("zoom_in"))
				HiddenLabel(kingdomLabel, delta);
			if (Input.IsActionJustReleased("zoom_out"))
				ShowLabel(kingdomLabel, delta);
		}
	}
}
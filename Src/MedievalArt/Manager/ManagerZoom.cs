using Godot;
using MedievalArt.Scenes;

namespace MedievalArt.MedievalArt.Manager
{
	public class ManagerZoom : Node
	{
		private Camera2DMap camera2DMap;
		private Ground ground;
		private Control kingdomLabel;
		private Vector2? zoom = new Vector2(1, 1);
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
			zoom = camera2DMap?.Zoom;
			if (zoom > new Vector2((float)1.5, (float)1.5))
				ShowLabel(kingdomLabel);
			else
				HiddenLabel(kingdomLabel);
		}


		private void HiddenLabel(Control label )
		{
			label.Visible = false;
		}

		private void ShowLabel(Control label )
		{
			label.Visible = true;
		}
	}
}
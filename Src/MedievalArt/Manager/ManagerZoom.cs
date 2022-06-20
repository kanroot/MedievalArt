using System.Diagnostics;
using Godot;

namespace MedievalArt.MedievalArt.Manager
{
	public class ManagerZoom : Node
	{
		private Control cameraControl;
		private Camera2DMap camera2DMap;
		private Control kingdomControl;
		private Control roadControl;
		public static ManagerZoom Instance { get; private set; }

		public override void _Ready()
		{
			Instance = this;
			cameraControl = GetTree().CurrentScene.FindNode("CameraControl") as Control;
			camera2DMap = cameraControl?.GetNode<Camera2DMap>("Camera");
			kingdomControl = GetTree().CurrentScene.FindNode(
				"NameKingdom") as Control;
			roadControl = GetTree().CurrentScene.FindNode(
				"NameRoads") as Control;
		}

		public override void _Process(float delta)
		{
			MouseZoom(delta);
		}


		private void HiddenLabel(CanvasItem kingdom, CanvasItem road, float delta)
		{
			var kingdomRgba = kingdom.Modulate;
			var roadRgba = road.Modulate;

			if (camera2DMap?.zoomHidenKingdomLabel >= camera2DMap?.Zoom)
			{
				roadRgba.a = 1;
				kingdomRgba.a = 0;
			}
			else
			{
				kingdomRgba.a -= delta * 10;
				roadRgba.a += delta * 10;
			}

			road.Modulate = roadRgba;
			kingdom.Modulate = kingdomRgba;
		}

		private void ShowLabel(CanvasItem kingdom, CanvasItem road, float delta)
		{
			var kingdomRgba = kingdom.Modulate;
			var roadRgba = road.Modulate;

			if (camera2DMap?.Zoom < camera2DMap?.maxZoom && camera2DMap?.Zoom > camera2DMap?.zoomHidenKingdomLabel)
			{
				kingdomRgba.a += delta * 10;
				roadRgba.a -= delta * 10;
			}


			if (camera2DMap?.Zoom == camera2DMap?.maxZoom)
			{
				kingdomRgba.a = 1;
				roadRgba.a = 0;
			}


			road.Modulate = roadRgba;
			kingdom.Modulate = kingdomRgba;
		}

		private void MouseZoom(float delta)
		{
			if (Input.IsActionJustReleased("zoom_in"))
				HiddenLabel(kingdomControl, roadControl, delta);
			if (Input.IsActionJustReleased("zoom_out"))
				ShowLabel(kingdomControl, roadControl, delta);
		}
	}
}
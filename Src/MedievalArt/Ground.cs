using Godot;

namespace MedievalArt.Scenes
{
	public class Ground : StaticBody2D
	{
		public override void _Ready()
		{
			Connect("mouse_entered", this, nameof(Entre));
			Connect("mouse_exited", this, nameof(Sali));
		}

		public void Entre()
		{
			GD.Print("entre en el mapa");
		}

		public void Sali()
		{
			GD.Print("Sali");
		}
	}
}
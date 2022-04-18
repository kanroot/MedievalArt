using System;
using Godot;

namespace MedievalArt.MedievalArt
{
	public class Mountains : Node2D
	{
		[Export()] private PackedScene mountain;
		[Export()] private PackedScene mountain2;
		[Export()] private PackedScene mountain3;
		[Export()] private PackedScene mountain4;
		[Export()] private PackedScene mountain5;
		private Line2D pirineos;

		public override void _Ready()
		{
			pirineos = GetChild<Line2D>(0);
			GetTheNextPoint();
		}


		private void GetTheNextPoint()
		{
			var sizeOfMountains = GetSizeOfMountains() / 2;
			for (var i = 0; i < pirineos.GetPointCount() - 1; i++)
			{
				var lastPoint = pirineos.GetPointPosition(i + 1);
				var initialPoint = pirineos.GetPointPosition(i);
				while (initialPoint.x <= lastPoint.x)
				{
					initialPoint = new Vector2(initialPoint.x + sizeOfMountains.x, initialPoint.y);
					if (Math.Abs(initialPoint.y - lastPoint.y) > 1)
					{
						if (initialPoint.y < lastPoint.y)
						{
							initialPoint = new Vector2(initialPoint.x, initialPoint.y + sizeOfMountains.y);
						}
						else
						{
							initialPoint = new Vector2(initialPoint.x, initialPoint.y - sizeOfMountains.y);
						}
					}

					var mountainInstanced = mountain.Instance() as StaticBody2D;
					if (mountainInstanced != null) mountainInstanced.Position = initialPoint;
					pirineos.AddChild(mountainInstanced);
				}
			}
		}

		private Vector2 GetSizeOfMountains()
		{
			//este metodo obtiene el tamaño esclado de los montañas
			var mountainInstanced = mountain.Instance() as StaticBody2D;
			if (mountainInstanced != null)
			{
				var sprite = mountainInstanced.GetChild<Sprite>(0);
				var width = sprite.Texture.GetWidth() * mountainInstanced.Scale.x;
				var height = sprite.Texture.GetHeight() * mountainInstanced.Scale.y;
				var vector = new Vector2(width, height);
				return vector;
			}

			return new Vector2();
		}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
	}
}
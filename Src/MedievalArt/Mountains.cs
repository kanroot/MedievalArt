using System;
using System.Collections.Generic;
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
			var sizeOfMountains = GetSizeOfMountains();
			var distanceBetweenX = new List<float>();
			var distanceBetweenY = new List<float>();
			for (var i = 0; i < pirineos.GetPointCount() - 1; i++)
			{
				var initialPoint = pirineos.GetPointPosition(i);
				var lastPoint = pirineos.GetPointPosition(i + 1);
				distanceBetweenX.Add(lastPoint.x - initialPoint.x);
				distanceBetweenY.Add(lastPoint.y - initialPoint.y);
			}

			for (var i = 0; i < pirineos.GetPointCount() - 1; i++)
			{
				var initialPoint = pirineos.GetPointPosition(i);
				var countX = distanceBetweenX[i] / (sizeOfMountains.x / 2);
				var distanceY = distanceBetweenY[i] / countX;
				for (var j = 0; j < countX; j++)
				{
					var mountainInstanced = this.mountain.Instance() as StaticBody2D;
					if (mountainInstanced != null)
					{
						mountainInstanced.Position = new Vector2(initialPoint.x, initialPoint.y);
						pirineos.AddChild(mountainInstanced);
					}

					initialPoint = new Vector2(initialPoint.x + sizeOfMountains.x / 2, initialPoint.y + distanceY);
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
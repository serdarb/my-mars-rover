using System;

using MarsRover.Business.Contract;

namespace MarsRover.Business.Domain
{
	public class Plateau : Rectangular, IPlateau
	{
		public int Bottom { get{ return 0; } }
		public int Left { get{ return 0; } }
		public int Right { get{ return Width; } }
		public int Top { get{ return Height; } }

		private object[,] _grid;
		public object[,] Grid {	get{ return _grid; } }

		public Plateau (int width, int height)
		{
			Width = width;
			Height = height;

			_grid = new object[Right, Top];

			for (int i = Left; i < Right; i++) {
				for (int j = Bottom; j < Top; j++) {
					_grid [i, j] = string.Format("{0}x{1}", i, j);
				}
			}			
		}
	}
}
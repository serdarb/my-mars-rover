using System;

namespace MarsRover.Tests
{
	public class Rectangular : IRectangular
	{
		public int Width {
			get;
			set;
		}
		public int Height {
			get;
			set;
		}
		public int Size {
			get{ return Width * Height; }
		}
	}
}


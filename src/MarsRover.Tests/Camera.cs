using System;
using System.Drawing;

namespace MarsRover.Tests
{
	public class Camera : ICamera
	{
		public Bitmap TakePhoto ()
		{
			return new Bitmap(100,100);
		}
	}
}


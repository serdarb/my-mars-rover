using System;
using System.Drawing;
using NUnit.Framework;

namespace MarsRover.Tests
{
	public class Camera
	{
		public Bitmap TakePhoto ()
		{
			return new Bitmap(100,100);
		}
	}
}


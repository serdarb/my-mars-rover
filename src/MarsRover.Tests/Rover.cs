using System;
using System.Drawing;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRover.Tests
{
	public class Rover
	{
		public Camera Camera {
			get;
			set;
		}

		public Dictionary<string,Bitmap> Photos {
			get;
			set;
		}

		public Rover ()
		{
			Photos = new Dictionary<string,Bitmap> ();
		}

		public void TakePhoto ()
		{
			var image = Camera.TakePhoto ();
			Photos.Add (Guid.NewGuid().ToString(),image);
		}
	}
}


using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests
{
	public class Nasa
	{
		public Dictionary<string,Bitmap> Photos {
			get;
			set;
		}

		public Nasa ()
		{
			Photos = new Dictionary<string, Bitmap> ();
		}

		public Rover CreateRover ()
		{
			return new Rover(this);
		}

		public void SendRoverToMars (Mars mars, Rover rover)
		{
			if (mars == null)
				throw new ArgumentNullException("mars");

			if (rover == null)
				throw new ArgumentNullException("rover");

			mars.Rovers.Add (rover);
		}
	}
}


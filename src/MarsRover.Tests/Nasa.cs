using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests
{
	public class Nasa : ISpaceAgency
	{
		private Dictionary<string, Bitmap> _photos;
		public Dictionary<string,Bitmap> Photos { get{ return _photos; } }

		public Nasa ()
		{
			_photos = new Dictionary<string, Bitmap> ();
		}

		public IRover CreateRover ()
		{
			return new Rover(this, new Camera());
		}

		public void SendRoverToMars (IPlanet mars, IRover rover)
		{
			if (mars == null)
				throw new ArgumentNullException("mars");

			if (rover == null)
				throw new ArgumentNullException("rover");

			mars.Rovers.Add (rover);
		}
	}
}


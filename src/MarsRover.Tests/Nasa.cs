using System;

namespace MarsRover.Tests
{
	public class Nasa
	{
		public Rover CreateRover ()
		{
			return new Rover();
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


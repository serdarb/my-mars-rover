using System;
using System.Collections.Generic;

namespace MarsRover.Tests
{
	public class Mars
	{
		public Plateau Plateau {
			get;
			set;
		}

		public List<Rover> Rovers {
			get;
			set;
		}

		public Mars ()
		{
			Rovers = new List<Rover> ();
		}
	}
}


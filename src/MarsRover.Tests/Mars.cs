using System;
using System.Collections.Generic;

namespace MarsRover.Tests
{
	public class Mars : IPlanet
	{
		public Plateau Plateau {
			get;
			set;
		}

		public List<IRover> Rovers {
			get;
			set;
		}

		public Mars ()
		{
			Rovers = new List<IRover> ();
		}
	}
}


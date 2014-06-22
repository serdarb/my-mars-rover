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

		private List<IRover> _rovers;
		public List<IRover> Rovers { get { return _rovers; } }

		public Mars ()
		{
			_rovers = new List<IRover> ();
		}
	}
}


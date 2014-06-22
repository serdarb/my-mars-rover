using System.Collections.Generic;

using MarsRover.Business.Contract;

namespace MarsRover.Business.Domain
{
	public class Mars : IPlanet
	{
		public IPlateau Plateau { get; set;	}

		private List<IRover> _rovers;
		public List<IRover> Rovers { get { return _rovers; } }

		public Mars ()
		{
			_rovers = new List<IRover> ();
		}
	}
}
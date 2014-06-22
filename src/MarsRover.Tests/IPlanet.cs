using System.Collections.Generic;

namespace MarsRover.Tests
{
	public interface IPlanet
	{
		Plateau Plateau { get; set;	}
		List<IRover> Rovers { get;	}
	}
}
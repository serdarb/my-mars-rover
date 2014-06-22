using System.Collections.Generic;

namespace MarsRover.Business.Contract
{
	public interface IPlanet
	{
		IPlateau Plateau { get; set;	}
		List<IRover> Rovers { get;	}
	}
}
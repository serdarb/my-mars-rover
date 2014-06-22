using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests
{
	public interface ISpaceAgency
	{
		Dictionary<string,Bitmap> Photos { get; }

		IRover CreateRover ();

		void SendRoverToMars (IPlanet mars, IRover rover);
	}
}


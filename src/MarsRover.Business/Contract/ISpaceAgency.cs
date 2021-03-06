using System.Drawing;
using System.Collections.Generic;

namespace MarsRover.Business.Contract
{
	public interface ISpaceAgency
	{
		Dictionary<string, Bitmap> Photos { get; }

		IRover CreateRover ();
		ISpaceStation CreateSpaceStation ();
		void SendRoverToMars (IPlanet mars, IRover rover);
		void SendCommandsToSpaceStation (ISpaceStation spaceStation, string commands);
	}
}
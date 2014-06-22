using System;

using MarsRover.Business.Domain;

namespace MarsRover.Presentation
{
	class MainClass
	{
		const string NAVIGATION_COMMAND = @"5 5
											1 2 N
											LMLMLMLMM
											3 3 E
											MMRMMRMRRM";

		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			var nasa = new Nasa ();
			var station = nasa.CreateSpaceStation ();	

			for (int i = 0; i < 3; i++) {
				nasa.SendRoverToMars (station.Mars, nasa.CreateRover ());
			}

			nasa.SendCommandsToSpaceStation(station, NAVIGATION_COMMAND);
			station.StartResearching ();

			Console.Read();
		}
	}
}

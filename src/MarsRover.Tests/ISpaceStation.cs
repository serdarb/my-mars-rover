using System;
using System.Collections.Generic;

namespace MarsRover.Tests
{
	public interface ISpaceStation
	{
		IPlanet Mars { get; }
		Queue<string> UnprocessedCommands { get; }
		Queue<ResearchInfo> ResearchInfos {	get; }

		void ValidateCommandsAndEnqueueResearchInfos ();
		Plateau DefinePlateau (int width, int height);
	}
}
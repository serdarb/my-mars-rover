using System;
using System.Collections.Generic;

namespace MarsRover.Tests
{
	public interface ISpaceStation
	{
		Queue<string> UnprocessedCommands { get; }
		Queue<ResearchInfo> ResearchInfos {	get; }

		void ValidateCommandsAndEnqueueResearchInfos ();
		Plateau DefinePlateau (int width, int height);
	}
}
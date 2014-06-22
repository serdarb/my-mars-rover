using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests
{
	public interface ISpaceStation
	{
		Queue<string> UnprocessedCommands { get; }
	}
}


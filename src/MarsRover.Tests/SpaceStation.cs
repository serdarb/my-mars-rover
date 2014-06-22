using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests
{
	public class SpaceStation : ISpaceStation
	{
		private Queue<string> _unprocessedCommands;
		public Queue<string> UnprocessedCommands {
			get {
				return _unprocessedCommands;
			}
		}

		public SpaceStation ()
		{
			_unprocessedCommands = new Queue<string> ();
		}

	}
}

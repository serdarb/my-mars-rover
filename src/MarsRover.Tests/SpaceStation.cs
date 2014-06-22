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

		private Queue<ResearchInfo> _researchInfos;
		public Queue<ResearchInfo> ResearchInfos {
			get {
				return _researchInfos;
			}
		}

		public IPlanet Mars {
			get { return _mars; }
		}

		private CommandParser _commandParser;
		private IPlanet _mars;
		public SpaceStation (IPlanet mars, CommandParser commandParser)
		{
			_mars = mars;
			_commandParser = commandParser;

			_unprocessedCommands = new Queue<string> ();
			_researchInfos = new Queue<ResearchInfo> ();
		}

		public void ValidateCommandsAndEnqueueResearchInfos ()
		{
			while (UnprocessedCommands.Count > 0) {
				var command = UnprocessedCommands.Dequeue ();

				if (Mars == null) {
					throw new Exception ("space station should connect to mars");
				}

				if (Mars.Plateau == null) {
					var plateauMetrics = _commandParser.GetPlateauMetrics (command);
					Mars.Plateau = DefinePlateau (plateauMetrics[0], plateauMetrics[1]);
				}

				var researchInfos = _commandParser.GetResearchInfos (command);
				foreach (var info in researchInfos) {
					ResearchInfos.Enqueue (info);
				}
			}
		}

		public Plateau DefinePlateau (int width, int height)
		{
			return new Plateau(width, height);
		}
	}

}

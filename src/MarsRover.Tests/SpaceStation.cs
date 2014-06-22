using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
					Mars.Plateau = DefinePlateau (plateauMetrics [0], plateauMetrics [1]);
				}

				var researchInfos = _commandParser.GetResearchInfos (command);
				foreach (var info in researchInfos) {
					ResearchInfos.Enqueue (info);
				}
			}
		}

		public Plateau DefinePlateau (int width, int height)
		{
			return new Plateau (width, height);
		}

		public bool StartResearching ()
		{
			if (ResearchInfos.Count == 0)
				throw new Exception ("there is no research info to run rovers");

			DoNextResearch ();

			return true;
		}

		void roverResearchEnded (object sender, EventArgs e)
		{
			var args = (ResearchEndedEventArgs)e;
			Console.WriteLine ("rover research ended > " + args.Position);
			DoNextResearch ();
		}

		private void DoNextResearch ()
		{
			if (ResearchInfos.Count == 0) {
				Console.WriteLine ("all researches completed...");
				return;
			}

			var researchInfo = ResearchInfos.Dequeue ();
			var rover = ConnectToRover ();
			rover.ResearchEnded += roverResearchEnded;
			rover.Research (researchInfo);
		}

		IRover ConnectToRover ()
		{
			if (Mars.Rovers.Count == 0)
				throw new Exception ("there is no rover on mars");

			var rover = Mars.Rovers.FirstOrDefault (x => !x.IsResearching);
			if (rover == null)
				throw new Exception ("all rovers are busy please try again later");


			rover.IsResearching = true;
			return rover;
		}
	}
}

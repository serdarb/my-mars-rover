using MarsRover.Business.Contract;

namespace MarsRover.Business.Domain
{
	public class ResearchInfo : IResearchInfo
	{
		public	string RoverPosition { get; set; }
		public	string RoverExploration { get; set;	}
	}
}
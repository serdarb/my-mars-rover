using MarsRover.Business.Contract;

namespace MarsRover.Business.Domain
{
	public class Location : ILocation
	{
		public int X { get; set; }
		public int Y { get; set; }
	}
}

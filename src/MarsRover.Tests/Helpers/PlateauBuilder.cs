using System;
using Moq;

namespace MarsRover.Tests
{

	public class PlateauBuilder
	{
		public PlateauBuilder ()
		{

		}

		internal Plateau Build()
		{
			return new Plateau(5,5);
		}
	}
}
using System;

using Moq;

using MarsRover.Business.Contract;
using MarsRover.Business.Domain;

namespace MarsRover.Tests
{
	public class PlateauBuilder
	{
		public PlateauBuilder ()
		{

		}

		internal IPlateau Build()
		{
			return new Plateau(5,5);
		}
	}
}
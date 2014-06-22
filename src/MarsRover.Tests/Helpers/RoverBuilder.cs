using System;

using Moq;

using MarsRover.Business.Contract;
using MarsRover.Business.Domain;

namespace MarsRover.Tests
{
	public class RoverBuilder
	{
		ISpaceAgency _spaceAgency;
		ICamera _camera;

		public RoverBuilder ()
		{
			_spaceAgency = new Mock<ISpaceAgency> ().Object;
			_camera = new Mock<ICamera> ().Object;
		}

		internal RoverBuilder WithSpaceAgency(ISpaceAgency spaceAgency)
		{
			_spaceAgency = spaceAgency;
			return this;
		}

		internal RoverBuilder WithCamera(ICamera camera)
		{
			_camera = camera;
			return this;
		}

		internal IRover Build()
		{
			return new Rover(_spaceAgency, _camera);
		}
	}
}
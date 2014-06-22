using System;
using NUnit.Framework;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace MarsRover.Tests
{
	[TestFixture]
	public class DomainDesignTests
	{
		protected WindsorContainer _container;

		[SetUp]
		public void SetUp()
		{
			_container = new WindsorContainer();

			_container.Register(Component.For<IPlanet>().ImplementedBy<Mars>());
			_container.Register(Component.For<IPlateau>().ImplementedBy<Plateau>());
			_container.Register(Component.For<ISpaceAgency>().ImplementedBy<Nasa>());
		}

		[Test]
		public void mars_should_have_a_rectengular_plataeu()
		{
			var mars = _container.Resolve<IPlanet>();
			mars.Plateau = new Plateau();

			Assert.IsNotNull (mars.Plateau);
			Assert.IsInstanceOf (typeof(Rectangular), mars.Plateau);
		}

		[Test]
		public void nasa_should_land_rovers_on_mars()
		{
			var nasa = _container.Resolve<ISpaceAgency>();
			var rover = nasa.CreateRover ();
			var mars = _container.Resolve<IPlanet>();

			Assert.IsNotNull (mars.Rovers);

			int oldRoverCount = mars.Rovers.Count;
			nasa.SendRoverToMars (mars, rover);
			int newRoverCount = mars.Rovers.Count;

			Assert.AreEqual (oldRoverCount + 1, newRoverCount);
		}

		[Test]
		public void rover_camera_should_take_a_photo()
		{
			var nasa = _container.Resolve<ISpaceAgency>();
			var rover = nasa.CreateRover ();

			Assert.IsNotNull (rover.Camera);
			Assert.IsNotNull (rover.Photos);

			int oldPhotoCount = rover.Photos.Count;
			rover.TakePhoto ();
			int newPhotoCount = rover.Photos.Count;

			Assert.AreEqual (oldPhotoCount + 1, newPhotoCount);
		}

		[Test]
		public void rover_should_send_photos_to_nasa()
		{
			var nasa = _container.Resolve<ISpaceAgency>();
			var rover = nasa.CreateRover ();

			rover.TakePhoto ();

			int oldPhotoCount = rover.Photos.Count;
			rover.SendPhotosToNasa ();
			int newPhotoCount = rover.Photos.Count;

			Assert.AreEqual (0, newPhotoCount);
		}

		[Test]
		public void rover_should_have_compasspoint_position_and_x_y_coordinate_location()
		{
			var rover = new RoverBuilder ().Build ();

			rover.Position = CompassPoint.North;
			rover.Location = new Location { X=0,Y=0};

			Assert.IsNotNull (rover.Position);
			Assert.IsNotNull (rover.Location);
			Assert.AreEqual (rover.Position, CompassPoint.North);
			Assert.AreEqual (rover.Location.X, 0);
			Assert.AreEqual (rover.Location.Y, 0);
		}
	}
}



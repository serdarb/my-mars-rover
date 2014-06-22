using System;
using NUnit.Framework;

namespace MarsRover.Tests
{
	[TestFixture]
	public class DomainDesignTests
	{
		[Test]
		public void mars_should_have_a_rectengular_plataeu()
		{
			var mars = new Mars ();
			mars.Plateau = new Plateau ();

			Assert.IsNotNull (mars.Plateau);
			Assert.IsInstanceOf (typeof(Rectangular), mars.Plateau);
		}

		[Test]
		public void nasa_should_land_rovers_on_mars()
		{
			var nasa = new Nasa ();
			var rover = nasa.CreateRover ();
			var mars = new Mars ();

			Assert.IsNotNull (mars.Rovers);

			int oldRoverCount = mars.Rovers.Count;
			nasa.SendRoverToMars (mars, rover);
			int newRoverCount = mars.Rovers.Count;

			Assert.AreEqual (oldRoverCount + 1, newRoverCount);
		}

		[Test]
		public void rover_camera_should_take_a_photo()
		{
			var nasa = new Nasa ();
			var rover = nasa.CreateRover ();
			rover.Camera = new Camera ();

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
			var nasa = new Nasa ();
			var rover = nasa.CreateRover ();

			rover.TakePhoto ();

			int oldPhotoCount = rover.Photos.Count;
			rover.SendPhotosToNasa ();
			int newPhotoCount = rover.Photos.Count;

			Assert.AreEqual (0, newPhotoCount);
		}
	}
}


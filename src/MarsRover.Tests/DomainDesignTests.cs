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

			Assert.That (mars, Has.Property("Plateau"));
			Assert.IsNotNull (mars.Plateau);
			Assert.IsInstanceOf (typeof(Rectangular), mars.Plateau);
		}

		[Test]
		public void nasa_should_land_rovers_on_mars()
		{
			var nasa = new Nasa ();
			var rover = nasa.CreateRover ();

			var mars = new Mars ();

			int oldRoverCount = mars.Rovers.Count;
			nasa.SendRoverToMars (mars, rover);
			int newRoverCount = mars.Rovers.Count;

			Assert.IsNotNull (mars.Rovers);
			Assert.AreEqual (oldRoverCount + 1, newRoverCount);
		}

	}
}


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
	}
}


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
			mars.Plataeu = new Plataue ();

			Assert.That (mars, Has.Property("Plataeu"));
			Assert.IsNotNull (mars.Plataeu);
			Assert.IsInstanceOf (typeof(Rectangular), mars.Plataeu);
		}
	}
}


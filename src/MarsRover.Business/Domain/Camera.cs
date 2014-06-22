using System.Drawing;

using MarsRover.Business.Contract;

namespace MarsRover.Business.Domain
{
	public class Camera : ICamera
	{
		public Bitmap TakePhoto ()
		{
			return new Bitmap(100, 100);
		}
	}
}
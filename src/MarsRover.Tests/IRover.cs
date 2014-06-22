using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests
{
	public interface IRover
	{
		string Name { get;}
		ICamera Camera {get;}
		Dictionary<string,Bitmap> Photos { get; }

		void TakePhoto ();
		void SendPhotosToNasa ();
	}
}


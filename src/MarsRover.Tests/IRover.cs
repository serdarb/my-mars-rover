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
		CompassPoint Position{ get;	set; }
		Location Location {	get; set; }

		void TakePhoto ();
		void SendPhotosToNasa ();

		bool Spin (char spiningSide);
		bool MoveForward ();
	}
}


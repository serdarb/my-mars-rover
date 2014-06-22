using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests
{
	public interface IRover
	{
		event ResearchEndedEventHandler ResearchEnded;

		string Name { get;}
		bool IsResearching {	get; set; }
		ICamera Camera {get;}
		Dictionary<string,Bitmap> Photos { get; }
		CompassPoint Position{ get;	set; }
		Location Location {	get; set; }

		void TakePhoto ();
		void SendPhotosToNasa ();

		bool Spin (char spiningSide);
		bool MoveForward ();

		void Research (ResearchInfo researchInfo);
	}
}


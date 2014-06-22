using System;
using System.Drawing;
using NUnit.Framework;
using System.Collections.Generic;

namespace MarsRover.Tests
{
	public class Rover
	{
		public string Name {
			get;
			set;
		}

		public Camera Camera {
			get;
			set;
		}

		public Dictionary<string,Bitmap> Photos {
			get;
			set;
		}

		private Nasa _nasa;
		public Rover (Nasa nasa)
		{
			_nasa = nasa;

			Name = Guid.NewGuid ().ToString ();
			Camera = new Camera ();
			Photos = new Dictionary<string,Bitmap> ();
		}

		public void TakePhoto ()
		{
			var image = Camera.TakePhoto ();
			var imagaName = string.Format ("{0}-{1}.bmp",Name,Guid.NewGuid().ToString());
			Photos.Add (imagaName, image);
		}

		public void SendPhotosToNasa ()
		{
			foreach (var item in Photos) {
				_nasa.Photos.Add (item.Key,item.Value);
			}		

			Photos.Clear ();
		}
	}
}


using System;
using System.Collections.Generic;
using System.Drawing;

namespace MarsRover.Tests
{
	public class Rover : IRover
	{
		private string _name;

		public string Name {
			get{ return _name; }
		}

		public CompassPoint Position {
			get;
			set;
		}

		public Location Location {
			get;
			set;
		}

		private ICamera _camera;

		public ICamera Camera {
			get{ return _camera; }
		}

		private Dictionary<string,Bitmap> _photos;

		public Dictionary<string,Bitmap> Photos {
			get{ return _photos; }
		}

		private Rover ()
		{
			
		}

		private ISpaceAgency _nasa;

		public Rover (ISpaceAgency nasa, ICamera camera)
		{
			_nasa = nasa;
			_camera = camera;
			_name = Guid.NewGuid ().ToString ();
			_photos = new Dictionary<string,Bitmap> ();

			Location = new Location { X = 0, Y = 0 };
		}

		public void TakePhoto ()
		{
			var image = Camera.TakePhoto ();
			var imagaName = string.Format ("{0}-{1}.bmp", Name, Guid.NewGuid ().ToString ());
			Photos.Add (imagaName, image);
		}

		public void SendPhotosToNasa ()
		{
			foreach (var item in Photos) {
				_nasa.Photos.Add (item.Key, item.Value);
			}		

			Photos.Clear ();
		}

		public bool Spin (char spiningSide)
		{
			var positionChar = Position.ToString () [0];
			switch (spiningSide) {
				case 'L':
				SpinLeft (positionChar);
					break;
				case 'R':
				SpinRight (positionChar);
					break;
				default:
					throw new ArgumentException ("not valid spiningSide");					
			}

			return true;
		}

		private void SpinLeft (char direction)
		{
			var lookupTable = new Dictionary<char, CompassPoint> {
				{'N', CompassPoint.West},
				{'W', CompassPoint.South},
				{'S', CompassPoint.East},
				{'E', CompassPoint.North}
			};
			Position = lookupTable [direction];
		}

		private void SpinRight (char direction)
		{
			var lookupTable = new Dictionary<char, CompassPoint> {
				{'N', CompassPoint.East},
				{'W', CompassPoint.North},
				{'S', CompassPoint.West},
				{'E', CompassPoint.South}
			};
			Position = lookupTable [direction];
		}

		public bool MoveForward ()
		{
			Location.Y++;
			return true;
		}
	}
}


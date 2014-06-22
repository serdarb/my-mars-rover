using System;

namespace MarsRover.Tests
{
	public class ResearchEndedEventArgs : EventArgs
	{
		private string _position;
		public string Position
		{
			get
			{
				return _position;
			}
		}

		public ResearchEndedEventArgs(string position)
		{
			_position = position;
		}
	}
}

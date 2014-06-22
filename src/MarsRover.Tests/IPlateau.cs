namespace MarsRover.Tests
{
	public interface IPlateau
	{
		int Bottom { get; }
		int Left { get; }
		int Right { get; }
		int Top { get; }

		object[,] Grid { get; }
	}
}
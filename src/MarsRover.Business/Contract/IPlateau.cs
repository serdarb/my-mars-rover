namespace MarsRover.Business.Contract
{
	public interface IPlateau : IRectangular
	{
		int Bottom { get; }
		int Left { get; }
		int Right { get; }
		int Top { get; }

		object[,] Grid { get; }
	}
}
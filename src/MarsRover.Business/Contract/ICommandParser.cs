using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRover.Business.Contract
{
	public interface ICommandParser
	{
		bool IsValid (string[] commands);
		bool IsNotValid (string[] commands);
		string[] SplitCommandString (string command);
		List<IResearchInfo> GetResearchInfos (string command);
		List<int> GetPlateauMetrics (string command);
	}
}
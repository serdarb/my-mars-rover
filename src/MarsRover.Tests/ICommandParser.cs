using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MarsRover.Tests
{
	public interface ICommandParser
	{
		bool IsValid (string[] commands);
		bool IsNotValid (string[] commands);
		string[] SplitCommandString (string command);
		List<ResearchInfo> GetResearchInfos (string command);
	}
}

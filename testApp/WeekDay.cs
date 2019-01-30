using System;
using System.Collections.Generic;

namespace testApp
{
	internal class WeekDay
	{
		internal Dictionary<string, List<string>> wdayDict = new Dictionary<string, List<string>>();

		internal WeekDay()
		{
			string[] days = {"mon", "tue", "wed", "thu", "fri", "sat", "sun"} ;
			foreach (var day in days)
			{
				wdayDict[day] = new List<string>();
			}

		}

		internal void dayAdd(string day, string name)
		{
			wdayDict[day.ToLower()].Add(name);
		}

		internal string getString(string day)
		{
			return String.Join(", ", wdayDict[day].ToArray());
		}
	}
}

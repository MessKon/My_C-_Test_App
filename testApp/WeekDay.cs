using System;
using System.Collections.Generic;

namespace testApp
{
	//Class to represent customers demanding material on Week days
	internal class WeekDay
	{
		//Implemented as a Dictionary with string keys and list values
		internal Dictionary<string, List<string>> wdayDict = new Dictionary<string, List<string>>();

		//Constructor
		internal WeekDay()
		{
			string[] days = {"mon", "tue", "wed", "thu", "fri", "sat", "sun"} ;
			foreach (var day in days)
			{
				wdayDict[day] = new List<string>();
			}

		}

		//Append a new customer to a Week day list
		internal void dayAdd(string day, string name)
		{
			wdayDict[day.ToLower()].Add(name);
		}

		//Return content of a week day list as a string
		internal string getString(string day)
		{
			return String.Join(", ", wdayDict[day].ToArray());
		}
	}
}

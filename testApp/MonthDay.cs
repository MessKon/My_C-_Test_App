using System;
using System.Collections.Generic;

namespace testApp
{
	//Class to represent customers demanding material on Month dates
	internal class MonthDay
	{
		//Implemented as Array of string Lists
		internal List<string>[] mdayList;

		//Constructor
		internal MonthDay()
		{
			mdayList = new List<string>[31];
			for (int i=0; i<31;i++)
                        {
				mdayList[i]= new List<string>();
			}
		}

		//Append a customer to a Month date list
		internal void dateAdd(int date,string name)
		{
			mdayList[date-1].Add(name);
		}

		//Return content of a Month date list as a string
		internal string getString(int date)
		{
			return String.Join(", ", mdayList[date].ToArray());
		}
	}
}

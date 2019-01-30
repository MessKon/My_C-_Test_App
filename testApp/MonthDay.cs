using System;
using System.Collections.Generic;

namespace testApp
{
	internal class MonthDay
	{
		internal List<string>[] mdayList;

		internal MonthDay()
		{
			mdayList = new List<string>[31];
			for (int i=0; i<31;i++)
                        {
				mdayList[i]= new List<string>();
			}
		}

		internal void dateAdd(int date,string name)
		{
			mdayList[date-1].Add(name);
		}

		internal string getString(int date)
		{
			return String.Join(", ", mdayList[date].ToArray());
		}
	}
}

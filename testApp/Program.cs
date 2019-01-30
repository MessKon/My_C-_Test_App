using System;
using System.Collections.Generic;

namespace testApp
{
	class Program
	{
		static void Main(string[] args)
		{
			int start_day_offset = 1;
			int end_day_offset   = 90;

			List<string> DailyList = new List<string>();

			MonthDay MDay = new MonthDay();
			MDay.dateAdd(6,"Bingo Cust");
			MDay.dateAdd(6,"Zumba Cust");
			MDay.dateAdd(5,"Super Cust");

			WeekDay WDay = new WeekDay();
			WDay.dayAdd("WEd","Lola Cust");

			bool to_txt = My_Input.Get_input(DailyList, WDay, MDay);

			string output= "";
			for (int i= start_day_offset; i< end_day_offset;i++)
			{
				var    current_date = DateTime.Now.AddDays(i);
				int    date_number  = current_date.Day;
				string date_weekday = current_date.ToString("ddd");

				List<string> customers = new List<string>();
				customers.AddRange(MDay.mdayList[date_number-1]); 
				customers.AddRange(WDay.wdayDict[date_weekday.ToLower()]);
				customers.AddRange(DailyList);
 
				output += current_date.ToString("ddd, dd MMMM yyyy") + ": "+  String.Join(", ", customers.ToArray()) + System.Environment.NewLine;
			}

			if (to_txt)
			{
				My_Output.Print_file(output);
			}
			else
			{
				My_Output.Print_console(output);
			}
		}
	}
}

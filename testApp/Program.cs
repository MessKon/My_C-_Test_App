using System;
using System.Collections.Generic;

namespace testApp
{
	//Main Program Class
	class Program
	{
		//Main function
		static void Main(string[] args)
		{
			int start_day_offset = 1;
			int end_day_offset   = 91;

			//Initialise our 3 Structures
			List<string> DailyList = new List<string>();
			MonthDay MDay = new MonthDay();
			WeekDay WDay = new WeekDay();

			//Populate the Structurs and decide on output stream
			bool to_txt = My_Input.Get_input(DailyList, WDay, MDay);

			//Conduct output string
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

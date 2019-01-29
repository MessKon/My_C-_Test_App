using System;
using System.Collections.Generic;

namespace testApp
{
	class My_Output
	{
		internal static void Print_console(string some_output)
		{
			Console.WriteLine(some_output);
		}

		internal static void Print_file(string some_output)
		{
			System.IO.File.WriteAllText(@"./out_file.txt", some_output);
			Console.WriteLine("Output written in out_file.txt in the current directory");
		}
	}

	//class My_Input
	//might not need a class Daily
	//class WeekDay
	class MonthDay
	{
		internal List<string>[] mdayList;

		internal MonthDay()
		{
			mdayList = new List<string>[28];
			for (int i=0; i<28;i++)
                        {
				mdayList[i]= new List<string>();
			}
		}

		internal void dateAdd(int date,string name)
		{
			mdayList[date].Add(name);
		}

		internal string getString(int date)
		{
			return String.Join(", ", mdayList[date].ToArray());
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			List<string> DailyList = new List<string>();

			MonthDay MDay = new MonthDay();
			MDay.dateAdd(6,"Bingo Cust");
			MDay.dateAdd(6,"Zumba Cust");
			MDay.dateAdd(5,"Super Cust");
			string output= "";
			for (int i=4; i<12;i++)
			{
				output += DateTime.Now.AddDays(i).ToString("ddd, dd MMMM yyyy") + ": "+  MDay.getString(i) + System.Environment.NewLine;
			}
			//My_Output.Print_console(output);
			My_Output.Print_file(output);
		}
	}
}

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
	//class Every
	//class WeekDay
	//class MonthDay
	class Program
	{
		static void Main(string[] args)
		{
			var names = new List<string> { "<name>", "Ana", "Felipe" };
			//foreach (var name in names)
			//{
			//	Console.WriteLine($"Hello {name.ToUpper()}!");
			//}
			string output= "";
			for (int i=4; i<12;i++)
			{
				output += DateTime.Now.AddDays(i).ToString("ddd, dd MMMM yyyy") + ": some customers" + System.Environment.NewLine;
				//Console.WriteLine(DateTime.Now.AddDays(i).ToString("ddd, dd MMMM yyyy") + ": some customers");
			}
			//My_Output.Print_console(output);
			My_Output.Print_file(output);
		}
	}
}

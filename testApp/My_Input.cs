using System;
using System.Collections.Generic;

namespace testApp
{
	internal class My_Input
	{
		private static void  Print_Initial_Message()
		{
			Console.WriteLine("Hello dear User,");
			Console.WriteLine("This is an app for generating a report on when to send marketing material");
			Console.WriteLine("based on customers' preference");
			Console.WriteLine();
			Console.WriteLine("In terms of the customer preference format");

		}

		private static void  Print_Valid_Input_Format()
		{
			Console.WriteLine("Each customer can go for one of the options below:");
			Console.WriteLine("'Every day' if he wishes to receive material every day");
			Console.WriteLine("'Every <X>th' if he wishes to receive material on the <X>th of every month (e.g. 'Every 9th')");
			Console.WriteLine("'Every <Weekday>' if he wishes to receive material on each of that <Weekday> (e.g 'Every Thursday')");
			Console.WriteLine("or 'Never' if he wishes not to receive material");
			//Console.WriteLine();
		}

		private static string Get_customer()
		{
			Console.WriteLine("Please provide the next customer's name:");
			string name = Console.ReadLine();
			return name;
		}
		
		private static string Get_preference(string name)
		{
			Console.WriteLine("What is {0}'s preference?", name);
			string pref = Console.ReadLine();
			return pref;
		}

		internal static bool Get_input(List<string> Daily_list, WeekDay WDay, MonthDay MDay)
		{
			Print_Initial_Message();
			Print_Valid_Input_Format();

			bool end = false;
			while (!end)
			{
				Console.WriteLine();
				Console.WriteLine("Please, enter 'Q' if you want to stop providing customer data");
				Console.WriteLine("Or any other input to keep on");
				string end_choice = Console.ReadLine();
				
				if(string.Equals(end_choice, "Q"))
				{
					end = true;
				}
				else
				{
					string customer_name = Get_customer();
					string preference    = Get_preference(customer_name);
					if (string.Equals(preference.ToLower(), "every day"))
					{
						Daily_list.Add(customer_name);
					}
					//else if ()
					//{
					//}
					//else if
					//{
					//}
					else if(string.Equals(preference.ToLower(), "never"))
					{
					}
					else
					{
						Console.WriteLine();
						Console.WriteLine("Sorry, the provided preference input is not valid");
						Console.WriteLine("You would need to re-attempt providing input for customer '{0}'", customer_name);
						Console.WriteLine("Reminding the valid preference input format");
						Console.WriteLine();
						Print_Valid_Input_Format();
					} 
				}
				
			}
			
			Console.WriteLine();
			Console.WriteLine("Now please, enter 'P' if you want the output written in a txt file");
			Console.WriteLine("Or any other input if you want it displayed in the console:");
			string out_choice = Console.ReadLine();
			Console.WriteLine();

			return string.Equals(out_choice, "P");
		}

	}
}

using System;
using System.Collections.Generic;

namespace testApp
{
	//Class for Input receiving
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
		}

		//Receive a customer's name
		private static string Get_customer()
		{
			Console.WriteLine("Please provide the next customer's name:");
			string name = Console.ReadLine();
			return name;
		}
		
		//Receive a customer's preference
		private static string Get_preference(string name)
		{
			Console.WriteLine("What is {0}'s preference?", name);
			string pref = Console.ReadLine();
			return pref;
		}

		//Check if Input provided has a valid format for a demand on one or multiple Weekdays
		private static List<string> checkWeekDay(string input)
		{
			List<string> result = new List<string>();

			if (input.Length < 11)
			{
				return result;
			}

			string first_half = input.Substring(0,5).ToLower();
			string second_half = input.Substring(6).ToLower();

			List<string> weekdays = new List<string> (new string[] {"monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"});

			if (string.Equals(first_half,"every"))
			{
				for (int i= 0; i< 7;i++)
				{
					if (second_half.Contains(weekdays[i]))
					{
						result.Add(weekdays[i].Substring(0,3));
					}
				}
			}

			return result;
		}

		//Check if Input provided has a valid format for a demand on a Month Date [1-28]
		private static int checkMonthDay(string input)
		{
			if (input.Length < 10)
			{
				return 0;
			}

			string first_half = input.Substring(0,5).ToLower();
			string second_half = input.Substring(6).ToLower();
			string last_part = second_half.Substring(second_half.Length-2).ToLower();
			string num_part = second_half.Remove(second_half.Length-2);

			List<string> valid_endings = new List<string> (new string[] {"st", "nd", "rd", "th"});

			if (valid_endings.Contains(last_part))
			{
				int num = 0;
				if( Int32.TryParse(num_part, out num) )
				{
					if (num > 0 && num < 29)
					{
						return num;
					}
					else
					{
						Console.WriteLine();
						Console.WriteLine("Sorry, accepted dates are only 1st to 28th!!");
						Console.WriteLine();
					}
				}
			}

			return 0;
		}

		//Function to help receive the input and populate the structures if format is appropriate
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
					bool valid = true;
					string customer_name = Get_customer();
					string preference    = Get_preference(customer_name);
					int isDate = checkMonthDay(preference);
					List<string> cust_weekdays = checkWeekDay(preference);

					if (string.Equals(preference.ToLower(), "every day"))
					{
						Daily_list.Add(customer_name);
					}
					else if (cust_weekdays.Count != 0)
					{
						foreach (string wday in cust_weekdays)
						{
							WDay.dayAdd(wday,customer_name);
						}
					}
					else if (isDate > 0)
					{
						MDay.dateAdd(isDate,customer_name);
					}
					else if(string.Equals(preference.ToLower(), "never"))
					{
					}
					else
					{
						valid = false;
						Console.WriteLine();
						Console.WriteLine("Sorry, the provided preference input is not valid");
						Console.WriteLine("You would need to re-attempt providing input for customer '{0}'", customer_name);
						Console.WriteLine("Reminding the valid preference input format");
						Console.WriteLine();
						Print_Valid_Input_Format();
					} 
					if (valid)
					{
						Console.WriteLine();
						Console.WriteLine("Customer '{0}' was added to the System.",customer_name);
						Console.WriteLine();
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

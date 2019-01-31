using System;
using System.Collections.Generic;

namespace testApp
{
	//Class to manage printing the output
	internal class My_Output
	{
		//Print to Console
		internal static void Print_console(string some_output)
		{
			Console.WriteLine(some_output);
		}

		//Print to a .txt under the same dir
		internal static void Print_file(string some_output)
		{
			System.IO.File.WriteAllText(@"./report_file-"+ DateTime.Now.ToString("yyyyMMddHHmmssfff") +".txt", some_output);
			Console.WriteLine("Output written in report_file-"+ DateTime.Now.ToString("yyyyMMddHHmmssfff") +".txt in the current directory");
		}
	}
}

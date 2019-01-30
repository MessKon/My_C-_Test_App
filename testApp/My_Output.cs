using System;
using System.Collections.Generic;

namespace testApp
{
	internal class My_Output
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
}

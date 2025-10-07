using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Program
{
	private static void Main(string[] args)
	{
		// Stack based Class
		StringHistory sh = new("Items: ");

		#region Stack
		{
			Console.WriteLine($"1) Starting String: {sh}");
			sh.Append("New Item");
			sh.Append(", New Item2");
			sh.Append(", New Item3");
			sh.Append(", New Item4");
			sh.Append(", New Item5");
			sh.Append(", New Item6");
			sh.Append(", New Item78");

			Console.WriteLine($"1A) Current String After Appends: {sh}");

			sh.DeleteLastChar();

			Console.WriteLine($"1B) Current String After Deleting Last Character: {sh}");

			sh.Undo();

			Console.WriteLine($"1C) Current String After Undoing Last Operation: {sh}");

		}
		#endregion

		#region Queue
		{

		}
		#endregion
	}

}
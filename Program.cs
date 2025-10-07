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

		Console.WriteLine();

		#region Queue
		{
			PrintJobs pj = new();

			Console.WriteLine($"2) Starting With No Jobs.");

			pj.Enqueue("Stealing personal data...");
			pj.Enqueue("Subscribing to scam websites...");
			pj.Enqueue("Pinging the blockchain...");
			pj.Enqueue("Undoing all your hard work...");
			pj.Enqueue("Creating backdoor in your code...");

			Console.WriteLine($"2A) Added 5 jobs using Enqueue Method.\n\t{pj}");

			Console.WriteLine($"2B) Processing Jobs.");

			Console.WriteLine($"2B-1) Processing Next Job.");
			Console.Write("\t");
			pj.HandleNextJob();

			Console.WriteLine($"2B-2) Processing Next Job.");
			Console.Write("\t");
			pj.HandleNextJob();

			Console.WriteLine($"2B-3) Processing Next Job.");
			Console.Write("\t");
			pj.HandleNextJob();

			Console.WriteLine($"2B-4) Processing Next Job.");
			Console.Write("\t");
			pj.HandleNextJob();

			Console.WriteLine($"2B-5) Processing Next Job.");
			Console.Write("\t");
			pj.HandleNextJob();

			Console.WriteLine($"2B) Remaining Jobs:\n\t{pj}.");

			Console.WriteLine($"2C) Processing Next Job that doesn't exist.");
			pj.HandleNextJob();

		}
		#endregion
	}

}
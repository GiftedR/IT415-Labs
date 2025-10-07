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

		Console.WriteLine();

		#region Performance
		{
			const int itemCount = 100_000;
			Console.WriteLine($"3) Starting Stack vs Queue Performance with {itemCount} items.");
			Queue<int> perfQueue = new();
			Stack<int> perfStack = new();
			Stopwatch sw = new();
			TimeSpan queueTime = new();
			TimeSpan stackTime = new();

			sw.Start();
			for (int idx = 0; idx < itemCount; idx++)
				perfQueue.Enqueue(idx);
			sw.Stop();

			Console.WriteLine($"3A) {itemCount}x Enqueue Time: {sw.Elapsed}");
			queueTime += sw.Elapsed;

			sw.Restart();
			for (int idx = 0; idx < itemCount; idx++)
				perfQueue.Dequeue();
			sw.Stop();

			Console.WriteLine($"3B) {itemCount}x Dequeue Time: {sw.Elapsed}");
			queueTime += sw.Elapsed;
			Console.WriteLine($"3C) {itemCount * 2}x Total Queue Time: {queueTime}");

			sw.Restart();
			for (int idx = 0; idx < itemCount; idx++)
				perfStack.Push(idx);
			sw.Stop();

			Console.WriteLine($"3D) {itemCount}x Stack Push Time: {sw.Elapsed}");
			stackTime += sw.Elapsed;

			sw.Restart();
			for (int idx = 0; idx < itemCount; idx++)
				perfStack.Pop();
			sw.Stop();

			Console.WriteLine($"3E) {itemCount}x Stack Pop Time: {sw.Elapsed}");
			stackTime += sw.Elapsed;
			Console.WriteLine($"3F) {itemCount * 2}x Total Stack Time: {stackTime}");
			Console.WriteLine($"\n3G) These tests show that the {(stackTime == queueTime ? "stack and queue are the same" : (stackTime < queueTime ? "stack is faster" : "queue is faster"))}.\n\tStack: {stackTime}\n\tQueue: {queueTime}");

		}
		#endregion
	}

}
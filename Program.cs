using System.Diagnostics;

internal class Program
{
	private static void Main(string[] args)
	{
		int[] onekarray = new int[1000];
		int[] tenkarray = new int[10000];
		int[] hundredkarray = new int[100000];

		TimeSpan onekconstanttime = new();
		TimeSpan tenkconstanttime = new();
		TimeSpan hundredkconstanttime = new();

		Stopwatch sw = new();

		sw.Start();
		FirstElement(onekarray);
		sw.Stop();
		onekconstanttime = sw.Elapsed;
		Console.WriteLine($"1k Constant Elapsed Time {onekconstanttime}");

		sw.Restart();
		FirstElement(tenkarray);
		sw.Stop();
		tenkconstanttime = sw.Elapsed;
		Console.WriteLine($"10k Constant Elapsed Time {tenkconstanttime}");

		sw.Restart();
		FirstElement(hundredkarray);
		sw.Stop();
		hundredkconstanttime = sw.Elapsed;
		Console.WriteLine($"100k Constant Elapsed Time {hundredkconstanttime}");

		TimeSpan oneklineartime = new();
		TimeSpan tenklineartime = new();
		TimeSpan hundredklineartime = new();

		sw.Start();
		SumElements(onekarray);
		sw.Stop();
		oneklineartime = sw.Elapsed;
		Console.WriteLine($"1k Linear Elapsed Time {oneklineartime}");

		sw.Restart();
		SumElements(tenkarray);
		sw.Stop();
		tenklineartime = sw.Elapsed;
		Console.WriteLine($"10k Linear Elapsed Time {tenklineartime}");

		sw.Restart();
		SumElements(hundredkarray);
		sw.Stop();
		hundredklineartime = sw.Elapsed;
		Console.WriteLine($"100k Linear Elapsed Time {hundredklineartime}");

		TimeSpan onekquadratictime = new();
		TimeSpan tenkquadratictime = new();
		TimeSpan hundredkquadratictime = new();

		sw.Start();
		CrossSearchElements(onekarray);
		sw.Stop();
		onekquadratictime = sw.Elapsed;
		Console.WriteLine($"1k Quadratic Elapsed Time {onekquadratictime}");

		sw.Restart();
		CrossSearchElements(tenkarray);
		sw.Stop();
		tenkquadratictime = sw.Elapsed;
		Console.WriteLine($"10k Quadratic Elapsed Time {tenkquadratictime}");

		sw.Restart();
		CrossSearchElements(hundredkarray);
		sw.Stop();
		hundredkquadratictime = sw.Elapsed;
		Console.WriteLine($"100k Quadratic Elapsed Time {hundredkquadratictime}");

		Console.WriteLine($"| Method | n=1,000 | n=10,000 | n=100,000 |\n" +
$"|--------|---------|----------|-----------|\n" +
$"| O(1)   | {onekconstanttime} | {tenkconstanttime} | {hundredkconstanttime} |\n" +
$"| O(n)   | {oneklineartime} | {tenklineartime} | {hundredklineartime} |\n" +
$"| O(n²)  | {onekquadratictime} | {tenkquadratictime} | {hundredkquadratictime} |");
	}

	private static int FirstElement(int[] arr) => arr.First();

	private static int SumElements(int[] arr) => arr.Sum();

	private static long CrossSearchElements(int[] arr)
	{
		long combos = 0;

		for (int x = 0; x < arr.Length; x++)
		{
			for (int y = 0; y < arr.Length; y++)
			{
				combos++;
				_ = arr[x]+arr[y];
			}
		}

		return combos;
	}
}
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

		Console.WriteLine(
$"| Method | n=1,000          | n=10,000         | n=100,000        |\n" +
$"|        |                  |                  |                  |\n" +
$"| O(1)   | {onekconstanttime} | {tenkconstanttime} | {hundredkconstanttime} |\n" +
$"| O(n)   | {oneklineartime} | {tenklineartime} | {hundredklineartime} |\n" +
$"| O(n²)  | {onekquadratictime} | {tenkquadratictime} | {hundredkquadratictime} |");
	}

/// <summary>
/// Gives the first item of the input array.
/// </summary>
/// <param name="arr">Input Array</param>
/// <returns>The First Item of the Array</returns>
/// <complexity>Time: O(1) - Only ever does one operation. Space: O(1) - No Variables are used.</complexity>
	private static int FirstElement(int[] arr) => arr.First();

/// <summary>
/// Adds the values if the input array.
/// </summary>
/// <param name="arr">Input Array</param>
/// <returns>The total sum of the array</returns>
/// <complexity>Time: O(n) - Adds only one additional operation per item added. Space: O(1) - Same amount of variables used regardless of size.</complexity>
	private static int SumElements(int[] arr) => arr.Sum();

/// <summary>
/// Cross pairs the values if the input array without checking for duplicates.
/// </summary>
/// <param name="arr">Input Array</param>
/// <returns>The total number of pairs within the array.</returns>
/// <complexity>Time: O(n²) - Adds a substantial amount of operations with each new item. Space: O(1) - Only the combo variable is used, the addition is discarded.</complexity>
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
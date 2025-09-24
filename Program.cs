using System.Diagnostics;

internal class Program
{
	private static void Main(string[] args)
	{
		int[] onekarray = new int[1000];
		int[] tenkarray = new int[10000];
		int[] hundredkarray = new int[100000];

		const long million = 1000000;

		long onekconstanttime = 0;
		long tenkconstanttime = 0;
		long hundredkconstanttime = 0;

		Stopwatch sw = new();

		sw.Start();
		FirstElement(onekarray);
		sw.Stop();
		onekconstanttime = sw.ElapsedMilliseconds;
		Console.WriteLine($"1k Constant Elapsed Time {onekconstanttime}ms");

		sw.Restart();
		FirstElement(tenkarray);
		sw.Stop();
		tenkconstanttime = sw.ElapsedMilliseconds;
		Console.WriteLine($"10k Constant Elapsed Time {tenkconstanttime}ms");

		sw.Restart();
		FirstElement(hundredkarray);
		sw.Stop();
		hundredkconstanttime = sw.ElapsedMilliseconds;
		Console.WriteLine($"100k Constant Elapsed Time {hundredkconstanttime}ms");

		long oneklineartime = 0;
		long tenklineartime = 0;
		long hundredklineartime = 0;

		sw.Start();
		SumElements(onekarray);
		sw.Stop();
		oneklineartime = sw.ElapsedMilliseconds;
		Console.WriteLine($"1k Linear Elapsed Time {oneklineartime}ms");

		sw.Restart();
		SumElements(tenkarray);
		sw.Stop();
		tenklineartime = sw.ElapsedMilliseconds;
		Console.WriteLine($"10k Linear Elapsed Time {tenklineartime}ms");

		sw.Restart();
		SumElements(hundredkarray);
		sw.Stop();
		hundredklineartime = sw.ElapsedMilliseconds;
		Console.WriteLine($"100k Linear Elapsed Time {hundredklineartime}ms");

		long onekquadratictime = 0;
		long tenkquadratictime = 0;
		long hundredkquadratictime = 0;

		sw.Start();
		CrossSearchElements(onekarray);
		sw.Stop();
		onekquadratictime = sw.ElapsedMilliseconds;
		Console.WriteLine($"1k Quadratic Elapsed Time {onekquadratictime}ms");

		sw.Restart();
		CrossSearchElements(tenkarray);
		sw.Stop();
		tenkquadratictime = sw.ElapsedMilliseconds;
		Console.WriteLine($"10k Quadratic Elapsed Time {tenkquadratictime}ms");

		sw.Restart();
		CrossSearchElements(hundredkarray);
		sw.Stop();
		hundredkquadratictime = sw.ElapsedMilliseconds;
		Console.WriteLine($"100k Quadratic Elapsed Time {hundredkquadratictime}ms");

		Console.WriteLine($"| Method | n=1,000 | n=10,000 | n=100,000 |\n" +
$"|--------|---------|----------|-----------|\n" +
$"| O(1)   | {onekconstanttime}ms | {tenkconstanttime}ms | {hundredkconstanttime}ms |\n" +
$"| O(n)   | {oneklineartime}ms | {tenklineartime}ms | {hundredklineartime}ms |\n" +
$"| O(n²)  | {onekquadratictime}ms | {tenkquadratictime}ms | {hundredkquadratictime}ms |");
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
				_ = $"{x}{y}";
			}
		}

		return combos;
	}
}
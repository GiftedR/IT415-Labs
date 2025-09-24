using System.Diagnostics;

internal class Program
{
	private static void Main(string[] args)
	{
		int[] onekarray = new int[1000];
		int[] tenkarray = new int[10000];
		int[] hundredkarray = new int[100000];

		const int million = 1000000;

		double onekconstanttime = 0;
		double tenkconstanttime = 0;
		double hundredkconstanttime = 0;

		Stopwatch sw = new();

		sw.Start();
		FirstElement(onekarray);
		sw.Stop();
		onekconstanttime = sw.Elapsed.Nanoseconds / million;

		sw.Restart();
		FirstElement(tenkarray);
		sw.Stop();
		tenkconstanttime = sw.Elapsed.Nanoseconds / million;

		sw.Restart();
		FirstElement(hundredkarray);
		sw.Stop();
		hundredkconstanttime = sw.Elapsed.Nanoseconds / million;


		double oneklineartime = 0;
		double tenklineartime = 0;
		double hundredklineartime = 0;

		sw.Start();
		SumElements(onekarray);
		sw.Stop();
		oneklineartime = sw.Elapsed.Nanoseconds / million;

		sw.Restart();
		SumElements(tenkarray);
		sw.Stop();
		tenklineartime = sw.Elapsed.Nanoseconds / million;

		sw.Restart();
		SumElements(hundredkarray);
		sw.Stop();
		hundredklineartime = sw.Elapsed.Nanoseconds / million;


		double onekquadratictime = 0;
		double tenkquadratictime = 0;
		double hundredkquadratictime = 0;

		sw.Start();
		CrossSearchElements(onekarray);
		sw.Stop();
		onekquadratictime = sw.Elapsed.Nanoseconds / million;

		sw.Restart();
		CrossSearchElements(tenkarray);
		sw.Stop();
		tenkquadratictime = sw.Elapsed.Nanoseconds / million;

		sw.Restart();
		CrossSearchElements(hundredkarray);
		sw.Stop();
		hundredkquadratictime = sw.Elapsed.Nanoseconds / million;
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
using System.Diagnostics;

internal class Program
{
	private static void Main(string[] args)
	{
		int[] onekarray = new int[1000];
		int[] tenkarray = new int[10000];
		int[] hundredkarray = new int[100000];
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
using System.Diagnostics;
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		Stopwatch sw = new();

		{ // Insertion Sorting
			int[] insertarr = gen(10);
			Console.Write("Insertion 10 Before:\n\t");
			print(insertarr);
			sw.Start();
			InsertionSort(insertarr);
			sw.Stop();
			Console.Write("After:\n");
			Console.Write($"\tInsertion Sort of 10 Items: {sw.Elapsed}\n\t");
			print(insertarr);
		}
		{ // Insertion Sorting
			int[] insertarr = gen(100);
			Console.Write("Insertion 100 Before:\n\t");
			print(insertarr);
			sw.Restart();
			InsertionSort(insertarr);
			sw.Stop();
			Console.Write("After:\n");
			Console.Write($"\tInsertion Sort of 100 Items: {sw.Elapsed}\n\t");
			print(insertarr);
		}
		{ // Insertion Sorting
			int[] insertarr = gen(1000);
			Console.Write("Insertion 1000 Before:\n\t");
			print(insertarr);
			sw.Restart();
			InsertionSort(insertarr);
			sw.Stop();
			Console.Write("After:\n");
			Console.Write($"\tInsertion Sort of 1000 Items: {sw.Elapsed}\n\t");
			print(insertarr);
		}
		{ // Quick Sorting
			int[] quickarr = gen(10);
			Console.Write("Quick 10 Before:\n\t");
			print(quickarr);
			sw.Restart();
			QuickSort(quickarr);
			sw.Stop();
			Console.Write("After:\n");
			Console.Write($"\tQuick Sort of 10 Items: {sw.Elapsed}\n\t");
			print(quickarr);
		}
		{ // Quick Sorting
			int[] quickarr = gen(100);
			Console.Write("Quick 100 Before:\n\t");
			print(quickarr);
			sw.Restart();
			QuickSort(quickarr);
			sw.Stop();
			Console.Write("After:\n");
			Console.Write($"\tQuick Sort of 100 Items: {sw.Elapsed}\n\t");
			print(quickarr);
		}
		{ // Quick Sorting
			int[] quickarr = gen(1000);
			Console.Write("Quick 1000 Before:\n\t");
			print(quickarr);
			sw.Restart();
			QuickSort(quickarr);
			sw.Stop();
			Console.Write("After:\n");
			Console.Write($"\tQuick Sort of 1000 Items: {sw.Elapsed}\n\t");
			print(quickarr);
		}
	}

	private static void print(int[] arr)
	{
		StringBuilder sb = new();
		for (int idx = 0; idx < 10 && idx < arr.Length; idx++)
			sb.Append(arr[idx] + ",");
		Console.WriteLine(sb.ToString());
	}
	private static int[] gen(int size)
	{
		int[] genarr = new int[size];
		Random rng = new();
		for (int idx = 0; idx < size; idx++)
			genarr[idx] = rng.Next(0, 999);
		return genarr;
	}

	public static void InsertionSort(int[] arr)
	{
		int size = arr.Length;

		for (int idx = 1; idx < size; idx++)
		{
			int value = arr[idx];
			int jdx = idx - 1;

			while (jdx >= 0 && arr[jdx] > value)
			{
				arr[jdx + 1] = arr[jdx];
				jdx = jdx - 1;
			}
			arr[jdx + 1] = value;
		}
	}


	private static void swap(int[] arr, int i, int j)
	{
		int tmp = arr[i];
		arr[i] = arr[j];
		arr[j] = tmp;
	}

	private static int part(int[] arr, int low, int high)
	{
		int pivot = arr[high];
		int i = low - 1;
		for (int j = low; j <= high - 1; j++)
		{
			if (arr[j] < pivot)
			{
				i++;
				swap(arr, i, j);
			}
		}

		swap(arr, i + 1, high);
		return i + 1;
	}

	public static void QuickSort(int[] arr, int low = 0, int high = -1)
	{
		if (high < 0)
			high = arr.Length - 1;

		if (low < high)
		{
			int partidx = part(arr, low, high);

			QuickSort(arr, low, partidx - 1);
			QuickSort(arr, partidx + 1, high);
		}
	}
}
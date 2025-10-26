using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		Stopwatch sw = new();
		TimeSpan in10, in100, in1000, qs10, qs100, qs1000;

		{ // Insertion Sorting
			int[] insertarr = gen(10);
			Console.Write("Insertion 10 Before:\n\t");
			print(insertarr);
			sw.Start();
			InsertionSort(insertarr);
			sw.Stop();
			Console.Write("After:\n");
			Console.Write($"\tInsertion Sort of 10 Items: {sw.Elapsed}\n\t");
			in10 = sw.Elapsed;
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
			in100 = sw.Elapsed;
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
			in1000 = sw.Elapsed;
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
			qs10 = sw.Elapsed;
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
			qs100 = sw.Elapsed;
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
			qs1000 = sw.Elapsed;
			print(quickarr);
		}
		Console.WriteLine("Results:");
		Console.WriteLine("            |-------10---------|-------100--------|-------1000-------|");
		Console.WriteLine($"Insert Sort | {in10} | {in100} | {in1000} |");
		Console.WriteLine($"Quick Sort  | {qs10} | {qs100} | {qs1000} |");
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

	/// <summary>
	/// Sorts an array using the Insertion Algorithm.
	/// </summary>
	/// <param name="arr">The array to be sorted</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Best:    Ω(n)  - Best case is the array is already sorted.
	/// 		Average: Θ(n²) - Average case increases operations by the amount of items each time.
	/// 		Worst:   O(n²) - Worst case increases operations by the amount of items each time.
	/// 	</complexity>
	/// </remarks>
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

	/// <summary>
	/// Used for quick sort, swaps to array elements.
	/// </summary>
	/// <param name="arr">The array being sorted</param>
	/// <param name="i">Left swap index</param>
	/// <param name="j">Right swap index</param>
	private static void swap(int[] arr, int i, int j)
	{
		int tmp = arr[i];
		arr[i] = arr[j];
		arr[j] = tmp;
	}

	/// <summary>
	/// Creates a partition for elements to be swapped.
	/// </summary>
	/// <param name="arr">The array affected</param>
	/// <param name="low">Starting position of the pivot</param>
	/// <param name="high">Ending position of the pivot</param>
	/// <returns></returns>
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

	/// <summary>
	/// Sorts the input array.
	/// </summary>
	/// <param name="arr">The array to be sorted.</param>
	/// <remarks>
	/// 	Changed to iterative over recursive due to frequent stack overflows with larger arrays.
	/// 	<complexity>
	/// 		Best:    Ω(n log n) - Best case is the array is already sorted.
	/// 		Average: Θ(n log n) - The sorting uses a splitting method, so increases only happen after a certain threshold.
	/// 		Worst:   O(n²)      - Only occurs when the array is in a specific state.
	/// 	</complexity>
	/// </remarks>
	public static void QuickSort(int[] arr)
	{
		int p, startidx = 0, endidx = arr.Length - 1, top = -1;
		int[] stack = new int[arr.Length];

		stack[++top] = startidx;
		stack[++top] = endidx;

		while (top >= 0)
		{
			endidx = stack[top--];
			startidx = stack[top--];

			p = part(arr, startidx, endidx);

			if (p - 1 > startidx)
			{
				stack[++top] = startidx;
				stack[++top] = p - 1;
			}
			if (p + 1 < endidx)
			{
				stack[++top] = p + 1;
				stack[++top] = endidx;
			}
		}
	}
}
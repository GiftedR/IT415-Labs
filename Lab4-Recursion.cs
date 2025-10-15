internal class Program
{
	private static void Main(string[] args)
	{
		Func<int, int[]> makeArray = (int length) =>
		{
			int[] retarr = new int[length];
			for (int idx = 0; idx < length; idx++)
			{
				retarr[idx] = idx + 1;
			}
			return retarr;
		};

		#pragma warning disable CS8625 // Disables Null into array location for testing
		Console.WriteLine("1) Factorials");
		Console.WriteLine($"1a) 0!      -> {Factorial(0) }\t\tAccurate: {Factorial(0)  == 1					}");
		Console.WriteLine($"1b) 5!      -> {Factorial(5) }\t\tAccurate: {Factorial(5)  == 120				}");
		Console.WriteLine($"1c) 10!     -> {Factorial(10)}\t\tAccurate: {Factorial(10) == 3_628_800			}");
		Console.WriteLine($"1d) 15!     -> {Factorial(15)}\tAccurate: {  Factorial(15) == 1_307_674_368_000 }");
		Console.WriteLine();
		Console.WriteLine("2) Fibbonaccci");
		Console.WriteLine($"2a) 0       -> {Fibonacci(0) }\t\tAccurate: {Fibonacci(0)  == 0  }");
		Console.WriteLine($"2b) 5       -> {Fibonacci(5) }\t\tAccurate: {Fibonacci(5)  == 5  }");
		Console.WriteLine($"2c) 10      -> {Fibonacci(10)}\t\tAccurate: {Fibonacci(10) == 55 }");
		Console.WriteLine($"2d) 15      -> {Fibonacci(15)}\t\tAccurate: {Fibonacci(15) == 610}");
		Console.WriteLine();
		Console.WriteLine("3) SumArray");
		Console.WriteLine($"3a) [0]     -> {SumArray(makeArray(0)) }\t\tAccurate: {SumArray(makeArray(0))  == 0  }");
		Console.WriteLine($"3b) [1...5] -> {SumArray(makeArray(5)) }\t\tAccurate: {SumArray(makeArray(5))  == 15 }");
		Console.WriteLine($"3c) [1...10]-> {SumArray(makeArray(10))}\t\tAccurate: {SumArray(makeArray(10)) == 55 }");
		Console.WriteLine($"3d) [1...15]-> {SumArray(makeArray(15))}\t\tAccurate: {SumArray(makeArray(15)) == 120}");
		Console.WriteLine($"3e) <null>  -> {SumArray(null)		   }\t\tAccurate: {SumArray(null)			 == 0}");
		Console.WriteLine();
		Console.WriteLine("4) Contains");
		Console.WriteLine($"4a) [0]      3 -> {Contains(makeArray(0) , 3)}\t\tAccurate: {Contains(makeArray(0),  3) == false}");
		Console.WriteLine($"4b) [1...5]  2 -> {Contains(makeArray(5) , 2)}\t\tAccurate: {Contains(makeArray(5),  2) == true }");
		Console.WriteLine($"4c) [1...10] 16-> {Contains(makeArray(10),16)}\t\tAccurate: {Contains(makeArray(10),16) == false}");
		Console.WriteLine($"4d) [1...15] 8 -> {Contains(makeArray(15), 8)}\t\tAccurate: {Contains(makeArray(15), 8) == true }");
		Console.WriteLine($"4d) <null>   3 -> {Contains(null, 3)}\t\tAccurate: {		 Contains(null, 3)  		== false}");
		Console.WriteLine();
		#pragma warning restore CS8625 // Enables Null into array location
	}

	/// <summary>
	/// Factorializes a number.
	/// </summary>
	/// <param name="n">The number to be factorialized</param>
	/// <returns>Input factorial.</returns>
	/// <remarks>Int128 is used due to large number output.</remarks>
	/// <complexity>Time: O(n), Space: O(n) - Adds one operation per item to the stack frame and calculates one at a time.</complexity>
	static Int128 Factorial(Int128 n)
	{
		if (n < 1)
			return 1;
		return n * Factorial(n - 1);
	}

	/// <summary>
	/// Calculates the Fibbonacci squence.
	/// </summary>
	/// <param name="n">The step in the fibbonacci sequence.</param>
	/// <returns>The value at the step.</returns>
	/// <complexity>Time: O(φ^n), Space: O(n) - Adds one operation per item, averages out to an exponential value</complexity>
	static int Fibonacci(int n)
	{
		if (n < 2)
			return n;
		return Fibonacci(n - 1) + Fibonacci(n - 2);
	}

	/// <summary>
	/// Adds all the values within the array.
	/// </summary>
	/// <param name="arr">The array to be summed.</param>
	/// <param name="index">The starting point of the array, defaults to the beginning.</param>
	/// <returns>The total value of all the elements in the array.</returns>
	/// <complexity>Time: O(n), Space: O(n) - Functions similar to a loop, just in one stack frame.</complexity>
	static int SumArray(int[] arr, int index = 0)
	{
		if (arr == null || arr.Length < 1 || index >= arr.Length)
			return 0;
		return arr[index] + SumArray(arr, index + 1);
	}
	
	/// <summary>
	/// Checks if the value is within the array.
	/// </summary>
	/// <param name="arr">The array to be checked.</param>
	/// <param name="target">The value to look for.</param>
	/// <param name="index">The starting point for the search. Defaults to the beginning.</param>
	/// <returns>If the value was found within the array.</returns>
	/// <complexity>Time: O(n), Space: O(n) - Functions similar to a loop, just in one stack frame.</complexity>
	static bool Contains(int[] arr, int target, int index = 0)
	{
		if (arr == null || arr.Length < 0 || index >= arr.Length)
			return false;
		return arr[index] == target || Contains(arr, target, index + 1);
	}
}
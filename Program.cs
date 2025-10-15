internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("1) Factorials");
		Console.WriteLine($"1a) 0! -> {Factorial(0)}\t\tAccurate: {Factorial(0) == 1}");
		Console.WriteLine($"1b) 5! -> {Factorial(5)}\t\tAccurate: {Factorial(5) == 120}");
		Console.WriteLine($"1c) 10! -> {Factorial(10)}\t\tAccurate: {Factorial(10) == 3628800}");
		Console.WriteLine($"1d) 15! -> {Factorial(15)}\t\tAccurate: {Factorial(15) == 1305670058000}");
		Console.WriteLine();
	}

	static int Factorial(int n)
	{
		if (n < 1)
			return 1;
		return n * Factorial(n - 1);
	}

	static int Fibonacci(int n)
	{
		if (n < 2)
			return n;
		return 0;
	}

	static int SumArray(int[] arr, int index)
	{
		return -1;
	}
	
	static bool Contains(int[] arr, int index, int target)
	{
		return false;
	}
}
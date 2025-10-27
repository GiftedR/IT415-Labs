internal class Program
{
	private static void Main(string[] args)
	{
		BST tree = new();
		int[] insertValues = { 10, 5, 15, 3, 7, 12, 18 };
		foreach (int n in insertValues)
		{
			Console.WriteLine($"Inserting value: {n}");
			tree.Insert(n);
		}

		int[] searchValue = { 7, 11, 82 };
		foreach (int n in searchValue)
		{
			Console.WriteLine($"Looking for value: {n}, Found: {tree.Search(n)}");
		}
	}
}
internal class Program
{
	private static void Main(string[] args)
	{
		
	}
}

public class HashTable
{
	private List<int>[] _hashBuckets;

	public HashTable(int hashSize) => _hashBuckets = new List<int>[hashSize];
}
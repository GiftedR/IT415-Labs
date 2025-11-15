using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		HashTable ht = new(3);

		Console.WriteLine("Inserting 4 values, 12, 22, 37, 5");

		ht.Insert(12);
		ht.Insert(22);
		ht.Insert(37);
		ht.Insert(5);

		Console.WriteLine($"Contains Value 12: {ht.Contains(12)}");
		Console.WriteLine($"Contains Value 22: {ht.Contains(22)}");
		Console.WriteLine($"Contains Value 37: {ht.Contains(37)}");
		Console.WriteLine($"Contains Value 5: {ht.Contains(5)}");
		
		Console.WriteLine($"Final HashTable: \n{ht}");
		
		HashTable ht5 = new(5);

		Console.WriteLine("Inserting 3 values, 12, 22, 37");

		ht5.Insert(12);
		ht5.Insert(22);
		ht5.Insert(37);

		Console.WriteLine($"Contains Value 12: {ht5.Contains(12)}");
		Console.WriteLine($"Contains Value 22: {ht5.Contains(22)}");
		Console.WriteLine($"Contains Value 37: {ht5.Contains(37)}");
		
		Console.WriteLine($"Final HashTable: \n{ht5}");
	}
}

public class HashTable
{
	private List<int>[] _hashBuckets;

	public HashTable(int hashSize) => _hashBuckets = new List<int>[hashSize];

	private int Hash(int hashKey) => hashKey % _hashBuckets.Length;

	public void Insert(int hashKey)
	{
		int idx = Hash(hashKey);
		if (_hashBuckets[idx] == null)
			_hashBuckets[idx] = new List<int>();
		
		if (!_hashBuckets[idx].Contains(hashKey))
		{
			// The only thing I changed was setting it to add rather than create a new list.
			// _hashBuckets[idx] = new List<int>(); // Fixed it by commenting out this line
			_hashBuckets[idx].Add(hashKey);
		}
	}

	public bool Contains(int hashKey) => _hashBuckets[Hash(hashKey)] != null && _hashBuckets[Hash(hashKey)].Contains(hashKey);

	public override string ToString()
	{
		StringBuilder sb = new();

		Func<List<int>, string> lst_str = (List<int> list) =>
		{
			if (list == null)
				return "";
			StringBuilder lstsb = new();
			foreach (int item in list)
				lstsb.Append($" {item}, ");
			return lstsb.ToString();
			
		};
		for (int idx = 0; idx < _hashBuckets.Length; idx++)
			sb.Append($"[{idx}] : [{lst_str(_hashBuckets[idx])}]\n");

		return sb.ToString();
	}
}
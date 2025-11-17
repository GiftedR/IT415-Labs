using System.Text;

// In the custom has table, when items have multiple keys, they just get appended to the list that the bucket contains.
// This makes the hash table most closely related to a 2d array.
// 
// For the current implementation of the hash table, it behaves differently than the dictionary. The dictionary
// acts more closely to an array that uses strings as indexer values rather than actual numbers. This is the most useful
// when building some sort of caching system, where single words can be mapped to files or compiled classes. Where
// items can be referenced by short hand names rather than requiring the absolute path, or rebuilding an index each time.
// 
// A use-case where one might want to build a custom solution for a hash table rather than using the in built one would be
// when needing to use custom data types to act as indexers. Such as using a 2d vector to map to a certain color for things
// like ambient occlusion in video games. Another perfect example would be using a custom hash table for building a
// decision tree that maps users choices to reputation with in game factions.

internal class Program
{
	private static void Main(string[] args)
	{
		SimpleHashTable sht = new(5);

		Console.WriteLine("Inserting 12 in hash table...");
		sht.Insert(12);
		Console.WriteLine("Inserting 22 in hash table...");
		sht.Insert(22);
		Console.WriteLine("Inserting 37 in hash table...");
		sht.Insert(37);

		Console.WriteLine($"Current Hash Table:\n{sht}");

		Dictionary<string, string> dct = new();
		
		Console.WriteLine("Setting Alice with the phone number 555-1234...");
		dct.Add("Alice", "555-1234");
		Console.WriteLine("Setting Bob with the phone number 555-5678...");
		dct.Add("Bob", "555-5678");
		Console.WriteLine("Setting Charlie with the phone number 555-9012...");
		dct.Add("Charlie", "555-9012");

		Console.WriteLine($"Alices number is {dct["Alice"]}");
		
		Console.WriteLine($"David has a number is {dct.ContainsKey("David")}");
	}
}

public class SimpleHashTable
{
	private List<int>[] _hashBuckets;

	public SimpleHashTable(int hashSize) => _hashBuckets = new List<int>[hashSize];

	private int Hash(int hashKey) => hashKey % _hashBuckets.Length;

	public void Insert(int hashKey)
	{
		int idx = Hash(hashKey);
		if (_hashBuckets[idx] == null)
			_hashBuckets[idx] = new List<int>();
		
		if (!_hashBuckets[idx].Contains(hashKey))
		{
			_hashBuckets[idx].Add(hashKey);
		}
	}

	public bool Contains(int hashKey) => _hashBuckets[Hash(hashKey)] != null && _hashBuckets[Hash(hashKey)].Contains(hashKey);

	public string PrintTable()
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

	public override string ToString() => PrintTable();
}
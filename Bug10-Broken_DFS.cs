using System.Security.Cryptography.X509Certificates;

internal class Program
{
	private static void Main(string[] args)
	{
		// Test case one: Everything references every other thing
		Dictionary<string, List<string>> l1_Circ = new()
		{
			{"Carl", [ "Bob", "Jeff", "Andy"]},
			{"Bob", [ "Carl", "Jeff", "Andy"]},
			{"Jeff", [ "Bob", "Carl", "Andy"]},
			{"Andy", [ "Bob", "Jeff", "Carl"]}
		};

		// Test case two: Large circle of four nodes
		Dictionary<string, List<string>> l2_Circ = new()
		{
			{"Carl", [ "Bob" ]},
			{"Bob", [ "Jeff" ]},
			{"Jeff", [ "Andy"]},
			{"Andy", [ "Carl"]}
		};

		BrokenDFS("Carl", l1_Circ);
		p_DFSHistory = new(); // History reset needed in order to work properly and not change method signiture.
		BrokenDFS("Carl", l2_Circ);
	}

	private static List<string> p_DFSHistory = new();

	// Bug was in here, there was no check for duplicate parsing, now it instead bypasses the parsing if it is found within the history.
	public static void BrokenDFS(string vertex, Dictionary<string, List<string>> graph)
	{
		// Adds item to the history
		p_DFSHistory.Add(vertex);
		Console.WriteLine(vertex);
		foreach (string neighbor in graph[vertex])
		{
			if (!p_DFSHistory.Contains(neighbor)) // Only calls if not within history
				BrokenDFS(neighbor, graph);
		}
	}
}
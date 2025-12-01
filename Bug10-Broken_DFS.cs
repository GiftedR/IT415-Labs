using System.Security.Cryptography.X509Certificates;

internal class Program
{
	private static void Main(string[] args)
	{
		Dictionary<string, List<string>> l1_Circ = new()
		{
			{"Carl", [ "Bob", "Jeff", "Andy"]},
			{"Bob", [ "Carl", "Jeff", "Andy"]},
			{"Jeff", [ "Bob", "Carl", "Andy"]},
			{"Andy", [ "Bob", "Jeff", "Carl"]}
		};

		Dictionary<string, List<string>> l2_Circ = new()
		{
			{"Carl", [ "Bob" ]},
			{"Bob", [ "Jeff" ]},
			{"Jeff", [ "Andy"]},
			{"Andy", [ "Carl"]}
		};

		BrokenDFS("Carl", l1_Circ);
		p_DFSHistory = new();
		BrokenDFS("Carl", l2_Circ);
	}

	private static List<string> p_DFSHistory = new();

	public static void BrokenDFS(string vertex, Dictionary<string, List<string>> graph)
	{
		p_DFSHistory.Add(vertex);
		Console.WriteLine(vertex);
		foreach (string neighbor in graph[vertex])
		{
			if (!p_DFSHistory.Contains(neighbor))
				BrokenDFS(neighbor, graph);
		}
	}
}
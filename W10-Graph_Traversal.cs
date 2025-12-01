using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		Dictionary<string, List<string>> l1_Circ = new()
		{
			{"Carl", [ "Bob" ]},
			{"Bob", [ "Jeff" ]},
			{"Jeff", [ "Andy"]},
			{"Andy", [ "Carl"]}
		};

		Dictionary<string, List<string>> l2_Circ = new()
		{
			{"Carl", [ "Bob", "Jeff", "Andy"]},
			{"Bob", [ "Carl", "Jeff", "Andy"]},
			{"Jeff", [ "Bob", "Carl", "Andy"]},
			{"Andy", [ "Bob", "Jeff", "Carl"]}
		};

		Console.WriteLine("\nLevel 1 Circle adjacency list");
		PrintAdj(l1_Circ);
		Console.WriteLine("\nLevel 2 Circle adjacency list");
		PrintAdj(l2_Circ);

		Console.WriteLine("\nPerforming BFS on Level 1 Circle starting with Carl");
		DFS("Carl", l1_Circ);
		p_DFSHistory = new();
		Console.WriteLine("\nPerforming BFS on Level 2 Circle starting with Carl");
		DFS("Carl", l2_Circ);
		p_DFSHistory = new();
		Console.WriteLine("\nPerforming BFS on Level 1 Circle starting with Bob");
		DFS("Bob", l1_Circ);
		p_DFSHistory = new();
		Console.WriteLine("\nPerforming BFS on Level 2 Circle starting with Bob");
		DFS("Bob", l2_Circ);
		p_DFSHistory = new();
		Console.WriteLine("\nPerforming BFS on Level 1 Circle starting with Jeff");
		DFS("Jeff", l1_Circ);
		p_DFSHistory = new();
		Console.WriteLine("\nPerforming BFS on Level 2 Circle starting with Jeff");
		DFS("Jeff", l2_Circ);
		p_DFSHistory = new();
		Console.WriteLine("\nPerforming BFS on Level 1 Circle starting with Andy");
		DFS("Andy", l1_Circ);
		p_DFSHistory = new();
		Console.WriteLine("\nPerforming BFS on Level 2 Circle starting with Andy");
		DFS("Andy", l2_Circ);
		p_DFSHistory = new();
	}

	private static HashSet<string> p_DFSHistory = new();

	public static void DFS(string vertex, Dictionary<string, List<string>> graph)
	{
		p_DFSHistory.Add(vertex);
		Console.WriteLine(vertex);
		foreach (string connection in graph[vertex])
		{
			if (!p_DFSHistory.Contains(connection))
				DFS(connection, graph);
		}
	}

	private static void PrintAdj(Dictionary<string, List<string>> graph)
	{
		foreach (string node in graph.Keys)
		{
			Console.WriteLine($"{node} -> {StringifyList(graph[node])}");
		}
	}

	private static string StringifyList(List<string> values)
	{
		StringBuilder sb = new();
		foreach (string item in values)
		{
			sb.Append($"{item}, ");
		}
		sb.Remove(sb.Length - 2, 2);
		return sb.ToString();
	}
}
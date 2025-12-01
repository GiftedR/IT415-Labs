using System.Text;

// Reflection: The main difference in style between Breadth First Search (BFS) vs Depth First Search (DFS) is the way they approach the same problem. Dealing with searching and traversing a graph. BFS deals with it by reading it from one side to the other, starting with the highest most node. While DFS handles it by starting with the deepest or farthest away node it can reach.

// The main place where DFS and BFS can be found is in regard to path finding algorithms. BFS has its best case when ensuring you map every part of a structure. Being meticulous with the search and ensuring each item is hit. Although it can take longer, it can help with indexing each node for path finding viability, creating a simple index of which items connect to which other items. DFS is then used in algorithms like A-Star, where an item or entity needs to get from one point to another within the limitations of the world and as fast as possible. Which it then can use the indexed items from the BFS to course correct.

// As stated previously, you can use BFS to create an indexed map then to use with DFS to create an efficient path of travel. It can also be used to track deviations if needed. If I had to guess, most items uses a skewed version of BFS that travels towards the goal in order to save processing power.

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
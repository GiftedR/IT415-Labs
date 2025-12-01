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
		BrokenDFS("Carl", l2_Circ);
	}

	public static void BrokenDFS(string vertex, Dictionary<string, List<string>> graph)
	{
		Console.WriteLine(vertex);
		foreach (string neighbor in graph[vertex])
		{
			BrokenDFS(neighbor, graph);
		}
	}
}
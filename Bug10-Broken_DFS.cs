internal class Program
{
	private static void Main(string[] args)
	{
		
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
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		BST bst = BuildSkewed();
		Console.WriteLine("Tree Before:");
		bst.PrintTree(bst.Root);
		RotateLeft(ref bst);
		Console.WriteLine("\nTree After Rotating:");
		bst.PrintTree(bst.Root);

		int[] hp = { 4, 10, 3, 5, 1 };
		Console.WriteLine("Starting: [ 4, 10, 3, 5, 1 ]");
		Heapify(hp);
		Console.WriteLine($"Heaped: [{StrArray(hp)} ]");
	}

	private static BST BuildSkewed()
	{
		BST bst = new();
		bst.Insert(10);
		bst.Insert(20);
		bst.Insert(30);

		return bst;
	}

	private static void RotateLeft(ref BST bst)
	{
		if (bst.Root == null || bst.Root.Right == null || bst.Root.Right.Right == null) return;

		bst.Root.Left = bst.Root.Right;
		bst.Root.Right = bst.Root.Left.Right;
		bst.Root.Left.Right = null;

	}

	private static void Heapify(int[] arr)
	{
		
	}
	
	private static string StrArray(int[] arr)
	{
		StringBuilder sb = new();

		foreach (int i in arr)
			sb.Append($" {i},");

		sb.Remove(sb.Length - 1, 1);
		return sb.ToString();
	}
}

public class BST
{
	public Node? Root { get; set; }

	public Node Insert(int newValue, Node? item = null)
	{
		if (Root == null)
			return Root = new Node(newValue);

		if (item == null)
			item = Root;

		if (newValue < item.value)
			return item.Left == null ? item.Left = new Node(newValue) : Insert(newValue, item.Left);
		if (newValue > item.value)
			return item.Right == null ? item.Right = new Node(newValue) : Insert(newValue, item.Right);

		throw new InvalidOperationException("Duplicate values are not allowed");
	}

	public void PrintTree(Node? node, string indent = "", bool isLeft = true)
	{
		if (node == null) return;
		Console.WriteLine(indent + (isLeft ? "L-- " : "R-- ")
							+ node.value);
		PrintTree(node.Left, indent + "   ", true);
		PrintTree(node.Right, indent + "   ", false);
	}
}

public class Node
{
	public int value { get; set; }
	public Node? Left { get; set; }
	public Node? Right { get; set; }
	public Node(int startingValue)
	{
		value = startingValue;
	}
}
using System.Text;

/// <summary>
/// Reflection: 
/// Rotation cause the nodes within the tree to swap positions to create a more balanced tree. It allows for a faster search of the smallest and the biggest values. It can also allow for quick access for features of the tree like height and depth.
// 
// Heapify ensures the array is in a format that would generate a valid heap for use with all the standard heap actions. In this case it corrects it to a min-heap. It can also set it up to be a max heap which has its own use cases.
// 
// In terms of AVL it allows for quicker searching of certain values, Where a tree can have a million items, but only need to run the action a few times to determine of an item is contained in the tree. It also takes the same amount of operations to remove an item from the tree due to how quickly it can be found.
// 
// With a priority Queue, it can be used to make sure that more required actions happen first. This is most commonly used with systems and tasks to make sure that the kernel and lower level processes run before the higher ones so they can be set up for them to use. This makes operating systems more stable.
/// </summary>

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
		int length = arr.Length;

		for (int idx = length / 2 - 1; idx >= 0; idx--)
			RecursiveHeapify(arr, idx, length);
	}

	private static void RecursiveHeapify(int[] arr, int index, int number)
	{
		int smallest = index;
		int left = 2 * index + 1;
		int right = 2 * index + 2;

		if (left < number && arr[left] < arr[smallest])
			smallest = left;

		if (right < number && arr[right] < arr[smallest])
			smallest = right;
		
		if (smallest != index)
		{
			int tmp = arr[index];

			arr[index] = arr[smallest];
			arr[smallest] = tmp;

			RecursiveHeapify(arr, smallest, number);
		}
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
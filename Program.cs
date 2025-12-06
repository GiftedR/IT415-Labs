using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		Tree demoTree = Tree.CreateTeachingTree();

		Console.WriteLine("Starting Tree:");
		demoTree.PrintTree(demoTree.Root);

		List<TreeNode> InOrder = new();
		Tree.InOrder(demoTree.Root!, ref InOrder);
		Console.WriteLine($"\nRunning InOrder Sample\n\tExpected:[3, 27, 9, 38, 43]\n\tActual:{GetListString(InOrder)}");
		List<TreeNode> PreOrder = new();
		Tree.PreOrder(demoTree.Root!, ref PreOrder);
		Console.WriteLine($"\nRunning PreOrder Sample\n\tExpected:[38, 27, 3, 9, 43]\n\tActual:{GetListString(PreOrder)}");
		List<TreeNode> PostOrder = new();
		Tree.PostOrder(demoTree.Root!, ref PostOrder);
		Console.WriteLine($"\nRunning PostOrder Sample\n\tExpected:[3, 9, 27, 43, 38]\n\tActual:{GetListString(PostOrder)}");

		Console.WriteLine($"\nGetting the Height in edges:\n\tExpected: 2\n\tActual: {Tree.GetHeight(demoTree.Root!)}");
		
		Console.WriteLine($"\nGetting the Depth of the 38 Node:\n\tExpected: 0\n\tActual: {Tree.GetDepth(demoTree.Root!, 38)}");
		Console.WriteLine($"\nGetting the Depth of the 27 Node:\n\tExpected: 1\n\tActual: {Tree.GetDepth(demoTree.Root!, 27)}");
		Console.WriteLine($"\nGetting the Depth of the 43 Node:\n\tExpected: 1\n\tActual: {Tree.GetDepth(demoTree.Root!, 43)}");
		Console.WriteLine($"\nGetting the Depth of the 3 Node:\n\tExpected: 2\n\tActual: {Tree.GetDepth(demoTree.Root!, 3)}");
		Console.WriteLine($"\nGetting the Depth of the 9 Node:\n\tExpected: 2\n\tActual: {Tree.GetDepth(demoTree.Root!, 9)}");
	}

	public static string GetListString(List<TreeNode> lst) => GetArrString(lst.ToArray());
	public static string GetArrString(TreeNode[] arr)
	{
		StringBuilder sb = new("[");
		foreach (TreeNode item in arr)
		{
			sb.Append($"{item}, ");
		}
		sb.Remove(sb.Length - 2, 2);
		sb.Append("]");
		return sb.ToString();
	}
}
public class Tree
{
	public TreeNode? Root { get; set; }

	public static void InOrder(TreeNode node, ref List<TreeNode> output)
	{
		if (node.Left != null)
			InOrder(node.Left, ref output);
		output.Add(node);
		if (node.Right != null)
			InOrder(node.Right, ref output);
	}
	public static void PreOrder(TreeNode node, ref List<TreeNode> output)
	{
		output.Add(node);
		if (node.Left != null)
			PreOrder(node.Left, ref output);
		if (node.Right != null)
			PreOrder(node.Right, ref output);
	}
	public static void PostOrder(TreeNode node, ref List<TreeNode> output)
	{
		if (node.Left != null)
			PostOrder(node.Left, ref output);
		if (node.Right != null)
			PostOrder(node.Right, ref output);
		output.Add(node);
	}

	public static int GetHeight(TreeNode node)
	{
		if (node == null)
			return -1;
		int leftHeight = GetHeight(node.Left!);
		int rightHeight = GetHeight(node.Right!);
		return 1 + Math.Max(leftHeight, rightHeight);
	}

	public static int GetDepth(TreeNode? node, int target)
	{
		if (node == null)
			return -1;
		if (node.Data == target) 
			return 0;
		int leftDepth = GetDepth(node.Left, target);
		if (leftDepth > -1) 
			return leftDepth + 1;
		int RightDepth = GetDepth(node.Right, target);
		if (RightDepth > -1) 
			return RightDepth + 1;
		return -1;
	}

	public static Tree CreateTeachingTree() => new Tree
	{
		Root = new TreeNode(38)
		{
			Left = new TreeNode(27)
			{
				Left = new TreeNode(3),
				Right = new TreeNode(9)
			},
			Right = new TreeNode(43)
		}
	};
	public void PrintTree(TreeNode? node, string indent = "", bool isLeft = true)
	{
		if (node == null) return;
		Console.WriteLine(indent + (isLeft ? "L-- " : "R-- ")
							+ node.Data);
		PrintTree(node.Left, indent + "   ", true);
		PrintTree(node.Right, indent + "   ", false);
	}
}

public class TreeNode
{
	public int Data { get; set; }
	public TreeNode? Left { get; set; }
	public TreeNode? Right { get; set; }

	public TreeNode(int data) => Data = data;

	public override string ToString() => Data.ToString();
}
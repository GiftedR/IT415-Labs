using System.Text;

// Note to reader: Complexity documentation only applys to one call of the function. So recursive functions are O(1), but overall are O(n) when called.

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

/// <summary>
/// Binary Tree data structure.
/// </summary>
public class Tree
{
	public TreeNode? Root { get; set; }

	/// <summary>
	/// Traverses the tree in order and adds them to a list
	/// </summary>
	/// <param name="node">The starting node</param>
	/// <param name="output">The list that gets added to.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursion, method itself is only used once.
	/// 		Space: O(1) - Creates no additional variables.
	/// 	</complexity>
	/// </remarks>
	public static void InOrder(TreeNode node, ref List<TreeNode> output)
	{
		if (node.Left != null)
			InOrder(node.Left, ref output);
		output.Add(node);
		if (node.Right != null)
			InOrder(node.Right, ref output);
	}

	/// <summary>
	/// Traverses the tree in pre order and adds them to a list
	/// </summary>
	/// <param name="node">The starting node</param>
	/// <param name="output">The list that gets added to.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursion, method itself is only used once.
	/// 		Space: O(1) - Creates no additional variables.
	/// 	</complexity>
	/// </remarks>
	public static void PreOrder(TreeNode node, ref List<TreeNode> output)
	{
		output.Add(node);
		if (node.Left != null)
			PreOrder(node.Left, ref output);
		if (node.Right != null)
			PreOrder(node.Right, ref output);
	}

	/// <summary>
	/// Traverses the tree in post order and adds them to a list
	/// </summary>
	/// <param name="node">The starting node</param>
	/// <param name="output">The list that gets added too.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursion, method itself is only used once.
	/// 		Space: O(1) - Creates no additional variables.
	/// 	</complexity>
	/// </remarks>
	public static void PostOrder(TreeNode node, ref List<TreeNode> output)
	{
		if (node.Left != null)
			PostOrder(node.Left, ref output);
		if (node.Right != null)
			PostOrder(node.Right, ref output);
		output.Add(node);
	}

	/// <summary>
	/// Gets the hight of the tree.
	/// </summary>
	/// <param name="node">The starting point.</param>
	/// <returns>The height.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursion, method itself is only used once.
	/// 		Space: O(1) - Only uses left and right variable regardless of size.
	/// 	</complexity>
	/// </remarks>
	public static int GetHeight(TreeNode node)
	{
		if (node == null)
			return -1;
		int leftHeight = GetHeight(node.Left!);
		int rightHeight = GetHeight(node.Right!);
		return 1 + Math.Max(leftHeight, rightHeight);
	}

	/// <summary>
	/// Gets the depth of the specified node.
	/// </summary>
	/// <param name="node">THe starting node.</param>
	/// <param name="target">The item to look for.</param>
	/// <returns>The depth of the item.</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recusion, method itself is only used once.
	/// 		Space: O(1) - Only uses 2 variables regardless of size.
	/// 	</complexity>
	/// </remarks>
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

	/// <summary>
	/// Creates a sample tree for use with traversals, depth and height.
	/// </summary>
	/// <returns>Sample Tree</returns>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Only makes a new object.
	/// 		Space: O(1) - Only called once.
	/// 	</complexity>
	/// </remarks>
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
	/// <summary>
	/// Prints the tree.
	/// </summary>
	/// <param name="node">The starting point.</param>
	/// <param name="indent">The indent character.</param>
	/// <param name="isLeft">Is left by default.</param>
	/// <remarks>
	/// 	<complexity>
	/// 		Time: O(1) - Recursive, method only called once.
	/// 		Space: O(1) - Creates no variables.
	/// 	</complexity>
	/// </remarks>
	public void PrintTree(TreeNode? node, string indent = "", bool isLeft = true)
	{
		if (node == null) return;
		Console.WriteLine(indent + (isLeft ? "L-- " : "R-- ")
							+ node.Data);
		PrintTree(node.Left, indent + "   ", true);
		PrintTree(node.Right, indent + "   ", false);
	}
}

/// <summary>
/// A node contained in the tree.
/// </summary>
public class TreeNode
{
	/// <summary>
	/// Data contained in the node.
	/// </summary>
	public int Data { get; set; }
	/// <summary>
	/// Node to the left of this one.
	/// </summary>
	public TreeNode? Left { get; set; }
	/// <summary>
	/// Node to the right of this one.
	/// </summary>
	public TreeNode? Right { get; set; }

	public TreeNode(int data) => Data = data;

	public override string ToString() => Data.ToString();
}

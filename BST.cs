class Node
{
	public int Value;
	public Node? Left;
	public Node? Right;

	public Node(int value)
	{
		Value = value;
	}
}

class BST
{
	public Node? Root;

	public void Insert(int value)
	{
		if (Root == null)
			Root = new Node(value);
		else
			Insert(Root, value);
	}

	private void Insert(Node current, int value)
	{
		if (value < current.Value)
			if (current.Left == null)
				current.Left = new Node(value);
			else
				Insert(current.Left, value); // Was current.right, but since insertion needed to be left, there would no need to insert to the right.
		else if (value > current.Value)
			if (current.Right == null) // This entire section was wrong. Since it is a binary tree, actions to the left and right need to be symmetrical, otherwise there can be issues.
				current.Right = new Node(value);
			else
				Insert(current.Right, value);
	}

	public bool Search(int value)
	{
		return Search(Root, value);
	}

	private bool Search(Node? current, int value)
	{
		if (current == null)
			return false;

		if (current.Value == value)
			return true;
		else if (value < current.Value)
			return Search(current.Left, value);
		else
			return Search(current.Right, value);
	}
}
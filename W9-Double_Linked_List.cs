using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		DoubleLinkedList<(int, int)> forward = new();
		forward.AddLast((1, 1));
		forward.AddLast((1, 2));
		forward.AddLast((1, 3));
		forward.AddLast((1, 4));
		forward.AddLast((2, 1));
		forward.AddLast((2, 2));
		forward.AddLast((2, 3));
		forward.AddLast((2, 4));
		forward.AddLast((3, 1));
		forward.AddLast((3, 2));
		forward.AddLast((3, 3));
		forward.AddLast((3, 4));
		forward.AddLast((4, 1));
		forward.AddLast((4, 2));
		forward.AddLast((4, 3));
		forward.AddLast((4, 4));
		Console.WriteLine("\nAdd Last List From Head:");
		Console.WriteLine(forward.ReadForward());
		Console.WriteLine("\nAdd Last List From Tail:");
		Console.WriteLine(forward.ReadBackward());

		DoubleLinkedList<(int, int)> backward = new();
		backward.AddFirst((1, 1));
		backward.AddFirst((1, 2));
		backward.AddFirst((1, 3));
		backward.AddFirst((1, 4));
		backward.AddFirst((2, 1));
		backward.AddFirst((2, 2));
		backward.AddFirst((2, 3));
		backward.AddFirst((2, 4));
		backward.AddFirst((3, 1));
		backward.AddFirst((3, 2));
		backward.AddFirst((3, 3));
		backward.AddFirst((3, 4));
		backward.AddFirst((4, 1));
		backward.AddFirst((4, 2));
		backward.AddFirst((4, 3));
		backward.AddFirst((4, 4));
		Console.WriteLine("\nAdd First List From Head:");
		Console.WriteLine(backward.ReadForward());
		Console.WriteLine("\nAdd First List From Tail:");
		Console.WriteLine(backward.ReadBackward());

		DoubleLinkedList<(int, int)> deyeet = new();
		deyeet.AddLast((0, 0));
		deyeet.AddLast((0, 8));
		deyeet.AddLast((9, 2));
		deyeet.AddLast((3, 7));
		deyeet.AddLast((2, 467));
		deyeet.AddFirst((8992, 467));

		Console.WriteLine("\nCurrent Deletion List:");
		Console.WriteLine(deyeet.ReadForward());
		Console.WriteLine("\nDeleting (2, 467) From List:");
		deyeet.Remove(new((2, 467)));
		Console.WriteLine(deyeet.ReadForward());
		Console.WriteLine("\nDeleting (8992, 467) From List:");
		deyeet.Remove(new((8992, 467)));
		Console.WriteLine(deyeet.ReadForward());
		Console.WriteLine("\nAdding (987, 120) To Head:");
		deyeet.AddFirst((987, 120));
		Console.WriteLine(deyeet.ReadForward());
		Console.WriteLine("\nDeleting The Head:");
		deyeet.Remove(deyeet.Head!);
		Console.WriteLine(deyeet.ReadForward());
		Console.WriteLine("\nAdding (5400, 1230) To Tail:");
		deyeet.AddLast((5400, 1230));
		Console.WriteLine(deyeet.ReadForward());
		Console.WriteLine("\nDeleting The Tail:");
		deyeet.Remove(deyeet.Tail!);
		Console.WriteLine(deyeet.ReadForward());
		Console.WriteLine("\nDeleting The 4th Value:");
		deyeet.Remove(deyeet.Head!.Next!.Next!.Next!);
		Console.WriteLine(deyeet.ReadForward());

	}
}

public class DoubleLinkedList<T>
{
	public DoubleNode<T>? Head { get; protected set; }
	public DoubleNode<T>? Tail { get; protected set; }

	public int Count { get; protected set; }

	public void AddFirst(T data)
	{
		if (Head == null && Tail == null)
		{
			Head = Tail = new DoubleNode<T>(data);
			return;
		}
		DoubleNode<T> newHead = new(data);
		newHead.Next = Head;
		newHead.Prev = Tail;
		
		Head!.Prev = newHead;
		Tail!.Next = newHead;
		Head = newHead;
	}
	
	public void AddLast(T data)
	{
		if (Head == null && Tail == null)
		{
			Head = Tail = new(data);
			return;
		}
		DoubleNode<T> newTail = new(data);
		newTail.Prev = Tail;
		newTail.Next = Head;

		Head!.Prev = newTail;
		Tail!.Next = newTail;
		Tail = newTail;
		Count ++;
	}
	
	public DoubleNode<T>? GetNode(DoubleNode<T> node)
	{
		if (Head == null || Tail == null) return null;
		DoubleNode<T> _fore = Head!;
		DoubleNode<T> _back = Tail!;
		do
		{
			if (_fore == node || _back == node) return node;
			_fore = _fore.Next!;
			_back = _back.Prev!;
		}
		while (
			_fore != _back &&
			_fore.Prev != _back
		);

		return null;
	}

	public void Remove(DoubleNode<T> node)
	{
		if (Head == null && Tail == null) return;

		if (node == Head)
		{
			Tail!.Next = Head.Next;
			Head.Next!.Prev = Tail;
			Head = Head.Next;
		}
		else if (node == Tail)
		{
			Tail.Prev!.Next = Head;
			Head!.Prev = Tail.Prev;
			Tail = Tail.Prev;
		}
		else
		{
			DoubleNode<T>? delNode = GetNode(node);
			if (delNode == null) return;
			delNode.Next!.Prev = delNode.Prev;
			delNode.Prev!.Next = delNode.Next;
		}
	}

	public string ReadForward(string separator = " -> ")
	{
		if (Head == null || Tail == null) return "";
		if (Head == Tail) return Head.ToString()!;
		StringBuilder sb = new();
		DoubleNode<T> _head = Head!;
		DoubleNode<T> _point = Head!;

		sb.Append($"[HEAD]:{_point.Data}{separator}");
		while(_point.Next != _head)
		{
			_point = _point.Next!;
			sb.Append($"{_point.Data}{separator}");
		}

		sb.Append("<HEAD>");

		return sb.ToString();
	}

	public string ReadBackward(string separator = " -> ")
	{
		if (Head == null || Tail == null) return "";
		if (Head == Tail) return Tail.ToString()!;
		StringBuilder sb = new();
		DoubleNode<T> _tail = Tail!;
		DoubleNode<T> _point = Tail!;

		sb.Append($"[TAIL]:{_point.Data}{separator}");
		while(_point.Prev != _tail)
		{
			_point = _point.Prev!;
			sb.Append($"{_point.Data}{separator}");
		}

		sb.Append("<TAIL>");

		return sb.ToString();
	}
}

public class DoubleNode<T>
{
	public DoubleNode<T>? Prev { get; set; }
	public DoubleNode<T>? Next { get; set; }
	public T? Data { get; set; }
	public DoubleNode(T startingData) => Data = startingData;
	public override string ToString()
	{
		if (Data == null) return "NULL";
		else return Data.ToString()!;
	}
}
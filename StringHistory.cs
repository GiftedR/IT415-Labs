

using System.Text;

public class StringHistory
{
	private StringBuilder sb;
	private Stack<string> history = new();

	public StringHistory(string startingString = "")
	{
		sb = new(startingString);
	}

	public void Append(string s)
	{
		history.Push(sb.ToString());
		sb.Append(s);
	}

	public void DeleteLastChar()
	{
		history.Push(sb.ToString());
		sb.Remove(sb.Length - 1, 1);
	}

	public void Undo()
	{
		if (history.Count > 0)
			sb = new(history.Pop());
		else
			Console.WriteLine("Attempted to undo, but there is nothing to undo.");
	}

	public override string ToString() => sb.ToString();
}
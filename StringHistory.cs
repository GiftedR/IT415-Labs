

using System.Text;

public class StringHistory
{
	private StringBuilder sb;
	private Stack<string> history = new();

	public StringHistory(string startingString = "")
	{
		sb = new(startingString);
	}

	/// <summary>
	/// Adds a new item to the string and the histor
	/// </summary>
	/// <param name="s">The item to be added</param>
	/// <remarks>Time: O(2n) - At worst case both the internal StringBuilder and the internal Stack would need to resize at the same time and copy their internal arrays</remarks>
	public void Append(string s)
	{
		history.Push(sb.ToString());
		sb.Append(s);
	}

	/// <summary>
	/// Deletes the last character of the string
	/// </summary>
	/// <remarks>Time: O(n) - At the worst case the history would need to be resized to handle the new history snapshot.</remarks>
	public void DeleteLastChar()
	{
		history.Push(sb.ToString());
		sb.Remove(sb.Length - 1, 1);
	}

	/// <summary>
	/// Reverts the string to the last history snapshot.
	/// </summary>
	/// <remarks>Time: O(n) - When it undoes properly, it rebuilds the internal stringbuilder with whatever string was in it at the snapshot.</remarks>
	public void Undo()
	{
		if (history.Count > 0)
			sb = new(history.Pop());
		else
			Console.WriteLine("Attempted to undo, but there is nothing to undo.");
	}

	public override string ToString() => sb.ToString();
}
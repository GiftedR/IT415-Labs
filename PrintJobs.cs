

using System.Text;

public class PrintJobs
{
	private Queue<string> jobs = new();

	/// <summary>
	/// Adds an item to the job queue.
	/// </summary>
	/// <param name="jobName">The name of the job to be acted upon</param>
	/// <remarks>Time: O(n) - Each enqueue add to the array. When it needs more space it grows the internal array by double, meaning that the array would need to be copied each growth.</remarks>
	public void Enqueue(string jobName)
	{
		if (!string.IsNullOrEmpty(jobName))
			jobs.Enqueue(jobName);
		else
			Console.WriteLine("WARN: Invalid Job Name");
	}

	/// <summary>
	/// Performs the next job within the new queue.
	/// </summary>
	/// <remarks>Time: O(1) - Always handles the action at the head pointer of the queue, resize is only needed for the Enqueue</remarks>
	public void HandleNextJob()
	{
		string? jobOutput = "";
		if (jobs.TryDequeue(out jobOutput))
			Console.WriteLine(jobOutput!);
		else if (jobs.Count <= 0)
			Console.WriteLine("INFO: No Current Jobs");
		else
			Console.WriteLine("WARN: Job Failed");
	}

	/// <summary>
	/// Checks the next item in the queue.
	/// </summary>
	/// <returns>The next item in the queue, or a default info message</returns>
	public string PeekNext() => jobs.Count > 0 ? jobs.Peek() : "INFO: No Current Jobs";

	public override string ToString()
	{
		StringBuilder sb = new("Current Jobs: ");
		string[] jobCopy = new string[jobs.Count];
		jobs.CopyTo(jobCopy, 0);
		foreach (string jb in jobCopy)
			sb.Append(jb + ", ");

		return sb.ToString()!;
	}
}
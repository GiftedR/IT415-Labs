

using System.Text;

public class PrintJobs
{
	public Queue<string> jobs = new();

	public void Enqueue(string jobName)
	{
		if (!string.IsNullOrEmpty(jobName))
			jobs.Enqueue(jobName);
		else
			Console.WriteLine("WARN: Invalid Job Name");
	}

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
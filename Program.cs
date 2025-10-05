using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		RunArraySample();
		RunStringSample();
	}

	public static void RunArraySample()
	{
		int[] studentIds = { 71892, 65198, 47384, 90873, 74893 };
		Console.WriteLine($"1) Original array {string.Join(',', studentIds)}");

		// Accessing by index
		{
			Console.WriteLine($"1A) Accessing by Index 3, value: {studentIds[3]}");
		}

		// Insert at middle by shifting
		{
			const int insertIndex = 2;
			const int newStudentId = 57389;
			Console.WriteLine($"1B) Insert new value {newStudentId} at index {insertIndex} by shifting.");
			for (int idx = studentIds.Length - 1; idx > insertIndex; idx--)
			{
				studentIds[idx] = studentIds[idx - 1];
			}
			studentIds[insertIndex] = newStudentId;
			Console.WriteLine($"1B) Adjusted array {string.Join(',', studentIds)}.");
		}

		// Delete at middle by shifting
		{
			const int deleteIndex = 1;
			Console.WriteLine($"1C) Deleting value {studentIds[deleteIndex]} at index {deleteIndex} by shifting.");
			for (int idx = deleteIndex; idx < studentIds.Length - 1; idx++)
			{
				studentIds[idx] = studentIds[idx + 1];
			}
			Console.WriteLine($"1C) Adjusted array {string.Join(',', studentIds)}.");
		}
	}

	public static void RunStringSample()
	{
		string students = "James Gunn";
		const int newStudentsCount = 10000;
		Stopwatch sw = new();
		StringBuilder sb;

		Console.WriteLine($"2) Original student string: {students}");
		// Native Concatination
		{
			sw.Start();
			for (int idx = 0; idx < newStudentsCount; idx++)
			{
				students += $", student{idx}";
			}
			sw.Stop();
			Console.WriteLine($"2A) Added {newStudentsCount} student(s) using native concatination for a total time of: {sw.Elapsed}");
		}

		sb = new(students);

		// Stringbuilder Concatination
		{
			sw.Restart();
			for (int idx = newStudentsCount; idx < newStudentsCount * 2; idx++)
			{
				sb.Append($", student{idx}");
			}
			sw.Stop();
			Console.WriteLine($"2B) Added {newStudentsCount} student(s) using stringbuilder for a total time of: {sw.Elapsed}");
		}

		//Formatting the string to be capital
		{
			string[] oldstrings = sb.ToString().Split(',');

			for (int idx = 0; idx < oldstrings.Length; idx++)
			{
				if (oldstrings[idx].Length > 0)
				{
					oldstrings[idx] = char.ToUpper(oldstrings[idx].Trim()[0]) + oldstrings[idx].Trim().Substring(1);
				}
			}
			sb = new(string.Join(", ", oldstrings));
			Console.WriteLine($"2C) Capitalized student names: {sb.ToString(0, Math.Min(sb.Length, 100))}...");
		}
	}
}
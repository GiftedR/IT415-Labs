using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		RunArraySample();
		RunStringSample();
		RunListSample();
		RunPerformanceSample();
		RunPerformanceSample();
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

	public static void RunListSample()
	{
		List<string> students = ["Bob Alec", "Kyle Barr", "Ronald Eksill"];
		Console.WriteLine($"3) Original student string: {string.Join(", ", students)}");

		// Adding to the end
		{
			students.Add("Bob Barker");
			Console.WriteLine($"3A) After adding a student to the end: {string.Join(", ", students)}");
		}

		// Inserting into the middle
		{
			students.Insert(2, "Gabe Newell");
			Console.WriteLine($"3B) After inserting a student at index 2: {string.Join(", ", students)}");
		}

		// Removing at the end
		{
			students.RemoveAt(students.Count - 1);
			Console.WriteLine($"3C) After removing a student from the end: {string.Join(", ", students)}");
		}

		// Removing from the middle
		{
			students.RemoveAt(1);
			Console.WriteLine($"3D) After removing a student from index 1: {string.Join(", ", students)}");
		}

		// Checking if a name exists
		{
			Console.WriteLine($"3E) Students {string.Join(", ", students)} contains Ronald Eksill: {students.Contains("Ronald Eksill")}");
		}
	}

	public static void RunPerformanceSample()
	{
		const int itemCount = 1000000;
		Stopwatch sw = new();
		string[] array = new string[itemCount];
		List<string> list;

		for (int idx = 0; idx < itemCount; idx++)
			array[idx] = "123456";

		list = [.. array];

		Console.WriteLine($"4) Starting with arrays and list of {itemCount} item(s)");
		// Insert at array 0
		{
			sw.Start();
			const int insertIndex = 0;
			const string newItem = "654321";
			Array.Resize(ref array, array.Length + 1);
			for (int idx = array.Length - 1; idx > insertIndex; idx--)
			{
				array[idx] = array[idx - 1];
			}
			array[insertIndex] = newItem;
			sw.Stop();
			Console.WriteLine($"4A) Inserted into an array at index {insertIndex} for a total time of {sw.Elapsed}");
		}

		// Insert at list 0
		{
			sw.Restart();
			list.Insert(0, "654321");
			sw.Stop();
			Console.WriteLine($"4B) Inserted into a list at index 0 for a total time of {sw.Elapsed}");
		}

		// Insert at array end
		{
			sw.Restart();
			Array.Resize(ref array, array.Length + 1);
			array[array.Length - 1] = "888888";
			sw.Stop();
			Console.WriteLine($"4C) Inserted into an array at index {array.Length - 1} for a total time of {sw.Elapsed}");
		}

		// Insert at list end
		{
			sw.Restart();
			list.Insert(list.Count - 1, "888888");
			sw.Stop();
			Console.WriteLine($"4D) Inserted into an list at index {list.Count - 1} for a total time of {sw.Elapsed}");
		}
	}
}
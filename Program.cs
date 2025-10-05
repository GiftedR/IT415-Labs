using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

internal class Program
{
	private static void Main(string[] args)
	{
		RunArraySample();
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
}
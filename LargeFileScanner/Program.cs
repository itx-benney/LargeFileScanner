/*
    Author : @itx-benney
	Updated in : SAT 20 May 2023
 */
using System;
using System.IO;using System.Linq;

namespace LargeFileScanner;

public static class Program
{
	public static void Main()
	{
		long largeFileSizeInMB = 50; //LARGE FILE SIZE IN MB: CHANGE AS YOU LIKE

		Console.WriteLine("Scanning your device for large files...\n");
		ScanFiles("/storage/emulated/0/"); //CHANGE WITH UR LOCAL PATH

		void ScanFiles(string localPath)
		{
			string[] files = Directory.GetFiles(localPath, "*", SearchOption.AllDirectories);
			var largeFiles = from string file in files
							 where IsLargeFile(file)
							 select file;
			if (!(largeFiles.ToArray().Length <= 0))
			{
				foreach (string largeFile in largeFiles)
				{
					Console.WriteLine($"{largeFile}\n");
				}
			}
			else
			{
				Console.WriteLine("There are no large file in your device");
			}
		}
		bool IsLargeFile(string fileName)
		{
			long sizeInBytes = new FileInfo(fileName).Length;
			long sizeInMB = sizeInBytes / (1024 * 1024);

			if (sizeInMB >= largeFileSizeInMB)
			{
				return true;
			}
			return false;
		}
	}
}

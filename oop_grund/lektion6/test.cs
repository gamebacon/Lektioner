using System.IO;
using System;

public class Test {

	public static void Main(string[] args) {
		
		DirectoryInfo thisD = new DirectoryInfo("." + @"\Test");
		string filePath = thisD.FullName + @"\fileTest.txt";
		//Console.WriteLine(thisD.FullName);

		Directory.CreateDirectory(thisD.FullName);
		File.WriteAllText(filePath, "Hey!\nHows it hanging?");

		string[] lines = File.ReadAllLines(filePath);
		
		foreach(string line in lines) {
			Console.WriteLine(line);
		}
	}

}

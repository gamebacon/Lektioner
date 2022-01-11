using System;
using System.IO;

class One {
	public static void Main(string[] args) {
		new One();
	}

	public One() {
	
		Console.Write("Enter name: ");
		string name = Console.ReadLine();

		Console.Write("Enter age: ");
		int age = Int32.Parse(Console.ReadLine());

		Console.WriteLine("Saving...");


		DirectoryInfo dInfo = new DirectoryInfo(".");

		string filePath = dInfo.FullName + @"\nameAge.txt";
		File.WriteAllText(filePath, name + "\n" + age);

		Console.WriteLine(File.OpenText(filePath).ReadToEnd());
	}
}

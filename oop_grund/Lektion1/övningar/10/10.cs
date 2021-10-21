using System;
using System.Collections.Generic;

public class Övning10 {
	public static void Main(string[] args) {
		new Övning10();
	}

	public Övning10() {
		List<string> strings = new List<string>();
		for(int i = 0; i < 5;) {
			Console.Write("Enter a unique string: " );
			string str = Console.ReadLine();
			if(strings.Contains(str)) {
				Console.WriteLine("This string already exists!");
				continue;
			} else {
				strings.Add(str);
				i++;
			}
		}
		
		Console.WriteLine("You entered: ");

		foreach(string str in  strings) {
			Console.Write(str + " ");
		}
	}

}

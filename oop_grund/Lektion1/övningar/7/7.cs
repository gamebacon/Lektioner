using System;
public class Övning7 {

	public static void Main(string[] args) {
		new Övning7();
	}

	public Övning7() {
		string[] names = {"William", "Tony", "Niklas"};		
		foreach(string name in names) {
			Console.WriteLine(name);
		}
	}
}

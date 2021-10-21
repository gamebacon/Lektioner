using System;

public class Övning2 {

	public static void Main(string[] args) {
		new Övning2();
	}


	public Övning2() {
		Djur apa = new Djur("banan", "apple", "körv");
		Djur hund = new Djur("Henrik", 3);

		Console.WriteLine("Totala Djur: " + Djur.totalaDjur);
	}
}

public class Djur {
	public static int totalaDjur = 0;

	string name;
	int age;

	public Djur() {
		totalaDjur++;
	}

	public Djur(string name) {
		this.name = name;
	}

	public Djur(params string[] foods) : this() {

		foreach(string food in foods) {
			Console.WriteLine("I like to eat " + food);
		}

	}

	public Djur(int age) {
		this.age = age;
	}
	public Djur(string name, int age) : this() {
		this.name = name; 
		this.age = age;
	}

}

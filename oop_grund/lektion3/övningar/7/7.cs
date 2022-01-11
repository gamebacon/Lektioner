using System;
using System.Collections.Generic;

public class Övning7 {

	public static void Main(string[] args) {
		List<Däggdjur> däggdjur = new List<Däggdjur>();

		Däggdjur dog = new Dog();
		däggdjur.Add(dog);

		Däggdjur cow = new Cow();
		däggdjur.Add(cow);

		Däggdjur cat = new Cat();
		däggdjur.Add(cat);

		Däggdjur wolf = new Wolf();
		däggdjur.Add(wolf);

		Däggdjur sheep = new Sheep();
		däggdjur.Add(sheep);

		foreach(Däggdjur djur in däggdjur) {
			djur.MakeSound();
		}
		
		
		
	}

}

public abstract class Däggdjur {
	public abstract void MakeSound(); 
}

public class Dog : Däggdjur {

	public override void MakeSound() {
		Console.WriteLine("Woof");
	}	 

}

public class Cat : Däggdjur {

	public override void MakeSound() {
		Console.WriteLine("Miow");
	}	 

}

public class Wolf : Däggdjur {

	public override void MakeSound() {
		Console.WriteLine("Aoooooouuuw");
	}	 

}

public class Sheep : Däggdjur {

	public override void MakeSound() {
		Console.WriteLine("Beeeeeh");
	}	 

}

public class Cow : Däggdjur {

	public override void MakeSound() {
		Console.WriteLine("Muuuuuuh");
	}	 

}

using System;
using System.Collections.Generic;

public class �vning7 {

	public static void Main(string[] args) {
		List<D�ggdjur> d�ggdjur = new List<D�ggdjur>();

		D�ggdjur dog = new Dog();
		d�ggdjur.Add(dog);

		D�ggdjur cow = new Cow();
		d�ggdjur.Add(cow);

		D�ggdjur cat = new Cat();
		d�ggdjur.Add(cat);

		D�ggdjur wolf = new Wolf();
		d�ggdjur.Add(wolf);

		D�ggdjur sheep = new Sheep();
		d�ggdjur.Add(sheep);

		foreach(D�ggdjur djur in d�ggdjur) {
			djur.MakeSound();
		}
		
		
		
	}

}

public abstract class D�ggdjur {
	public abstract void MakeSound(); 
}

public class Dog : D�ggdjur {

	public override void MakeSound() {
		Console.WriteLine("Woof");
	}	 

}

public class Cat : D�ggdjur {

	public override void MakeSound() {
		Console.WriteLine("Miow");
	}	 

}

public class Wolf : D�ggdjur {

	public override void MakeSound() {
		Console.WriteLine("Aoooooouuuw");
	}	 

}

public class Sheep : D�ggdjur {

	public override void MakeSound() {
		Console.WriteLine("Beeeeeh");
	}	 

}

public class Cow : D�ggdjur {

	public override void MakeSound() {
		Console.WriteLine("Muuuuuuh");
	}	 

}

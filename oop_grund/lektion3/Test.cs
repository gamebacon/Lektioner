using System;
using System.Collections.Generic;

public class Driver {

	public static void Main(string[] args) {
		
		Person person = new Person("Oskar");
		Student student = new Student("Maria");

		List<Person> list = new List<Person>();

		foreach(Person p in list) {
			p.Yo();
		}
	}


}

public class Student : Person {
	
	public Student(string name) : base(name) {

	}

	public void override Yo() {
		Console.WriteLine("(Student) " + name + " says Yo!");
	}

}

public class Person {

	public static int numberOfPeople;
	public string name {get; set; }

	public string address {get; private set;}
	public int age;
	public readonly Calculator calc = new Calculator();


	public string this[string key] {
		get { return "I got a " + key; }
	}

	public virtual void Yo() {
		Console.WriteLine("(Person) " +  name + " says Yo!");
	}


	public Person() {
		numberOfPeople++;
	}

	public Person(string name) : this() {
		this.name = name;
	}

	public Person(int age, string name) : this(name) {
		this.age = age;
	}

	public void sayHi() {
		Console.WriteLine("Hi " + name);
	}

	public void SayHi(params string[] arr) 
	{
		for(int i = 0; i < arr.Length; i++) {
			Console.WriteLine(name + " says hi to " + arr[i]);
		}
	}

}

public class Calculator {

	
	public void Add(ref int num) {
		num++;
	}


}


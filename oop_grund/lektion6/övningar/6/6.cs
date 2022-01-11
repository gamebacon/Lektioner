using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

//using System.Random;

public class Six {
	
	public static void Main(string[] args) {
		DirectoryInfo dInfo = new DirectoryInfo(".");

		Random random = new Random();
		string[] names = {"Oscar", "Karin", "Peter", "Pär", "Annette", "Julius", "Lukas", "Damien", "Tony", "Niklas"};
		List<Kid> kids = new List<Kid>();
		
		foreach(string name in names) {
			Kid kid = new Kid(name, random.Next(2, 10), random.NextDouble() > .5f);
			kids.Add(kid);
		}
		
	}

}

public class Kid {

	public string name;
	public int age;
	public bool hasBeenGood;


	public Kid(string name, int age, bool hasBeenGood) {
		this.name = name;
		this.age = age;
		this.hasBeenGood = hasBeenGood;
	}

}



using System;
using System.Collections.Generic;

public class Övning9 {
	public static void Main(string[] args) {
		new Övning9();
	}

	public enum City {
		none,
		London,
		Paris,
		Stockholm,
		Moskva,
		Berlin
	}
	
	List<City> London = new List<City>(new City[]{City.Paris, City.Stockholm});
	List<City> Stockholm = new List<City>(new City[]{City.London, City.Paris, City.Moskva});
	List<City> Moskva = new List<City>(new City[]{City.Stockholm, City.Berlin});
	List<City> Berlin = new List<City>(new City[]{City.Moskva, City.Paris});
	List<City> Paris = new List<City>(new City[]{City.Berlin, City.Stockholm, City.London});


	Dictionary<City, List<City>> cityAndDestinations = new Dictionary<City, List<City>>();

	City currentCity = City.London;


	public Övning9() {
			cityAndDestinations.Add(City.London, London);
			cityAndDestinations.Add(City.Stockholm, Stockholm);
			cityAndDestinations.Add(City.Moskva, Moskva);
			cityAndDestinations.Add(City.Berlin, Berlin);
			cityAndDestinations.Add(City.Paris, Paris);
		
		do {
			Console.WriteLine("\n\n\nYou are now in " + currentCity + ".");
			Console.Write("Current depatures:");

			foreach(City city in cityAndDestinations[currentCity]) {
				Console.Write(" *" + city);
			}

			Console.WriteLine("\nWhere would you like to fly? or stay by typing 'exit'.");
			string str = Console.ReadLine();
			
			if(str == "exit")
				break;

			City dep = ParseCity(str);
			if(dep == City.none || !cityAndDestinations[currentCity].Contains(dep)) {
				Console.WriteLine("Invalid departure!");
			} else {
				Console.WriteLine("*Flying to " + dep + "*");
				currentCity = dep;
			}

		} while(true);

		Console.WriteLine("Enjoy your stay!");
	}
		
	private City ParseCity(string str) {
		City city = currentCity;
		try {
			city = (City) Enum.Parse(typeof(City), str);
		} catch(ArgumentException) {};
		return city;	
	}
}


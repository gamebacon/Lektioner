using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

class Four {

	public static void Main(string[] args) {
		new Four();
	}

	public Four() {
		int days = 0;
		Dictionary<string, int> travelers = LoadTravelers();

		foreach(KeyValuePair<string, int> key in travelers) {
			Console.WriteLine(key.Key + " has traveled " + (key.Value + days) + " days!");
		}
		
		while(true) {
			Console.WriteLine("1(Add a traveler) 2(Next day) 3(Exit)");
			int choise = -1;
			
			try {
				string input = Console.ReadLine();
				choise = Int32.Parse(input);
			} catch(Exception) { continue; }

			if(choise == 1) {
						string name;
				while(true) {
						Console.Write("Enter name: ");
						name = Console.ReadLine();
						if(travelers.ContainsKey(name)) {
							Console.WriteLine("{0} is already traveling! do you want to override?", name);
							if(Console.ReadLine().Equals("yes")) {
								travelers.Remove(name);
								break;
							}
						} else {
							break;
						}

				}

				int travelDays = 0;

				while(true) {
					Console.WriteLine("How many days is {0} travling for?", name);
					try {
						travelDays = Int32.Parse(Console.ReadLine());
						if(travelDays < 1)
							continue;
						else
							break;
					} catch(Exception)  {}
				}

				Console.WriteLine("{0} is now traveling for {1} days!", name, travelDays);
				travelers.Add(name, travelDays);
				

			} else if(choise == 2) {
				Console.WriteLine("Next day..");

				foreach(string key in travelers.Keys.ToList()) {
					travelers[key]--;
					
					if(travelers[key] == 0) {
						Console.WriteLine("{0} arrived at their destination!", key);
						travelers.Remove(key);
					}
						
				}
				
				
			} else if(choise == 3){
				Save(travelers);
				break;
			}
		}

	}

	
	public Dictionary<string, int> LoadTravelers() {
		Dictionary<string, int> travelers = new Dictionary<string, int>();

		DirectoryInfo dInfo = new DirectoryInfo("." + @"\travelers.txt");
		
		
		try {
				string[] lines = File.ReadAllLines(dInfo.FullName);

				foreach(string line in lines) {
					string name = line.Split(',')[0];
					int days = Int32.Parse(line.Split(',')[1]);
					
					travelers.Add(name, days);
				}

		} catch(FileNotFoundException) {}
	
		return travelers;
	}

	public void Save(Dictionary<string, int> travelers) {
		DirectoryInfo dInfo = new DirectoryInfo("." + @"\travelers.txt");

		string text = "";

		foreach(KeyValuePair<string, int> key in travelers) {
			text += key.Key + "," + (key.Value) + "\n";
		}

		File.WriteAllText(dInfo.FullName, text);
	}



}

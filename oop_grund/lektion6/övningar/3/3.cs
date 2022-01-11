using System.IO;
using System.Collections.Generic;
using System;


public class Three {
	public static void Main(string[] args) {
		
		new Three();

	}	

	public enum Club {
		none,
		Putter = 1,
		Iron = 6,
		Driver = 9
	}

	public Three() {

		Random random = new Random();
		
		int totalHoleLength;
		int distanceToHole;


		while(true) {
				Club club = Club.none;
				int totalSwings = 0;
				int power;

				Console.WriteLine("Starting a new game..");
				totalHoleLength = random.Next(150) + 50;
				distanceToHole = totalHoleLength; 

				do {
						Console.WriteLine(String.Format("It's {0} meters to the current hole.", Math.Abs(distanceToHole)));
						
						do {
						Console.WriteLine("Please choose a club between the following options.");

						foreach(Club c in Enum.GetValues(typeof(Club))) {
							if(c == Club.none)
								continue;

							Console.WriteLine("* " + c);
						}

						club = GetClub(Console.ReadLine());

						} while(club == Club.none);

						Console.WriteLine("You choose a " + club + " club!");
						
							int powerInput = -1;
						do {
							Console.WriteLine("Choose the amount of power to use 1-10.");
							powerInput = ParseInt(Console.ReadLine());
							power = powerInput * ((int) club);

						} while(powerInput < 0 || powerInput > 10);
						
						totalSwings++;
						Console.WriteLine("Good shot!"); 

						distanceToHole = (distanceToHole > 0 ? distanceToHole - power : distanceToHole + power);
				} while (distanceToHole != 0);

			Console.WriteLine(String.Format("You finished after {0} shots!", totalSwings));

			float score = (float) totalHoleLength/totalSwings;
			
			if(score > getHighscore()) {
				setHighscore(score);
			}

			Console.WriteLine("Do you want to play again?");
			string answer = Console.ReadLine();

			if(!answer.ToLower().Equals("yes")) {
				Console.WriteLine("Come back soon!");
				break;
			}
		} 
	
		
	}

	
	
	private void setHighscore(float score) {
		Console.WriteLine(String.Format("New highscore! ({0:0.00})", score));
		DirectoryInfo dInfo = new DirectoryInfo(".");
		string filePath = dInfo.FullName + @"\highscore.txt";
		File.WriteAllText(filePath, score.ToString("0.##"));
	} 

	private float getHighscore() {
		DirectoryInfo dInfo = new DirectoryInfo("." + @"\highscore.txt");
		float highscore = (float) Convert.ToDouble(File.ReadAllLines(dInfo.FullName)[0]);
		return highscore;
	}


	private Club GetClub(string str) {
		Club club = Club.none;

		try {
			club = (Club) Enum.Parse(typeof(Club), str);
		} catch (ArgumentException) {};

		return club;
	} 
	
	private int ParseInt(string str) {
		int power = -1;
		try {
			power = Int32.Parse(str);
		} catch(Exception) {}; 
		return power;
	}

}

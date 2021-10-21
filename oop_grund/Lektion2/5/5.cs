using System;


public class Övning5 {


	public static void Main(string[] args) {
		
		new Övning5();

	}	

	public enum Club {
		none,
		Putter = 1,
		Iron = 6,
		Driver = 9
	}

	public Övning5() {
		Random random = new Random();
		Club club = Club.none;
		
		int totalSwings = 0;
		int power;
		int distanceToHole;

		Console.WriteLine("Starting a new game..");
		distanceToHole = random.Next(150) + 50;

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
				
				do {
					Console.WriteLine("Choose the amount of power to use 1-10.");
					power = ParseInt(Console.ReadLine()) * ((int) club);
				} while(power < 0);
				
				totalSwings++;
				Console.WriteLine("Good shot!"); 

				distanceToHole = (distanceToHole > 0 ? distanceToHole - power : distanceToHole + power);
		} while (distanceToHole != 0);
		
		Console.WriteLine(String.Format("Good job, you finished after {0} swings!", totalSwings));
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

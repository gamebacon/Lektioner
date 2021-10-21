using System;
public class Övning5 {

	public static void Main(string[] args) {
		new Övning5();
	}


	public Övning5() {
		try { 

			Console.Write("Enter max speed: ");
			int maxSpeed = Parse(Console.ReadLine());
			Console.Write("Enter actual speed: ");
			int actualSpeed = Parse(Console.ReadLine());

			if(actualSpeed <= maxSpeed) { //is ok
				Console.WriteLine("You're Valid!");
			} else {
				int overLimit = actualSpeed-maxSpeed;
				if(overLimit >= 30) {
					Console.WriteLine(String.Format(
					"You lost your lisence for going {0}km/h too fast!",
					overLimit
					));
				} else {
					float fine = overLimit * 120;
					Console.WriteLine(String.Format(
					"You were fined {0:C2} for going {1}km/h too fast!",
					fine, overLimit
					));
				}
			}



		} catch(Exception) {Console.WriteLine("Invalid input");}
	}



	public int Parse(string str) {
		int num = -1;
		num = Int32.Parse(str);
		if(num < 0)
			throw new Exception();
		return num;
	}
}

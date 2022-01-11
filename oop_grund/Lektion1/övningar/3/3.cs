using System;

public class Övning3 {

	public static void Main(string[] args) {
		new Övning3();
	}

	public Övning3() {
		Console.WriteLine("Enter a number between 1-10");
		string str = Console.ReadLine();
		int num = -1;

		try {
			num = Int32.Parse(str);
			if(num > 10 || num < 1)
				num = -1;

		} catch (Exception) {

		};

		if(num == -1)
			Console.WriteLine("Not what i asked for!!!");
		else
			Console.WriteLine("You entered " + num + ", Good job!");
		
	}

}

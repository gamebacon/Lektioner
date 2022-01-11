using System;
using System.Collections.Generic;

public class Övning11 {
	public static void Main(string[] args) {
		new Övning11();
	}

	public Övning11() {
		List<int> nums = new List<int>();

		do {
		int newNum = -1;
		Console.Write("Enter a num: ");

		string str = Console.ReadLine();

		if(str == "exit")
			break;
		
		try {
			newNum = Int32.Parse(str);
		} catch(Exception) { Console.WriteLine("Invalid input!"); continue;}

		if(!nums.Contains(newNum))
			nums.Add(newNum);

		} while (true);


		Console.WriteLine("You entered " + nums.Count + " unique numbers!");

	}


}

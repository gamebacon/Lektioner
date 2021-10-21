using System;
using System.Collections.Generic;
public class Övning8 {

	public static void Main(string[] args) {
		new Övning8();
	}

	public Övning8() {
		int sum = 0;
		
		while(true) {
			Console.Write("Enter number: ");
			int num = -1;
			string str = Console.ReadLine();

			try {
				num = Int32.Parse(str);
				sum+=num;
			} catch (Exception) {
			if(str == "exit")
				break;
			else
				Console.WriteLine("Invalid input!");
			}
		} 

		Console.WriteLine("Total sum: " + sum);
			

	}
}

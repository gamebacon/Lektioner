using System;

public class Övning9 {
	public static void Main(string[] args) {
		if(args.Length == 1) {
			int num = Int32.Parse(args[0]);
			Console.WriteLine(factorial(num));
		} else
			Console.WriteLine("No arguments found");
			
	}



	public static int factorial(int num) {
		return num == 0 ? 1 : (num * factorial(num-1));
	}

}

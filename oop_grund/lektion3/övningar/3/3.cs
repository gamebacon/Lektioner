using System;
public class Övningar3 {
	public static void Main(string[] args) {
		new Övningar3();
	}

	public Övningar3() {
		int number = 10;
		int copy = 0;

		Multiply(ref number, out copy);

		Console.WriteLine(number);
		Console.WriteLine(copy);
	}

	public static void Multiply(ref int num, out int dup) {
		num *= num;	
		dup = num;
	} 


}

		

using System;
public class �vningar3 {
	public static void Main(string[] args) {
		new �vningar3();
	}

	public �vningar3() {
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

		

using System;

public class Övning1 {
	public static void Main(string[] args) {
		new Övning1();
	}


	public Övning1() {
		Console.WriteLine(Calculator.Add(5,4));
		Console.WriteLine(Calculator.Subtract(5,4));
		Console.WriteLine(Calculator.Multiply(5,4));
		Console.WriteLine(Calculator.Devide(5,4));
	}
}

public class Calculator {
	public static int Add(int one, int two) {
		return one+two;
	}
	public static int Subtract(int one, int two) {
		return one-two;
	}
	public static int Multiply(int one, int two) {
		return one*two;
	}
	public static int Devide(int one, int two) {
		return one/two;
	}

}

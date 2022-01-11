using System;

public class Övning4 {

	public static void Main(string[] args) {
		new Övning4();
	}


	public Övning4() {

		int one = -1;
		int two= -1;

		try {
			Console.Write("Enter number one: ");
			one = Int32.Parse(Console.ReadLine());

			Console.Write("Enter number two: ");
			two = Int32.Parse(Console.ReadLine());

			Console.WriteLine(String.Format("{0} + {1} = {2}", one, two, one + two));
			Console.WriteLine(String.Format("{0} - {1} = {2}", one, two, one - two));
			Console.WriteLine(String.Format("{0} / {1} = {2,00}", one, two, ((float) one / two)));
			Console.WriteLine(String.Format("{0} * {1} = {2}", one, two, one * two));
			Console.WriteLine(String.Format("Higest: {0}",one > two ? one : two));

		} catch(Exception e) {Console.WriteLine("Invalid input!"); Console.WriteLine(e.ToString());}

		


		
	}

}

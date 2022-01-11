using System;

public class Övning4 {


	public static void Main(string[] args) {
		new Övning4();
	}

	public Övning4() {

		int max = 3;
		string[] input = Console.ReadLine().Split(' ');

		for(int i = 0; i < input.Length; i++) {

			if(i >= max) {
				Console.WriteLine("...");
				break;
			} 

			Console.Write(input[i] + " ");
		}
		


	}


}

using System;

public class �vning4 {


	public static void Main(string[] args) {
		new �vning4();
	}

	public �vning4() {

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

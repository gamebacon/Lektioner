using System;

public class Övning1 {

	public const int DEFAULT_MAX = 100;

	private int numberToGuess;
	private int guess;
	private int guesses;

	public static void Main(string[] args) {

		int maxNum = args.Length == 1 ? Övning1.Parse(args[0]) : Övning1.DEFAULT_MAX;

		new Övning1().Start(maxNum);

	}

	private void Start(int max) {

		numberToGuess = new Random().Next(max);

		Console.WriteLine("Guess a number from 0-" + max + ".");

		do {
			Console.Write("Guess: "); 
			guess = Övning1.Parse(Console.ReadLine());

			guesses++;

			if(guess == -1) {
				Console.WriteLine("Invalid guess!");
				break;
			} else if (guess < numberToGuess)
				Console.WriteLine("Too small!");
			else if (guess > numberToGuess)
				Console.WriteLine("Too big!");
			else
				Console.WriteLine("Correct! it took you " + guesses + " tries to guess " + numberToGuess + "!");


		} while(guess != numberToGuess);


	}


	private static int Parse(string str) {
		int output = -1;

		try {
			output = Int32.Parse(str);

		} catch(Exception) {};

		return output;
	}



}

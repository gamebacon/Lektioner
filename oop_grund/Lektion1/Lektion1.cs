using System;

namespace Lektion1 {


	public class Test {


		public static void Main(string[] args)
		{


			Random random = new Random();
			bool playing = true;

			while(playing) {

			int num1 = random.Next(2,10);
			int num2 = random.Next(2,10);

			int product = num1 * num2;

			Console.Write(String.Format(
			"{0} * {1} = ", num1, num2
			));
			
			int input = -1;

			try {

				input = Int32.Parse(Console.ReadLine());


			} catch (FormatException) {
				Console.WriteLine("Numbers only!!!");
				continue;
			};

			if(input == product)
				Console.WriteLine("Correct!");
			else {
				Console.WriteLine("Wrong!");
				playing = false;
			}

			}

		}

	}

}

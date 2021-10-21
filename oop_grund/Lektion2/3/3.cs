using System;

public class Övning3 {


	public static void Main(string[] args) {

		new Övning3();

	}

	public enum Weapon {
		none = 0,
		sten = 1,
		sax = 2,
		påse = 3
	}



	public Övning3() {

		Start();

	}

	private void Start() {


		do {
			Console.Write("Choose your weapon: ");

			string input = Console.ReadLine();
			Weapon user = parse(input.ToLower());
			Weapon pc = (Weapon) (new Random().Next(3) + 1);

			if(user == Weapon.none) {
				Console.WriteLine(String.Format("Invalid weapon '{0}'", input));
				continue;
			}

			Console.WriteLine(String.Format("{0} VS {1}", user, pc));

			if (user == pc) {
				Console.WriteLine("Draw! Try again.");
				continue;
			} else {

				bool win = IsWin(user, pc);

				if(win) {
					Console.WriteLine("You win!");
				} else {
					Console.WriteLine("You lose!");
				}

				break;
			}



		} while (true);

	}


	private Weapon parse(string input) {
		Weapon weapon = Weapon.none;
		
		try {
			weapon = (Weapon) Enum.Parse(typeof(Weapon), input);
		} catch (ArgumentException) {

		}

		return weapon;
	}

	private bool IsWin(Weapon user, Weapon pc) {
		int n1 = (int) user;
		int n2 = (int) pc;

		Console.WriteLine(n1 + ":" + n2);

		return n1 < n2 || n1 + n2 == 4;
	}
}

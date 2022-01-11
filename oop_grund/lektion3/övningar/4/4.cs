using System;

public class Övning4{

	public static void Main(string[] args) {
		new Övning4();
	}


	public Övning4() { 


		GameState state = GameState.init;
		string promptString = "Define a ship or type \'help\' for instructions.";
		int[,] AIBoard = new int[10,10];
		int[,] userBoard = new int[10,10];
	
		InitAI(AIBoard);
		string[] ships = Enum.GetNames(typeof(ShipType));

		for(int i = 0; i < ships.Length;) {
			ShipType type = (ShipType) Enum.Parse(typeof(ShipType), ships[i]);

			Console.WriteLine(promptString);
			Console.Write(Upper(type.ToString()) + ": ");

			string userInput = Console.ReadLine();

			if(userInput == "help") {
				Help();
				continue;
			} else if(userInput == "exit") {
				break;
			}

			Ship ship = ParseShip(userInput.ToLower() + " " + type);

			if(ship == null) {
				Help();
				continue;
			}

			if(!TryPlaceShip(ship, userBoard)) {
				Console.WriteLine("It can't fit there!");
				continue;
			} else {
				Console.WriteLine(String.Format("{0} placed on {1}!", type, userInput));
				i++;
			}

			DisplayBoard(userBoard);
 		}

		state = GameState.game;

		while(state = GameState.game) { 
			// game
		}


	}

		public void InitAI(int[,] board) {
			Random random = new Random();
			string[] ships = Enum.GetNames(typeof(ShipType));

			for(int i = 0; i < ships.Length;) {
				ShipType type = (ShipType) Enum.Parse(typeof(ShipType), ships[i]);

				char c = (char) (random.Next(97, 107));
				int num = random.Next(1, 10);
				Direction dir = (Direction) random.Next(4); 

				string str = String.Format("{0}{1} {2} {3}", c, num, dir, ships[i]).ToLower();

				Console.WriteLine(str);

				Ship ship = ParseShip(str);
				
				if(TryPlaceShip(ship, board)) {
					i++;
				}
			}	
		}


		public void Help() {

				string helpString = "\nEnter a starting cord (a-j + 1-10) and a direction (left, right, up, down)\nFormat: <cord> <direction>";

				Console.WriteLine("-------HELP MENU---------");

				Console.WriteLine("Ships and their sizes:");

				foreach(string ship in Enum.GetNames(typeof(ShipType))) {
					ShipType type = (ShipType) Enum.Parse(typeof(ShipType), ship);
					Console.WriteLine(String.Format("    {0}: {1}", Upper(ship), (int) type));
				}

				int[,] exampleBoard = new int[10,10];
				Ship exampleShip = ParseShip("b3 down destroyer");
				TryPlaceShip(exampleShip, exampleBoard);

				Console.WriteLine(helpString);
				Console.WriteLine("Example for Destroyer, \"b3 down\" gives:");
				DisplayBoard(exampleBoard);
				Console.WriteLine("-------HELP MENU---------");
			
		}
			
		public bool TryPlaceShip(Ship ship, int[,] board) {
			for(int i = 0; i < 2; i++) {
					int x = 0;
					int y = 0;

					for(int size = 0; size < (int) ship.type; size++) {


						int locX = ship.startPos.x - 1 + x;
						int locY = ship.startPos.y - 1 + y;

						//Console.WriteLine("Locs: " + locX + ", " + locY);
						
						if(locX >= 10 || locX < 0 || locY >= 10 || locY < 0)
							return false;
						

						if(board[locX, locY] == 0) {
							if(i == 1) {
								board[locX,locY] = 1;
							}
						} else
							return false;

						x += (ship.dir == Direction.right ? 1 : ship.dir == Direction.left ? -1 : 0);
						y += (ship.dir == Direction.up ? -1 : ship.dir == Direction.down ? 1 : 0);
						
					}
		}
	return true;
	}

		public void DisplayBoard(int[,] board) {
			string abc = "ABCDEFGHIJ";

			Console.WriteLine("    1 2 3 4 5 6 7 8 9 10\n");

			for(int y = 0; y < board.GetLength(1); y++) {
				for(int x = 0; x < board.GetLength(0); x++) {
					if(x == 0)
						Console.Write(abc[y] + "  ");
					Console.Write(" " + board[x,y]);
				}
				Console.WriteLine("");
			}


		}
		
		public Ship ParseShip(string str) {
			Ship ship = null;

			try {
				string[] args = str.Split(' ');

				Cord cord = new Cord(args[0]);
				Direction dir = (Direction) Enum.Parse(typeof(Direction), args[1]);

				ShipType  type = (ShipType) Enum.Parse(typeof(ShipType), args[2]);

				ship = new Ship(cord, dir, type);
			} catch (Exception e) {
				if(false)
					Console.WriteLine(e.ToString());
			};

			return ship;
		}

		public string Upper(string str) { 
			return Char.ToUpper(str[0]) + str.Substring(1, str.Length-1);
		}

}


public enum GameState {
	init,
	game,
	gameover
}
 



public enum ShipType {
		carrier = 5,
		battleship = 4,
		cruiser = 3,
		submarine = 3,
		destroyer = 2
}

public class Ship {
	public ShipType type {get; private set;}
	public Cord startPos {get; private set;}
	public Direction dir {get; private set;}

	public Ship(Cord startPos, Direction dir, ShipType type) 
	{
		this.startPos = startPos;
		this.dir = dir;
		this.type = type;
		
	}
	
}

public class Cord {
	public int x;
	public int y;

	public Cord(int x, int y) {
		this.x = x;
		this.y = x;
	}

	public Cord(string parse) {
		this.x = Int32.Parse(parse.Substring(1, parse.Length-1));
		this.y = ((int) parse[0]) - 96;

		//Console.WriteLine("x: " + x + "\ny: " + y);

		if(x > 10 || x < 1 || (y > 10 || y < 1))  {
			//Console.WriteLine("ex");
			throw new Exception(); //dont allow this.
		}



	}
	
}



public enum Direction {
	up,
	down,
	left,
	right	
}


using System;
using System.Drawing;

public class Övningar4 {

	public static void Main(string[] args) {
		new Övningar4();
	}


	public Övningar4() { 
		string helpString = "Enter a starting cord (A-J + 1-10) and a direction (left, right, up, down) and a size (1-4)\nFormat: <cord> <direction> <size>\nExample: b3 down 2";
		string promptString = "Define the ship or type \'help\' for instructions.";
		int[,] AIBoard = new int[10,10];
		int[,] userBoard = new int[10,10];

		Console.WriteLine(helpString);
		display(userBoard);
		
		while(true) {
			Console.WriteLine(promptString);
			Console.Write("Ship: ");

			string userInput = Console.ReadLine();

			if(userInput == "help") {
				Console.WriteLine(helpString);
				continue;
			} else if(userInput == "exit") {
				break;
			}

			Ship ship = Parse(userInput.ToLower());

			if(ship == null) {
				Console.WriteLine(helpString);
				continue;
			} else if(!TryPlaceShip(ship, userBoard)) {
				Console.WriteLine("It can't fit there!");
				continue;
			}

			display(userBoard);
 		}


	}
			
		public bool TryPlaceShip(Ship ship, int[,] board) {
	
			for(int i = 0; i < 2; i++) {
					int x = 0;
					int y = 0;
			

					for(int size = 0; size < ship.size; size++) {


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

		public void display(int[,] board) {
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
		
		public Ship Parse(string str) {
			Ship ship = null;

			try {
				string[] args = str.Split(' ');

				Cord cord = new Cord(args[0]);
				Direction dir = (Direction) Enum.Parse(typeof(Direction), args[1]);
				int size = Int32.Parse(args[2]);

				if(size > 4 || size < 1)
					return null;

				ship = new Ship(cord, dir, size);
			} catch (Exception e) {
				if(false)
					Console.WriteLine(e.ToString());
			};

			return ship;
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

public class Ship {
	public Cord startPos {get; private set;}
	public Direction dir {get; private set;}
	public int size {get; private set;}
	
	public Ship(Cord startPos, Direction dir, int size) 
	{
		this.startPos = startPos;
		this.dir = dir;
		this.size = size;
		
	}
	
}

public enum Direction {
	up,
	down,
	left,
	right	
}


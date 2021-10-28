import java.util.Arrays;
import java.util.List;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Scanner;

class Four {
	public static int totalRooms; 

	public static void main(String[] args) {
		new Four();
	}

	public Four() {
		Room hallway = new Hallway();
		Room hallwayBathroom = new HallwayBathroom();
		Room livingroom = new Livingroom();
		Room upperLivingroom = new UpperLivingroom();
		Room stairway = new Stairway();
		Room upperStairway = new UpperStairway();
		Room bathroom = new Bathroom();
		Room basement = new Basement();
		Room diningroom = new Diningroom();
		Room kitchen = new Kitchen();
		Room utilityroom = new Utilityroom();
		Room bedroom = new Bedroom();
		Room masterBedroom = new MasterBedroom();
		Room attic = new Attic();
		Room exitroom = new Exitroom();



		List<Room> exitroomRooms = new ArrayList<Room>(Arrays.asList(new Room[]{}));
		List<Room> hallwayRooms = new ArrayList<Room>(Arrays.asList(new Room[]{livingroom, hallwayBathroom, exitroom}));
		List<Room> hallwayBathroomRooms = new ArrayList<Room>(Arrays.asList(new Room[]{hallway}));
		List<Room> livingroomRooms= new ArrayList<Room>(Arrays.asList(new Room[]{hallway, kitchen,  stairway, bathroom, basement, diningroom}));
		List<Room> upperLivingroomRooms = new ArrayList<Room>(Arrays.asList(new Room[]{upperStairway, attic, bedroom, masterBedroom}));
		List<Room> stairwayRooms = new ArrayList<Room>(Arrays.asList(new Room[]{livingroom, upperStairway}));
		List<Room> upperStairwayRooms = new ArrayList<Room>(Arrays.asList(new Room[]{upperLivingroom, stairway}));
		List<Room> bathroomRooms = new ArrayList<Room>(Arrays.asList(new Room[]{livingroom}));
		List<Room> basementRooms = new ArrayList<Room>(Arrays.asList(new Room[]{livingroom}));
		List<Room> diningroomRooms = new ArrayList<Room>(Arrays.asList(new Room[]{livingroom}));
		List<Room> kitchenRooms = new ArrayList<Room>(Arrays.asList(new Room[]{livingroom}));
		List<Room> utilityroomRooms= new ArrayList<Room>(Arrays.asList(new Room[]{livingroom}));
		List<Room> bedroomRooms = new ArrayList<Room>(Arrays.asList(new Room[]{upperLivingroom}));
		List<Room> masterBedroomRooms = new ArrayList<Room>(Arrays.asList(new Room[]{upperLivingroom}));
		List<Room> atticRooms = new ArrayList<Room>(Arrays.asList(new Room[]{upperLivingroom}));

		HashMap<Room, List<Room>> roomDest = new HashMap<Room, List<Room>>();
		roomDest.put(hallway, hallwayRooms);
		roomDest.put(hallwayBathroom, hallwayBathroomRooms);
		roomDest.put(livingroom, livingroomRooms);
		roomDest.put(upperLivingroom, upperLivingroomRooms);
		roomDest.put(stairway, stairwayRooms);
		roomDest.put(upperStairway, upperStairwayRooms);
		roomDest.put(bathroom, bathroomRooms);
		roomDest.put(basement, basementRooms);
		roomDest.put(diningroom, diningroomRooms);
		roomDest.put(kitchen, kitchenRooms);
		roomDest.put(utilityroom, utilityroomRooms);
		roomDest.put(bedroom, bedroomRooms);
		roomDest.put(masterBedroom, masterBedroomRooms);
		roomDest.put(attic, atticRooms);
		
		Four.totalRooms = roomDest.size();
		
		Player player = new Player(100, 0);

		Scanner scanner = new Scanner(System.in);
		Room currentRoom = hallway;
			
		Util.clear(100);	
		System.out.println("Welcome to the House of Witchcraft!");
		System.out.println("In here you may find treasure or agonoy, be warned!");
		System.out.println("You are currently in " + currentRoom.name);

		while(true) {
			System.out.println(
				String.format(
						"You have %d health and %d coins.",
						player.getHealth(),
						player.coins 
				)
			);

			List<Room> rooms = roomDest.get(currentRoom);

			Room selectedRoom = null;
			System.out.print("Where would you like to go?");

			for(Room room : rooms) {
				System.out.print(String.format(" *[%s]", room.name));
			}

			System.out.print("\nRoom: ");

			String in = scanner.nextLine();


			for(Room room : rooms) {
				if(room.name.equalsIgnoreCase(in)) {
					selectedRoom = room;
					break;
				}
			}
			

			Util.clear(50);

			if(selectedRoom == null) {
				System.out.println("There is no such room as \"" + in + "\".");
			} else {
				if(selectedRoom.equals(exitroom)) {
					System.out.println("Come back soon!");
					player.coins += player.roomsVisited * 15;
					Util.showResults(player);
					break;
				} else {
					System.out.println("Now entering " + selectedRoom.name + "!");
					currentRoom = selectedRoom;
				}

				if(!currentRoom.hasEntered) {
					player.roomsVisited++;
					player.coins += currentRoom.coins;
					System.out.println(String.format("You found %s coins in %s!", currentRoom.coins, currentRoom.name));

					float rand = (float) Math.random();

					if(rand > currentRoom.trapChance) {
						int damage = currentRoom.onTrap(player);
						player.addHealth(-damage);
						if(player.getHealth() <= 0) {
							Util.showResults(player);
							break;
						}
					}

					currentRoom.hasEntered = true;
				}
			}
		}

		


	}

}


class Util {
	
	public static int range(int min, int max) {
		return (int) (Math.random() * ((max-min) + 1)) + min;
	}

	public static void clear(int lines) {
		for(int i = 0; i < lines; i++) {
			System.out.println();
		}
	}
	
	public static void showResults(Player player)  {
		if(player.getHealth() <= 0)
			System.out.println("You died!");

		System.out.println(
			String.format(
				"You finished with %d health and %d coins!\nYou entered %d/%d rooms.",
				player.getHealth(),
				player.coins,
				player.roomsVisited,
				Four.totalRooms
			)	
		);
	}

}

class Player {
	public int roomsVisited; 
	private int health;
	public int coins;

	public Player(int health, int coins) {
		this.health = health;
		this.coins = coins;
	}

	public void addHealth(int health) {
		this.health += health;
	}
	
	public int getHealth() {
		return health;
	}

}


abstract class Room {
	public final String name;
	public final int coins;
	public float trapChance;
	public boolean hasEntered;
	
	public Room(String name, int maxCoins, float trapChance) {
		this.name = name;
		this.coins = (int) (Math.random() * maxCoins);
		this.trapChance = trapChance;
	}

	@Override
	public String toString() {
		return name;	
	}

	public abstract int onTrap(Player player);
}

class Exitroom extends Room {


	public Exitroom() {
		super("Exit", 25, 0.75f);
	}

	@Override
	public int onTrap(Player player) {
		return 0;
	}
}

class Livingroom extends Room {


	public Livingroom() {
		super("Livingroom", 25, 0.75f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 10);
		String message = "You tripped on the carpet and fell face first!";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance-=.20;
		return damage;
	}
}

class UpperLivingroom extends Room {


	public UpperLivingroom() {
		super("Uppstairs livingroom", 10, 0.30f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 80);
		String message = "You got a random heart attack.";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= .50f;
		return damage;
	}
}

class Stairway extends Room {


	public Stairway() {
		super("Stairway", 10, 0.10f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 10);
		String message = "You tripped.";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= .10f;
		return damage;
	}
}

class UpperStairway extends Room {

	public UpperStairway() {
		super("Upper Stairway", 10, 0.10f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 10);
		String message = "You tripped on the last step.";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= .10f;
		return damage;
	}
}

class Basement extends Room {
	public Basement() {
		super("Basement", 75, 0.80f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(5, 30);
		String message = "You got bit by a big rat!";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance-=.10;
		return damage;
	}
}


class Bedroom extends Room {
	public Bedroom() {
		super("Bedroom", 40, 0.50f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 5);
		String message = "You hit your toe on the bed frame.";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= 0.20;
		return damage;
	}
}

class MasterBedroom extends Room {
	public MasterBedroom() {
		super("MasterBedroom", 40, 0.50f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 5);
		String message = "A painting fell of the wall and hit you in the face!";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= 0.10f;
		return damage;
	}
}

class Utilityroom extends Room {
	public Utilityroom() {
		super("Utilityroom", 90, 0.40f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(10, 20);
		String message = "You slipped on banana peel.";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= 0.20;
		return damage;
	}
}

class Hallway extends Room {
	public Hallway() {
		super("Hallway", 35, 0.30f);
	}
	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 15);
		String message = "Ouch! The door closed on you.";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= 0.10;
		return damage;
	}
}

class Kitchen extends Room {
	public Kitchen() {
		super("Kitchen", 35, 0.60f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 15);
		String message = "You cut of your thump while curring onions!";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= 0.10;
		return damage;
	}
}

class Bathroom extends Room {
	public Bathroom() {
		super("Bathroom", 50, 0.60f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 5);
		String message = "You lost the battle and pooped yourself.";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= 0.20;
		return damage;
	}
}


class HallwayBathroom extends Room {
	public HallwayBathroom() {
		super("Hallway bathroom", 20, 0.30f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 60);
		String message = "You slipped on the floor and hit your head.";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= 0.20;
		return damage;
	}
}

class Attic extends Room {
	public Attic() {
		super("Attic", 28, 0.90f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 50);
		String message = "You got bit by a huge rat!"; 
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= 0.30;
		return damage;
	}
}

class Diningroom extends Room {
	public Diningroom() {
		super("Diningroom", 40, 0.50f);
	}

	@Override
	public int onTrap(Player player) {
		int damage = Util.range(2, 20);
		String message = "You bit your toungh while eating spagetti";
		System.out.println(String.format("%s you lost %d health.", message, damage));
		trapChance -= 0.20;
		return damage;
	}
}



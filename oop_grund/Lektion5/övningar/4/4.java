import java.util.Arrays;
import java.util.List;
import java.util.ArrayList;
import java.util.HashMap;

class Three {
	public static void main(String[] args) {
		
	}

	public Three() {
		Player player = new Player();

		Room hallway = new Hallway();

		Room livingroom = new Livingroom();
		Room upperLivingroom= new UpperLivingroom();

		Room bathroom= new Bathroom();
		Room hallwayBathroom = new HallwayBathroom();

		Room bedroom = new Bedroom();
		Room masterBedroom = new MasterBedroom();

		Room basement = new Basement();
		Room attic = new Attic();
		Room utilityroom = new Utilityroom();
		Room diningroom = new Diningroom();
		Room kitchen = new Kitchen();

		Room stairway = new Stairway();
		Room upperStairway = new UpperStairway();


		List<Room> hallwayRooms = new ArrayList<Room>(Arrays.asList(new Room[]{livingroom, hallwayBathroom}));
		List<Room> hallwayBathroomRooms = new ArrayList<Room>(Arrays.asList(new Room[]{hallway}));

		List<Room> livingroomRooms= new ArrayList<Room>(Arrays.asList(new Room[]{hallway, kitchen,  stairway}));

		List<Room> stairWayRooms = new ArrayList<Room>(Arrays.asList(new Room[]{livingroom, upperStairway}));
		List<Room> upperStairwayRooms= new ArrayList<Room>(Arrays.asList(new Room[]{upperLivingroom, stairway}));

		List<Room> upperLivingroomRooms = new ArrayList<Room>(Arrays.asList(new Room[]{upperStairway, attic, bedroom, masterBedroom}));

		HashMap<Room, List<Room>> roomDest = new HashMap<Room, List<Room>>();


	

		


	}

}

class Util {
	
	public static int range(int min, int max) {
		return (int) (Math.random() * ((max-min) + 1)) + min;
	}

}

class Player {
	private int health;
	public int coins;


	public void setHealth(int health) {
		this.health -= health;
	}
	
	public int getHealth() {
		return health;
	}

}


abstract class Room {
	final String name;
	final int coins;
	public float trapChance;
	private boolean hasEntered;
	
	public Room(String name, int maxCoins, float trapChance) {
		this.name = name;
		this.coins = (int) (Math.random() * maxCoins);
		this.trapChance = trapChance;
	}

	public void onEnter(Player player) {

	}

	public abstract int onTrap(Player player);
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



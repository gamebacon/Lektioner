import java.util.Scanner;

class One {

	public enum Drink {
		SPRITE("Sprite", 1.75f),
		FANTA("Fanta", 1.25f),
		MOUNTAN_DEW("Mountan dew", 1.50f),
		COCA_COLA("Coca cola", 2.00f);

		public final String name;
		public final float price;

		private Drink(String name, float price) {
			this.name = name;
			this.price = price;
		}
	}

	public static void main(String[] args) {
		new One();
	}


	public One() {
	
		boolean hasBought = false;
		Scanner scanner = new Scanner(System.in);
		float balance = 10;

		while(true) {

			System.out.println("Current balance: $" + balance);
			System.out.println("What would you like to drink?");

			for(Drink drink : Drink.values()) {
				System.out.println(String.format("%s - $%.2f", drink.name, drink.price));
			}

			Drink drink = null; 

			try {
				System.out.print("Drink: ");
				String in = scanner.nextLine();

				if(in.equals("exit")) {
					if(hasBought) {
						System.out.println("Come back soon!");
						break;
					} else {
						System.out.println("You need to buy something first!");
						continue;
					}
				}

				drink = Drink.valueOf(in.toUpperCase().replace(" ", "_"));
			} catch(Exception ex) {
				System.out.println("Invalid drink!");
				continue;
			}

			if(drink.price > balance) {
				System.out.println(String.format("You can't afford a %s!", drink.name));
			} else {
				balance -= drink.price;
				System.out.println(String.format("You bought a %s!", drink.name));
				hasBought = true;
			}
		}

	}

}

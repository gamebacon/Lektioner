import java.util.List;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.Collections;

class Five {
	public static void main(String[] args) {
		new Five();
	}

	public Five() {
		Scanner scanner = new Scanner(System.in);
		String[] names = {"Peter", "Ann", "Guntas", "William", "Charles"};

		List<Person> persons = new ArrayList<Person>();

		for(int i = 0; i < names.length; i++) {
			String name = names[i];

			if(i == 0)
				persons.add(new Spy(name));
			else
				persons.add(new Person(name));
		}

		Collections.shuffle(persons);

		while(true) {

		Person guessedPerson = null;
		System.out.println("Guess who the spy is!");

		for(Person person : persons) {
			System.out.print(" *" + person.name);
		}

		System.out.print("\nGuess: ");
		String in = scanner.nextLine();	

		for(Person person : persons) {
			if(person.name.equalsIgnoreCase(in)) {
				guessedPerson = person;
			}
		}

		if(guessedPerson == null) {
			System.out.println("Theres no person with the name \"" + in + "\".");
			continue;
		} else if(guessedPerson instanceof Spy) {
			System.out.println(String.format("Correct! %s was the spy!", guessedPerson.name));
			return;
		} else {
			System.out.println(String.format("Wrong! %s was not the spy!", guessedPerson.name));
			persons.remove(guessedPerson);

			if(persons.size() > 2) {
				removeRandom(persons);
			} else {
				System.out.println("Gameover!");
				return;
			}
		}
		}
	}
	
	public void removeRandom(List<Person> persons) {
		int index = 0;
		while(true) {
			index = (int) (Math.random() * persons.size());
			Person person = persons.get(index);
			if(!(person instanceof Spy)) {
				persons.remove(person);
				return;
			}
		}	
	}
		
}


class Person {
	public String name;

	public Person() {

	}

	public Person(String name) {
		this.name = name;
	}

}
class Spy extends Person {
	public Spy() {

	}

	public Spy(String name) {
		super(name);
	}
}


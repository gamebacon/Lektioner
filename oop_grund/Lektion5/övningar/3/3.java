import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

class Three {
	public static void main(String[] args) {
		new Three();
	}


	public Three() {
		List<Animal> animals = new ArrayList<Animal>();
		animals.add(new Cow());
		animals.add(new Minotaur());
		animals.add(new Sheep());
		animals.add(new Sheep());
		animals.add(new Sheep());

		System.out.println(animals.toString());
		animals = transport(animals);
		System.out.println(animals.toString());
	}

	private List<Animal> transport(List<Animal> animals) {
		int minotaur = 0;
		Iterator<Animal> iterator = animals.iterator();

		while(iterator.hasNext()) {
			Animal animal = iterator.next();

			animal.MakeSound();

			if(animal instanceof Minotaur) 
				minotaur++;
			else if(animal instanceof Sheep && minotaur > 0) {
				minotaur--;
				iterator.remove();
				//System.out.println("Sheep got eaten!");
			}
		}

		return animals;
	}


}

abstract class Animal {

	public Animal(){

	}

	public abstract void MakeSound();
}

class Cow extends Animal {

	public Cow() {

	}

	@Override
	public void MakeSound() {
		System.out.println("Muuuu");
	}
}

class Sheep extends Animal {

	public Sheep() {

	}

	@Override
	public void MakeSound() {
		System.out.println("Bääää");
	}
}

class Minotaur extends Animal {

	public Minotaur() {

	}

	@Override
	public void MakeSound() {
		System.out.println("Rooooooouh!");
	}
}



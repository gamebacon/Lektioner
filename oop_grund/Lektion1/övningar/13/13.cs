using System;

public class Övning13 {
	public static void Main(string[] args) {
		new Övning13();
	}


	public Övning13() {
		MobilePhone phone = new MobilePhone();
		phone.Call("49232349234");
	}

}


public class Phone {

	public virtual void Call(string number) {
		Console.WriteLine("New phone who diz?");
	}

}

public class MobilePhone : Phone {
	Contact[] contacts = new Contact[3];

	public MobilePhone() {
		contacts[0] = new Contact("Erik", 0704950303);
		contacts[1] = new Contact("Hans", 0503030459);
		contacts[2] = new Contact("Bertil", 0492039339);
	}


	public override void Call(string number) {
		Contact c = null;
		for(int i = 0; i < contacts.Length; i++) {
			if(contacts[i].number.ToString() == number) {
				c = contacts[i];
			}
		}

		if(c == null) {
			Console.WriteLine("Could not find any contact with the number: " + number);
		} else {
			Console.WriteLine("Now calling " + c.name + "...");
		}
	}

}

public class Contact {
	public long number;
	public string name;

	public Contact(string name, long number) {
		this.name = name;
		this.number = number;
	}

}

using System;
public class Övning12 {
	public static void Main(string[] args) {
		new Övning12();
	}

	public Övning12() {
		Phone iphone = new Phone();
		iphone.Call("0702950823");
	}
}

public class Phone {
	public void Call(string num) {
		Console.WriteLine("new phone who dis?");
	}
}

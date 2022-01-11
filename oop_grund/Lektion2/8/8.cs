using System;

public class Övning8 {
	public static void Main(string[] args) {
		new Övning8();
	}	

	
	
	public Övning8() {
		char[] vocals = {'a', 'e', 'i', 'o', 'u'};
		int vocalCount = 0;

		string word = Console.ReadLine();
		

		foreach(char c in word.ToCharArray())
			foreach(char vocal in vocals)
				if(c == vocal)
					vocalCount++;

		Console.WriteLine(vocalCount);
	}
}

using System;

public class �vning8 {
	public static void Main(string[] args) {
		new �vning8();
	}	

	
	
	public �vning8() {
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

using System;

public class �vning6 {

	public static void Main(string[] args) {
		new �vning6();
	}
		


	public �vning6() {

		string[] str = Console.ReadLine().ToLower().Split(' ');
		string pascal = "";

		foreach(string word in str) {
			char[] arr = word.ToCharArray();
			for(int i = 0; i < arr.Length; i++) {
				pascal += i == 0 ? Char.ToUpper(arr[i]) : arr[i]; 
			}
		}
		
		Console.WriteLine(pascal);


	}


}

using System;

public class Övning6 {

	public static void Main(string[] args) {
		new Övning6();
	}
		


	public Övning6() {

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

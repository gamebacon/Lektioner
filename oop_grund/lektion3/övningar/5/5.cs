using System;
using System.Collections.Generic;

public class Övning5 {
	public static void Main(string[] args) {
		Dictionary<string, string> replaceWords = new Dictionary<string, string>();
		replaceWords.Add("mamma", "pappa");
		replaceWords.Add("ful", "fin");
		replaceWords.Add("fuck", "f**k");

		List<string> newWords = new List<string>();

		foreach(string word in args) {
			if(replaceWords.ContainsKey(word)) {
				newWords.Add(replaceWords[word]);			
			} else 
				newWords.Add(word);
		}

		foreach(string word in newWords) 
			Console.Write(word + " ");
		


	}


}

using System;

public class Övning6 {
	public static void Main(string[] args) {
		
	}
}


public class Library {
	public List<Book> books = new List<Book>();
	

} 


public class Book {

	private List<string> comments = new List<string>();

	public Book() {

	}

	public void AddComment(string comment) {
		comments.Add(comment);
	}

	public void ReadComments() {
		foreach(string comment in comments) 
			Console.WriteLine(comment);
	}

	
} 


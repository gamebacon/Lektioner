using System;
using System.IO;
	
public class Five {
	public static void Main(string[] args) {

		string[] actions = {"Exit", "Create", "Change dir", "Remove", "List"};

		while(true) {
			DirectoryInfo dInfo = new DirectoryInfo(".");
			string path = dInfo.FullName;

			Console.WriteLine("Current path: \"{0}\"", path);
			Console.WriteLine("What would you like to do?");	

			int choise = -1;
			for(int i = 0; i < actions.Length; i++) {
				Console.Write("{0}({1}) ", i+1, actions[i]);
			}
			
			try {
				choise = Int32.Parse(Console.ReadLine());
			} catch(Exception) {}
				
			if(choise== 1) 
			{
				break;
			}
			 else if(choise == 2)
		 	{
				int createChoise = -1;
				while(true) {
						Console.WriteLine("1(Folder) 2(File)");
						try {
								createChoise = Int32.Parse(Console.ReadLine());
								if(createChoise == 1 || createChoise == 2)
								{
									break;
								}
						} catch(Exception) {}
				}
				
				while(true) 
				{
					Console.Write("name: ");
					string name = Console.ReadLine();
					string newPath = path + @"\" + name;
					if(Directory.Exists(newPath)) {
						Console.WriteLine("A file with the name \"{0}\" already exists! pick a different one.", name);
						continue;
					} else {
						if(createChoise == 1) 
						{
							Directory.CreateDirectory(newPath);
						}
						else
						{
							File.Create(newPath);	
						}
						Console.WriteLine("\"{0}\" was created!", name);
						break;
					}
				}
				
				
			}
			else if(choise == 3)
			{
				Console.WriteLine("Where would you like to go?");
				
				ListDir(path, true);
				
				while(true) {
					string dirChoise = Console.ReadLine();
					//check if dirchosei exists... 
								zZzZZZZ
				}
			}
			else if(choise == 4)
			{

			} 
			else 
			{
				continue;
			}
		

			
		}

	}

	public static void ListDir(string path, bool dir) {
		
		string[] files;
		if(dir) {
			DirectoryInfo di = new DirectoryInfo(path);
			DirectoryInfo[] diArr = di.GetDirectories();

				Console.WriteLine("..");
			foreach(DirectoryInfo dri in diArr) {
				Console.WriteLine(dri.Name);
			}
		}
		else {
			files = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
				foreach(string file in files) {
					Console.WriteLine(file);
				} 
		}


	}

	
}

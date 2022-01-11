import java.io.FileWriter;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.BufferedReader;
import java.io.File;
import java.util.Scanner;

class Two {

	public static void main(String[] args) {
		new Two();
	}

		
	public Two() {
		Scanner scanner = new Scanner(System.in);
		
		System.out.print("Enter name: ");
		String name = scanner.nextLine();

		System.out.print("Enter age: ");
		int age = Integer.parseInt(scanner.nextLine());

		System.out.println(age);


		try {
				File file = new File(System.getProperty("user.dir") + "\\test.txt");
				file.createNewFile();
				
				BufferedWriter writer = new BufferedWriter(new FileWriter(file));
				
				writer.write(name + "\n" + age);
				
				System.out.println("writing...");
				writer.close();

				BufferedReader reader = new BufferedReader(new FileReader(file));
				
				String line = "";

				while((line = reader.readLine()) != null)  {
					System.out.println(line);
				}

				reader.close();

		} catch (Exception e) {
			System.out.println("error!!!");
			e.printStackTrace();
		}
	}


}

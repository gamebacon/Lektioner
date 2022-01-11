import java.util.Scanner;

class Six {
	public static void main(String[] args) {
		new Six();
	}

	public Six() {
		Scanner scanner = new Scanner(System.in);
		int num = 0;
		while(true) {
		System.out.print("Enter num: ");

		try {
			num = Integer.parseInt(scanner.nextLine());
		} catch(Exception e) {
			System.out.println("Invalid input!");
			continue;
		}
		
		long fac = factorial(num);
		System.out.println(String.format("The factorial for %d is %d", num, fac));
		break;
		}
	}
	
	public int factorial(int num) {
		return num == 1 ? num : num * factorial(num - 1);
	}


}

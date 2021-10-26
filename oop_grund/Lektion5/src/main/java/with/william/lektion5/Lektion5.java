package with.william.lektion5;

import java.util.Random;
import java.util.Scanner;

public class Lektion5 extends Object {
    public static void main(String[] args) {
        System.out.println("Hello world");

        System.out.println((int) (Math.random() * 10));

        Scanner scanner = new Scanner(System.in);

        String in = scanner.nextLine();


        System.out.println("You typed: " + in);
        String one = "HEJ";
        String two = "HEJ";

        System.out.println(one == two);


        System.out.println(one.equals(two));
    }
}

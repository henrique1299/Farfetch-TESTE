import java.util.Scanner;

public class Main {
    
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.println("String 1:");
        String str1 = scan.next();
        System.out.println("String 2:");
        String str2 = scan.next();
        scan.close();

        Anagram anagram = new Anagram ();

        System.out.println("Is Anagram: " + anagram.isAnagram(str1, str2));

    }
}

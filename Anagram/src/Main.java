package src;

import java.util.Scanner;

public class Main {
    
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.println("String 1:");
        String str1 = scan.nextLine();
        
        System.out.println("String 2:");
        String str2 = scan.nextLine();

        Anagram anagram = new Anagram ();
        
        System.out.println("Is Anagram: " + anagram.isAnagram(str1, str2));
        scan.close();

    }
}

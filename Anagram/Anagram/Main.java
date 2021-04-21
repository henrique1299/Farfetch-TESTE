public class Main {
    
    public static void main(String[] args) {
        //System.out.println("Eu sou o seu primeiro programa.");
        Anagram a = new Anagram("''","''");
        Anagram b = new Anagram("Aaz","Azz");
        Anagram c = new Anagram("cinema","iceman");
        Anagram d = new Anagram("awesome","awesom");
        Anagram e = new Anagram("qwerty","qeywrt");
        System.out.println("a:" + a.isAnagram());
        System.out.println("b:" + b.isAnagram());
        System.out.println("c:" + c.isAnagram());
        System.out.println("d:" + d.isAnagram());
        System.out.println("e:" + e.isAnagram());
    }
}

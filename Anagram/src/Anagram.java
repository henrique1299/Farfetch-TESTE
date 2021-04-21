package src;

public class Anagram
{
    
    public Anagram()
    {

    }

    public boolean isAnagram(String s1, String s2)
    {
        char[] char1 = removeRepetido(s1);
        char[] char2 = removeRepetido(s2);

        if (char1.length == char2.length && s1.length() == s2.length())
        {
            boolean anagram = checkAnagram(char1, char2);
            
            if (anagram)
                return true;
            return false;
        }
        else
        {
            return false;
        }
    }
    public char[] removeRepetido(String s)
    {
        String aux;
        for (int i = 0; i < s.length(); i++)
        {
            for (int j = i+1; j < s.length(); j++)
            {
                if (s.charAt(i) == s.charAt(j))
                {
                    aux = s.substring(i, s.length());
                    aux = aux.replace(String.valueOf(s.charAt(i)), "");
                    s = s.substring(0, i+1);
                    s += aux;
                }
            }
        }
        return s.toCharArray();
    }
    public boolean checkAnagram(char[] char1, char[] char2)
    {
        int cont;
        for (int i = 0; i < char1.length; i++)
        {
            cont = 0;
            for (int j = 0; j < char2.length; j++)
            {
                if (char1[i] == char2[j])
                {
                    cont++;
                }
            }
            if (cont != 1)
            {
                return false;
            }
        }
        return true;
    }
}
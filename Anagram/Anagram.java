public class Anagram
{
    private String s1;
    private String s2;
    public Anagram(String s1, String s2)
    {
        this.s1 = s1;
        this.s2 = s2;
    }

    public boolean isAnagram()
    {
        char[] S1 = removeRepetido(s1);
        char[] S2 = removeRepetido(s2);

        if (S1.length == S2.length && s1.length() == s2.length())
        {
            boolean anagram = checkAnagram(S1, S2);
            
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
    public boolean checkAnagram(char[] S1, char[] S2)
    {
        int cont;
        for (int i = 0; i < S1.length; i++)
        {
            cont = 0;
            for (int j = 0; j < S2.length; j++)
            {
                if (S1[i] == S2[j])
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
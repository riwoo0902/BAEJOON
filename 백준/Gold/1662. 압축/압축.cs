using System.Text;
class Program
{
    static void Main()
    {
        Console.WriteLine(LengthPrint(Console.ReadLine()));
    }
    static int LengthPrint(string s)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(s);
        int Lengt = 0;
        while (true)
        {
            string st = sb.ToString();
            GetParenthesesData(st, out int startIndex, out int lastIndex);
            if (startIndex == -1 || lastIndex == -1) break;
            int addCount = st[startIndex - 1] - 48;
            int a = LengthPrint(new string(st.ToCharArray(), startIndex + 1, lastIndex - startIndex-1));
            sb.Remove(startIndex - 1, lastIndex - startIndex + 2);
            Lengt += a * addCount;
        }
        Lengt += sb.Length;
        return Lengt;
    }
    static void GetParenthesesData(string s,out int startIndex,out int lastIndex)
    {
        startIndex = s.IndexOf('(');
        int count = 1;
        for(int i = startIndex + 1;i < s.Length; i++)
        {
            if (s[i] == '(') count++;
            else if (s[i] == ')')
            {
                count--;
                if(count <= 0)
                {
                    lastIndex = i;
                    return;
                }
            }
        }
        lastIndex = -1;
    }
}
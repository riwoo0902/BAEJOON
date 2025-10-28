using System.Text;
class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        StringBuilder sb = new StringBuilder();
        while (true)
        {

            string a = sr.ReadLine();
            if(a == "0") break;
            sb.Append(IsPalindrom(a) ? "yes\n" : "no\n");
        }
        Console.WriteLine(sb.ToString());
    }
    static bool IsPalindrom(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if(input[i] != input[^(i+1)]) return false;
        }
        return true;
    }
}
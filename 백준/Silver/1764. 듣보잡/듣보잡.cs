using System.Text;

class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int count = 0;

        int[] a = Array.ConvertAll(sr.ReadLine().Split(" "),int.Parse);
        HashSet<string> b = new();
        for(int i = 0; i < a[0]; i++)
        {
            b.Add(sr.ReadLine());
        }
        string input;
        List<string> list = new();
        for (int i = 0; i < a[1]; i++)
        {
            input = sr.ReadLine();
            if (b.Contains(input))
            {
                count++;
                list.Add(input);
            }
        }
        list.Sort();
        StringBuilder sb = new StringBuilder();
        list.ForEach(text => sb.AppendLine(text));

        Console.WriteLine(count);
        Console.WriteLine(sb);
    }
}
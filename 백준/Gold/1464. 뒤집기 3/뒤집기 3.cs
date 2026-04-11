using System.Text;
public class Test
{
    public static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        sb.Append(input[0]);
        for(int i = 1; i < input.Length; i++)
        {
            if (sb[0] < input[i])
            {
                sb.Append(input[i]);
            }
            else
            {
                sb.Insert(0, input[i]);
                string test = sb.ToString();
                sb.Clear();
                sb.Append(test);
            }
        }
        Console.WriteLine(sb);
    }
}
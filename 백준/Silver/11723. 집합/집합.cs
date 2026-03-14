using System.Text;

class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        StringBuilder sb = new StringBuilder();
        string input = sr.ReadLine();
        int loopCount = int.Parse(input);

        int[] s = new int[21];

        for(int i = 0; i < loopCount; i++)
        {
            input = sr.ReadLine();

            if (input[0] == 'a' && input[1] == 'd')
            {
                int numder = int.Parse(input.Split(" ")[1]);
                s[numder] = numder;
            }
            else if (input[0] == 'r')
            {
                int numder = int.Parse(input.Split(" ")[1]);
                s[numder] = 0;
            }
            else if (input[0] == 'c')
            {
                int numder = int.Parse(input.Split(" ")[1]);
                sb.Append((s[numder] != 0 ? 1 : 0) + "\n");
            }
            else if (input[0] == 't')
            {
                int numder = int.Parse(input.Split(" ")[1]);
                s[numder] = s[numder] == 0 ? numder : 0;
            }
            else if (input[0] == 'a')
            {
                s = new int[] { 0,1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            }
            else
            {
                s = new int[21];
            }
        }
        Console.WriteLine(sb);
    }
}
using System.Text;

class Program
{
    static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder sb = new();

        int sum = 0;
        bool a = false;
        int next = 1;

        foreach (char i in input)
        {
            if (i == '+' || i == '-')
            {
                sum += int.Parse(sb.ToString()) * next;
                if (a || i == '-')
                {
                    a = true;
                    next = -1;
                }
                else
                {
                    next = 1;
                }
                sb.Clear();
            }
            else
            {
                sb.Append(i);
            }
        }
        sum += int.Parse(sb.ToString()) * next;
        Console.WriteLine(sum);
    }
}
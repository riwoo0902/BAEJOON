using System.Text;
class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        int a = int.Parse(sr.ReadLine());
        Stack<int> stack = new Stack<int>();
        StringBuilder sb = new StringBuilder();
        for(int i = 0;i < a; i++)
        {
            string[] b = sr.ReadLine().Split(" ");
            if (b[0] == "push")
            {
                stack.Push(int.Parse(b[1]));
            }
            else if(b[0] == "pop")
            {
                try
                {
                    sb.Append(stack.Pop() + "\n");
                }
                catch
                {
                    sb.Append(-1 + "\n");
                }
            }
            else if (b[0] == "size")
            {
                sb.Append(stack.Count + "\n");
            }
            else if (b[0] == "empty")
            {
                sb.Append((stack.Count <= 0 ? 1 : 0) + "\n");
            }
            else if (b[0] == "top")
            {
                try
                {
                    int c = stack.Pop();
                    sb.Append(c + "\n");
                    stack.Push(c);
                }
                catch
                {
                    sb.Append(-1 + "\n");
                }
            }
        }
        Console.WriteLine(sb.ToString());
    }
}
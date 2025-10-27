using System.Text;
class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int a = int.Parse(sr.ReadLine());
        Queue<int> q = new Queue<int>();
        StringBuilder sb = new StringBuilder();
        int lastValue = 0;
        for(int i = 0; i < a; i++)
        {
            string[] b = sr.ReadLine().Split(" ");
            if (b[0] == "push")
            {
                int pushValue = int.Parse(b[1]);
                q.Enqueue(pushValue);
                lastValue = pushValue;
            }
            else if(b[0] == "pop")
            {
                if(q.TryDequeue(out int c))
                {
                    sb.Append($"{c}\n");
                }   
                else
                {
                    sb.Append("-1\n");
                }
            }
            else if (b[0] == "size")
            {
                sb.Append($"{q.Count}\n");
            }
            else if (b[0] == "empty")
            {
                int c = q.Count == 0 ? 1 : 0;
                sb.Append($"{c}\n");
            }
            else if (b[0] == "front")
            {
                if (q.TryPeek(out int c))
                {
                    sb.Append($"{c}\n");
                }
                else
                {
                    sb.Append("-1\n");
                }

            }
            else if (b[0] == "back")
            {
                if(q.Count != 0)
                {
                    sb.Append($"{lastValue}\n");
                }
                else
                {
                    sb.Append($"-1\n");
                }    
            }
        }
        Console.WriteLine(sb.ToString());
    }
}
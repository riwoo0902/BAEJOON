using System.Text;

class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        StringBuilder sb = new StringBuilder();
        
        int a = int.Parse(sr.ReadLine());
        int b;
        PriorityQueue<int, int> priorityQueue = new();
        for(int i = 0; i < a; i++)
        {
            b = int.Parse(sr.ReadLine());
            if(b == 0)
            {
                int text = priorityQueue.Count != 0 ? priorityQueue.Dequeue() : 0;
                sb.AppendLine(text.ToString());
                continue;
            }
            priorityQueue.Enqueue(b, b);
        }

        Console.WriteLine(sb);
    }
}



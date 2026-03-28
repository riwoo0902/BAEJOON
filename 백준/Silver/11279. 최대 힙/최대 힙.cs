using System.Text;
class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int input = int.Parse(sr.ReadLine());
        PriorityQueue<int,int> priorityQueue = new();
        StringBuilder sb = new();
        for (int i = 0; i < input; i++)
        {
            int input2 = int.Parse(sr.ReadLine());
            if(input2 == 0)
            {
                if(priorityQueue.Count > 0) sb.AppendLine(priorityQueue.Dequeue().ToString());
                else sb.AppendLine("0");
            }
            else priorityQueue.Enqueue(input2,int.MinValue - input2);
        }
        Console.WriteLine(sb.ToString());   
    }
}
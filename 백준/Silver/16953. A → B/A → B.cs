class Program
{
    static void Main()
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        int start = input[0];
        int end = input[1];

        Queue<Point> queue = new();
        HashSet<long> hash = new();
        int cost = -1;
        queue.Enqueue(new Point(start, 0));
        hash.Add(start);

        while (queue.Count > 0)
        {
            Point current = queue.Dequeue();
            if (current.pos == end)
            {
                cost = current.cost + 1;
                break;
            }
            long a = current.pos * 2;
            if (!hash.Contains(a))
            {
                hash.Add(a);
                if(a <= end) queue.Enqueue(new Point(a, current.cost + 1));
            }
            long b = current.pos * 10 + 1;
            if (!hash.Contains(b))
            {
                hash.Add(b);
                if (b <= end) queue.Enqueue(new Point(b, current.cost + 1));
            }
        }
        Console.WriteLine(cost);
    }
}
public class Point
{
    public long pos;
    public int cost;
    public Point(long pos, int cost)
    {
        this.pos = pos;
        this.cost = cost;
    }
}
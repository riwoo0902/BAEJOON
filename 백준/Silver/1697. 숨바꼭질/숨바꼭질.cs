class Program
{
    static void Main()
    {
        int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

        int start = input[0];
        int target = input[1];

        Queue<Point> queue = new(20);
        bool[] hash = new bool[100001];

        queue.Enqueue(new Point(start,0));
        hash[start] = true;
        int cost = 0;
        while (queue.Count > 0)
        {
            Point current = queue.Dequeue();
            if (current.pos == target)
            {
                cost = current.cost;
                break;
            }

            if (Check(current.pos -1) && !hash[current.pos - 1])
            {
                queue.Enqueue(new Point(current.pos - 1, current.cost + 1));
                hash[current.pos - 1] = true;
            }
            if (Check(current.pos + 1) && !hash[current.pos + 1])
            {
                queue.Enqueue(new Point(current.pos + 1, current.cost + 1));
                hash[current.pos + 1] = true;
            }
            if (Check(current.pos * 2) && !hash[current.pos * 2])
            {
                queue.Enqueue(new Point(current.pos * 2, current.cost + 1));
                hash[current.pos * 2] = true;
            }
        }
        Console.WriteLine(cost);
    }
    public static bool Check(int a)
    {
        return !(a <= -1 || a >= 100001);
    }
}
public class Point
{
    public int pos;
    public int cost = 0;
    public Point(int pos,int cost)
    {
        this.pos = pos;
        this.cost = cost;
    }
}
using System.Numerics;

class Program
{
    public static readonly Vector2[] dirs = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int[] input = Array.ConvertAll(Console.ReadLine().Split(" "),int.Parse);
        Vector2 targetPos = new Vector2(input[1], input[0]);
        Dictionary<Vector2, Point> dic = new();
        for (int i = 1; i <= input[0]; i++)
        {
            string input2 = Console.ReadLine();
            for(int j = 1; j <= input[1]; j++)
            {
                dic.Add(new Vector2(j,i), new Point(input2[j-1] - '0'));
            }
        }

        HashSet<Vector2> hash = new();
        Queue<Vector2> queue = new();

        queue.Enqueue(new Vector2(1,1));
        hash.Add(new Vector2(1,1));
        int cost = 0;
        while (queue.Count > 0)
        {
            Vector2 currentPointPos = queue.Dequeue();
            if(currentPointPos == targetPos)
            {
                cost = dic[targetPos].cost;
                break;
            }
            foreach(Vector2 dir in dirs)
            {
                Vector2 dirPos = currentPointPos + dir;
                if(hash.Contains(dirPos)) continue;
                hash.Add(dirPos);
                if (dic.TryGetValue(dirPos, out Point point))
                {
                    if(point.value == 1)
                    {
                        point.cost = dic[currentPointPos].cost + 1;
                        queue.Enqueue(dirPos);
                    }
                }
            }
        }
        Console.WriteLine(cost);
    }
}
public class Point
{
    public int value = 0;
    public int cost = 1;
    public Point(int value)
    {
        this.value = value;
    }
}
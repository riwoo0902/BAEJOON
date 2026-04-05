using System.Numerics;
class Program
{
    public static readonly Vector2[] dirs = { new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1) };
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int loop = int.Parse(sr.ReadLine());

        for(int loopCount = 0; loopCount < loop; loopCount++)
        {
            int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);

            Dictionary<Vector2, Point> map = new();
            Vector2 startPos = new Vector2();

            Queue<Vector2> currentCanGrowFirw = new();
            Queue<Vector2> queue = new Queue<Vector2>();
            HashSet<Vector2> hash = new();

            for (int i = 0; i < input[1]; i++)
            {
                string input2 = sr.ReadLine();
                for (int j = 0; j < input[0]; j++)
                {
                    Point point = new Point(input2[j]);
                    map.Add(new Vector2(i, j), point);
                    if (input2[j] == '@')
                    {
                        startPos = new Vector2(i, j);
                        map[startPos].cost = 0;
                        queue.Enqueue(startPos);
                        hash.Add(new Vector2(i, j));
                    }
                    else if (input2[j] == '*')
                    {
                        currentCanGrowFirw.Enqueue(new Vector2(i, j));
                        hash.Add(new Vector2(i, j));
                        point.state = '*';
                    }
                }
            }

            int cost = -1;
            int lastCost = 1;
            bool isgrow = false;
            while (queue.Count > 0)
            {
                Vector2 current = queue.Dequeue();
                Point currentPoint = map[current];

                if (lastCost == currentPoint.cost && !isgrow)
                {
                    isgrow = true;
                    Queue<Vector2> cash = new();
                    while (currentCanGrowFirw.Count > 0)
                    {
                        Vector2 firePos = currentCanGrowFirw.Dequeue();

                        foreach (Vector2 dir in dirs)
                        {
                            Vector2 fireDirPos = firePos + dir;
                            if (map.TryGetValue(fireDirPos, out Point firePoint))
                            {
                                if (firePoint.state != '.') continue;
                                firePoint.state = '*';
                                cash.Enqueue(fireDirPos);
                                hash.Add(fireDirPos);
                            }
                        }
                    }
                    while (cash.Count > 0) currentCanGrowFirw.Enqueue(cash.Dequeue());
                }

                if (currentPoint.state == '*') continue;
                foreach (Vector2 dir in dirs)
                {
                    Vector2 dirPos = current + dir;
                    if (hash.Contains(dirPos)) continue;
                    if (map.TryGetValue(dirPos, out Point point))
                    {
                        hash.Add(dirPos);
                        if (point.state != '.') continue;
                        lastCost = currentPoint.cost + 1;
                        point.cost = lastCost;
                        queue.Enqueue(dirPos);
                        isgrow = false;
                    }
                    else
                    {
                        cost = currentPoint.cost + 1;
                        goto End;
                    }
                }
            }
        End:;

            Console.WriteLine(cost == -1 ? "IMPOSSIBLE" : cost);
        }
    }
}
public class Point
{
    public int cost = 0;
    public char state;

    public Point(char v)
    {
        state = v;
    }
}
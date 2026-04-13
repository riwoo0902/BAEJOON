using System.Numerics;

class Program
{
    private static readonly Vector3[] dirs = { new Vector3(1, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 1, 0), new Vector3(0, -1, 0) };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int[] input = Array.ConvertAll(sr.ReadLine().Split(" "),int.Parse);

        Dictionary<Vector3, Point> map = new();
        HashSet<Vector3> hash = new();

        for(int i = 0; i < input[0]; i++)
        {
            string input2 = sr.ReadLine();
            for (int j = 0; j < input[1]; j++)
            {
                map.Add(new Vector3(i, j, 0), new Point(input2[j] - '0'));
                map.Add(new Vector3(i, j, 1), new Point(input2[j] - '0'));
            }
        }


        Queue<Vector3> queue = new();

        Vector3 startPos = new Vector3(0,0,0);
        queue.Enqueue(startPos);

        map[startPos].cost = 0;

        Vector2 targetPos = new Vector2(input[0]-1, input[1]-1);
        int cost = -1;
        while(queue.Count > 0)
        {
            Vector3 currentPos = queue.Dequeue();
            Point currentPoint = map[currentPos];
            if(currentPos.X == targetPos.X && currentPos.Y == targetPos.Y)
            {
                cost = currentPoint.cost + 1;
                break;
            }
            foreach(Vector3 dir in dirs)
            {
                Vector3 dirPos = currentPos + dir;
                if (map.TryGetValue(dirPos, out Point point))
                {
                    if (point.cost != -1) continue;
                    
                    if(point.state == 0)
                    {
                        queue.Enqueue(dirPos);
                        point.cost = currentPoint.cost + 1;
                    }
                    else if (dirPos.Z == 0)
                    {
                        Vector3 nextPos = dirPos + Vector3.UnitZ;
                        queue.Enqueue(nextPos);
                        map[nextPos].cost = currentPoint.cost + 1;
                    }
                }
            }
        }
        Console.WriteLine(cost);
    }
}
public class Point
{
    public int state;
    public int cost = -1;

    public Point(int state)
    {
        this.state = state;
    }
}
using System.Numerics;
using System.Text;

class Program
{
    public static Vector3[] dirs = { 
        new Vector3(1, 0, 0), new Vector3(-1, 0, 0),
        new Vector3(0, 1, 0), new Vector3(0, -1 ,0),
        new Vector3(0, 0, 1), new Vector3(0, 0, -1)
    };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            int[] input = Array.ConvertAll(sr.ReadLine().Split(' '), int.Parse);
            if (input[0] == 0 && input[1] == 0 && input[2] == 0) break;
            int cost = BFS(sr,input[0], input[1], input[2]);
            sb.AppendLine(cost != -1 ? $"Escaped in {cost} minute(s)." : "Trapped!");
        }
        Console.WriteLine(sb.ToString());
    }
    public static int BFS(StreamReader sr, int l,int r,int c)
    {
        int cost = -1;

        Dictionary<Vector3, Point> map = new();

        Queue<Vector3> queue = new();
        HashSet<Vector3> hash = new();

        Vector3 startPos = Vector3.Zero;
        Vector3 targetPos = Vector3.Zero;

        for (int i = 0; i < l; i++)
        {
            for (int j = 0; j < r; j++)
            {
                string mapLineInput = sr.ReadLine();
                for (int k = 0; k < c; k++)
                {
                    Vector3 vec = new Vector3(i, j, k);
                    map.Add(vec, new Point(mapLineInput[k]));
                    if(mapLineInput[k] == 'S')
                    {
                        startPos = vec;
                        map[startPos].cost = 0;
                        queue.Enqueue(vec);
                        hash.Add(vec);
                    }
                    else if(mapLineInput[k] == 'E') targetPos = vec;
                }
            }
            sr.ReadLine();
        }

        while(queue.Count > 0)
        {
            Vector3 currentPos = queue.Dequeue();
            if(currentPos == targetPos)
            {
                cost = map[currentPos].cost;
                break;
            }
            foreach(Vector3 dir in dirs)
            {
                Vector3 dirPos = currentPos + dir;
                if (hash.Contains(dirPos)) continue;
                hash.Add(dirPos);
                if(map.TryGetValue(dirPos,out Point point))
                {
                    if (point.type == '#') continue;

                    point.cost = map[currentPos].cost + 1;
                    queue.Enqueue(dirPos);
                }
            }
        }

        return cost;
    }

}
public class Point
{
    public char type;
    public int cost = -1;
    public Point(char type)
    {
        this.type = type;
    }
}
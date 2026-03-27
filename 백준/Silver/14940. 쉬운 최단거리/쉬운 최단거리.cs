using System.Numerics;
using System.Text;
class Program
{
    public static Vector2[] dirs = { new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1) };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int[] input = Array.ConvertAll(sr.ReadLine().Split(" "),int.Parse);

        Dictionary<Vector2, Point> map = new();
        Queue<Vector2> stack = new();
        HashSet<Vector2> hash = new();
        for(int i = 0; i < input[0]; i++)
        {
            int[] input2 = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
            for (int j = 0; j < input[1]; j++)
            {
                Vector2 pos = new Vector2(i, j);
                map.Add(pos, new Point(input2[j]));
                if (input2[j] != 1)
                {
                    map[pos].moveCount = 0;
                    hash.Add(pos);
                    if (input2[j] == 2) stack.Enqueue(pos);
                }
            }
        }

        while (stack.Count > 0)
        {
            Vector2 currentPointPos = stack.Dequeue();
            Point currentPoint = map[currentPointPos];
            foreach (Vector2 dir in dirs)
            {
                Vector2 dirPos = currentPointPos + dir;
                if (hash.Contains(dirPos)) continue;
                if(map.TryGetValue(dirPos,out Point point))
                {
                    point.moveCount = currentPoint.moveCount + 1;
                    hash.Add(dirPos);
                    stack.Enqueue(dirPos);
                }
            }
        }
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < input[0]; i++)
        {
            for (int j = 0; j < input[1]; j++)
            {
                sb.Append($"{map[new Vector2(i, j)].moveCount} ");
            }
            sb.AppendLine();
        }
        Console.WriteLine(sb.ToString());
    }
}
public class Point
{
    public int value;
    public int moveCount = -1;
    public Point(int value)
    {
        this.value = value;
    }
}
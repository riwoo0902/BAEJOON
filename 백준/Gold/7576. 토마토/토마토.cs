using System.Numerics;
class Program
{
    public static Vector2[] dirs = { new Vector2(0,-1), new Vector2(1,0), new Vector2(0,1), new Vector2(-1,0) }; 
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int[] inputs = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
        Dictionary<Vector2, Point> map = new();
        
        int allTomatoCount = 0;
        Queue<Vector2> lastGrowToamto = new();
        HashSet<Vector2> hash = new();
        for(int i = 0;i < inputs[1]; i++)
        {
            int[] inputs2 = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
            for (int j = 0; j < inputs[0];j++)
            {
                Vector2 pos = new Vector2(i, j);
                map.Add(pos, new Point(inputs2[j]));
                if(inputs2[j] == 1)
                {
                    lastGrowToamto.Enqueue(pos);
                    hash.Add(pos);
                    allTomatoCount++;
                }
                else if(inputs2[j] == 0) allTomatoCount++;
            }
        }

        int growCount = 0;

        while(lastGrowToamto.Count > 0)
        {
            Vector2 tomatoPos = lastGrowToamto.Dequeue();
            Point point = map[tomatoPos];
            
            foreach (Vector2 dir in dirs)
            {
                Vector2 dirPos = tomatoPos + dir;
                if (hash.Contains(dirPos)) continue;
                if (map.TryGetValue(dirPos, out Point pointSide))
                {
                    if(pointSide.value == 0)
                    {
                        pointSide.value = 1;
                        pointSide.growCount = point.growCount + 1;
                        if(pointSide.growCount > growCount) growCount = pointSide.growCount;
                        hash.Add(dirPos);
                        lastGrowToamto.Enqueue(dirPos);
                    }
                }
            }
        }

        Console.WriteLine(allTomatoCount == hash.Count ? growCount : -1);
    }
}
public class Point
{
    public int value = 0;
    public int growCount = 0;
    public Point(int value)
    {
        this.value = value;
    }
}
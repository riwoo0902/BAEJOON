using System.Numerics;
class Program
{
    public static readonly Vector2[] dirs = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int[] input = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
        Dictionary<Vector2, int> map = new();
        List<Vector2> picturePoints = new();
        for(int i = 0; i < input[0]; i++)
        {
            int[] input2 = Array.ConvertAll(sr.ReadLine().Split(" "),int.Parse);
            for (int j = 0; j < input[1]; j++)
            {
                Vector2 vec = new Vector2(i,j);
                map.Add(vec, input2[j]);
                if(input2[j] == 1)
                {
                    picturePoints.Add(vec);
                }
            }
        }
        HashSet<Vector2> hash = new();
        int pictureCount = 0;
        int maxSize = 0;
        foreach(Vector2 point in picturePoints)
        {
            if (hash.Contains(point)) continue;
            pictureCount++;
            Queue<Vector2> queue = new();
            queue.Enqueue(point);
            hash.Add(point);
            int size = 0;
            while (queue.Count > 0)
            {
                Vector2 currentPos = queue.Dequeue();
                size++;
                foreach (Vector2 dir in dirs)
                {
                    Vector2 dirPos = currentPos + dir;
                    if(hash.Contains(dirPos)) continue;
                    if (map.TryGetValue(dirPos,out int vlaue) && vlaue == 1)
                    {
                        queue.Enqueue(dirPos);
                        hash.Add(dirPos);
                    }
                }
            }
            if(maxSize < size) maxSize = size;
        }
        Console.WriteLine(pictureCount);
        Console.WriteLine(maxSize);
    }
}
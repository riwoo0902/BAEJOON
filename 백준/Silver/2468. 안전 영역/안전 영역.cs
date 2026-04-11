using System.Numerics;
class Program
{
    public static readonly Vector2[] dirs = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int input = int.Parse(sr.ReadLine());
        Dictionary<Vector2, int> map = new();
        int maxHeight = 1;
        for(int i = 0; i < input; i++)
        {
            int[] input2 = Array.ConvertAll(sr.ReadLine().Split(" "),int.Parse);
            for (int j = 0; j < input; j++)
            {
                Vector2 vec = new Vector2(i,j);
                map.Add(vec, input2[j]);
                if(input2[j] > maxHeight)
                {
                    maxHeight = input2[j];
                }
            }
        }

        int maxCount = 0;
        for(int i = 0; i <= maxHeight; i++)
        {
            int count = BFS(map,i);
            if(maxCount < count) maxCount = count;
        }
        Console.WriteLine(maxCount);
    }
    public static int BFS(Dictionary<Vector2, int> map,int rainHeight)
    {
        int count = 0;
        HashSet<Vector2> hash = new();
        foreach(Vector2 vce in map.Keys)
        {
            if(hash.Contains(vce) || map[vce] <= rainHeight) continue;
            count++;
            Queue<Vector2> queue = new();
            queue.Enqueue(vce);
            hash.Add(vce);
            while(queue.Count > 0)
            {
                Vector2 currentPos = queue.Dequeue();
                foreach(Vector2 dir in dirs)
                {
                    Vector2 dirPos = currentPos + dir;
                    if (hash.Contains(dirPos)) continue;
                    hash.Add(dirPos);
                    if(map.TryGetValue(dirPos,out int height))
                    {
                        if(height > rainHeight) queue.Enqueue(dirPos);
                    }
                }
            }
        }

        return count;
    }
}
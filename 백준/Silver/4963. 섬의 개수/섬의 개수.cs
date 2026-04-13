using System.Numerics;
class Program
{
    public static readonly Vector2[] dirs = { 
        new Vector2(-1, 1),  new Vector2(0, 1),  new Vector2(1, 1),
        new Vector2(-1, 0),                      new Vector2(1, 0),
        new Vector2(-1, -1), new Vector2(0, -1), new Vector2(1, -1)
    };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        while(true)
        {
            int[] input = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);

            if (input[0] == 0 && input[1] == 0) break;

            Dictionary<Vector2,int> map = new();
            
            for(int i = 0;i < input[1]; i++)
            {
                int[] input2 = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
                for (int j = 0; j < input[0]; j++) map.Add(new Vector2(i, j), input2[j]);
            }

            Queue<Vector2> queue = new();
            HashSet<Vector2> hash = new();

            int count = 0;
            foreach (Vector2 point in map.Keys)
            {
                if (hash.Contains(point) || map[point] == 0) continue;
                
                count++;

                hash.Add(point);
                queue.Enqueue(point);

                while(queue.Count > 0)
                {
                    Vector2 currentPos = queue.Dequeue();

                    foreach(Vector2 dir in dirs)
                    {
                        Vector2 dirPos = currentPos + dir;
                        if(hash.Contains(dirPos)) continue;
                        hash.Add(dirPos);
                        if(map.TryGetValue(dirPos,out int value))
                        {
                            if(value == 0) continue;
                            queue.Enqueue(dirPos);
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
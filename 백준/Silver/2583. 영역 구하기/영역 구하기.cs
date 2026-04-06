using System.Numerics;

class Program
{
    public static Vector2[] dirs = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int[] input = Array.ConvertAll(sr.ReadLine().Split(" "),int.Parse);

        Vector2 mapSize = new Vector2(input[0], input[1]);
        HashSet<Vector2> hash = new();
        for(int i = 0; i < input[2]; i++)
        {
            int[] input2 = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
            for(int x = input2[0]; x < input2[2]; x++)
            {
                for (int y = input2[1]; y < input2[3]; y++)
                {
                    hash.Add(new Vector2(y, x));
                }
            }
        }

        PriorityQueue<int,int> priorityQueue = new();
        for(int x = 0;x < mapSize.X; x++)
        {
            for (int y = 0; y < mapSize.Y; y++)
            {
                Vector2 startPos = new Vector2(x, y);

                if (hash.Contains(startPos)) continue;
                int size = 1;
                Queue<Vector2> queue = new();
                queue.Enqueue(startPos);
                hash.Add(startPos);

                while (queue.Count > 0)
                {
                    Vector2 currentPos = queue.Dequeue();
                    foreach (Vector2 dir in dirs)
                    {
                        Vector2 dirPos = currentPos + dir;
                        if (hash.Contains(dirPos)) continue;
                        if (Check(mapSize, dirPos))
                        {
                            hash.Add(dirPos);
                            queue.Enqueue(dirPos);
                            size++;
                        }
                        
                    }
                }
                priorityQueue.Enqueue(size, size);
            }
        }

        Console.WriteLine(priorityQueue.Count);

        while(priorityQueue.Count > 0) Console.Write(priorityQueue.Dequeue() + " ");
    }
    public static bool Check(Vector2 mapSize,Vector2 checkPos)
    {
        return checkPos.X >= 0 && checkPos.Y >= 0 && checkPos.X < mapSize.X && checkPos.Y < mapSize.Y;
    }
}
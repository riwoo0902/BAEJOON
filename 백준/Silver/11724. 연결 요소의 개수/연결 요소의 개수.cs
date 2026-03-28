class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int[] input = Array.ConvertAll(sr.ReadLine().Split(" "),int.Parse);

        Dictionary<int, List<int>> map = new();
        for (int i = 1; i <= input[0]; i++) map.Add(i, new List<int>());

        for (int i = 0; i < input[1]; i++)
        {
            int[] input2 = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
            map[input2[0]].Add(input2[1]);
            map[input2[1]].Add(input2[0]);
        }

        HashSet<int> hash = new();
        Queue<int> queue = new Queue<int>();

        int count = 0;

        foreach (int key in map.Keys)
        {
            if (hash.Contains(key)) continue;
            queue.Enqueue(key);
            count++;
            while(queue.Count > 0)
            {
                int cureentPointId = queue.Dequeue();
                foreach(int i in map[cureentPointId])
                {
                    if (hash.Contains(i)) continue;
                    hash.Add(i);
                    queue.Enqueue(i);
                }
            }
        }

        Console.WriteLine(count);

    }
}
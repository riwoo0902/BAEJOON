using System;
using System.Numerics;
using System.Text;

class Program
{
    public static readonly Vector2[] dirs = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        
        int input = int.Parse(sr.ReadLine());
        Dictionary<Vector2, int> dic = new();

        for (int i = 0; i < input; i++)
        {
            for (int j = 0; j < input; j++)
            {
                dic.Add(new Vector2(j, i), 0);
            }
        }
        List<Vector2> allPos = new();
        HashSet<Vector2> hash = new();
        for (int i = 0; i < input; i++)
        {
            string input2 = sr.ReadLine();
            for(int j = 0; j < input2.Length; j++)
            {
                if (input2[j] - '0' == 1)
                {
                    Vector2 pos = new Vector2(j, i);
                    dic[pos] = 1;
                    allPos.Add(pos);
                }
            }
        }
        List<int> list = new();
        foreach (Vector2 pos in allPos)
        {
            if (hash.Contains(pos)) continue;
            int count = 0;
            Queue<Vector2> queue = new Queue<Vector2>();
            queue.Enqueue(pos);
            hash.Add(pos);
            while (queue.Count > 0)
            {
                Vector2 curentPos = queue.Dequeue();
                count++;
                foreach (Vector2 dir in dirs)
                {
                    Vector2 nextPos = curentPos + dir;
                    if (hash.Contains(nextPos)) continue;
                    if (dic.TryGetValue(nextPos, out int value))
                    {
                        if (value == 1)
                        {
                            hash.Add(nextPos);
                            queue.Enqueue(nextPos);
                        }
                    }
                }
            }
            list.Add(count);
        }
        list.Sort();
        Console.WriteLine(list.Count);
        StringBuilder sb = new();
        foreach (int value in list) sb.AppendLine(value.ToString());
        Console.Write(sb.ToString());
    }
}
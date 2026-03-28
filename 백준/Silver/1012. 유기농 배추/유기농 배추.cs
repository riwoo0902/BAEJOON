using System.Numerics;

class Program
{
    public static readonly Vector2[] dirs = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int loop = int.Parse(sr.ReadLine());

        for(int l = 0; l < loop; l++)
        {
            int[] input = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
            Dictionary<Vector2, int> dic = new();

            for(int i = 0; i < input[0];i++)
            {
                for(int j = 0;  j < input[1]; j++)
                {
                    dic.Add(new Vector2(j,i), 0);
                }
            }
            List<Vector2> allPos = new();
            HashSet<Vector2> hash = new();
            for(int i = 0; i < input[2]; i++)
            {
                int[] input2 = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
                Vector2 pos = new Vector2(input2[0], input2[1]);
                dic[pos] = 1;
                allPos.Add(pos);
            }
            int count = 0;
            foreach(Vector2 pos in allPos)
            {
                if(hash.Contains(pos)) continue;
                count++;
                Queue<Vector2> queue = new Queue<Vector2>();
                queue.Enqueue(pos);
                hash.Add(pos);
                while (queue.Count > 0)
                {
                    Vector2 curentPos = queue.Dequeue();
                    foreach(Vector2 dir in dirs)
                    {
                        Vector2 nextPos = curentPos + dir;
                        if(hash.Contains(nextPos)) continue;
                        if (dic.TryGetValue(nextPos,out int value))
                        {
                            if(value == 1)
                            {
                                hash.Add(nextPos);
                                queue.Enqueue(nextPos);
                            }
                        }
                        
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
class Program
{
    public static readonly (int,int)[] moveVec = 
    { 
        (-1,2), (1,2), (-1, -2), (1, -2),
        (-2, -1), (-2, 1),(2, -1), (2, 1)
    };
    static void Main(string[] args)
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        int loop = int.Parse(sr.ReadLine());

        for(int l = 0; l < loop; l++)
        {
            int size = int.Parse(sr.ReadLine());
            int[,] map = new int[size, size];

            Queue<(int, int)> queue = new Queue<(int, int)>();
            HashSet<(int, int)> hash = new();

            int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            (int, int) vec2 = (input[0], input[1]);
            
            queue.Enqueue(vec2);
            hash.Add(vec2);

            int[] input2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            (int,int) targetVec = (input2[0], input2[1]);

            int cost = 0;
            while (queue.Count > 0)
            {
                (int, int) pos = queue.Dequeue();
                int currentCost = map[pos.Item1,pos.Item2];
                if(pos == targetVec)
                {
                    cost = currentCost;
                    break;
                }
                foreach((int,int) i in moveVec)
                {
                    (int, int) c = Sum(i, pos);
                    if (hash.Contains(c)) continue;
                    if (CheckInMap(size, c) && map[c.Item1, c.Item2] == 0)
                    {
                        hash.Add(c);
                        queue.Enqueue(c);
                        map[c.Item1, c.Item2] = currentCost + 1;
                    }
                }
            }
            Console.WriteLine(cost);
        }
    }
    public static (int, int) Sum((int, int) a, (int, int) b) => (a.Item1 + b.Item1, a.Item2 + b.Item2);
    public static bool CheckInMap(int size, (int,int) pos)
    {
        return pos.Item1 >= 0 && pos.Item2 >= 0 && pos.Item1 <= size - 1 && pos.Item2 <= size - 1;
    }
}
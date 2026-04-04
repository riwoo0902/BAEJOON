using System.Numerics;
class Program
{
    public static Vector2[] dirs = {new Vector2(1,0), new Vector2(-1,0), new Vector2(0,1), new Vector2(0,-1) };
    public delegate bool CheckDelegate(char baseColor, char checkTargetColor);
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int size = int.Parse(sr.ReadLine());

        Dictionary<Vector2, char> map = new();
        for (int i = 0; i < size; i++)
        {
            string input = sr.ReadLine();
            for (int j = 0; j < size; j++)
            {
                map.Add(new Vector2(i, j), input[j]);
            }
        }
        Console.WriteLine($"{BFS(map, CheckColor)} {BFS(map, CheckColor2)}");
    }
    public static bool CheckColor(char baseColor,char checkTargetColor) => baseColor == checkTargetColor;
    public static bool CheckColor2(char baseColor, char checkTargetColor) => 
        baseColor == 'R' || baseColor == 'G' ?
        checkTargetColor == 'R' || checkTargetColor == 'G' : 
        baseColor == checkTargetColor;
    public static int BFS(Dictionary<Vector2, char> map, CheckDelegate checkDelegate)
    {
        int count = 0;
        HashSet<Vector2> hash = new();
        foreach (Vector2 pos in map.Keys)
        {
            if (hash.Contains(pos)) continue;
            count++;
            Queue<Vector2> queue = new();
            queue.Enqueue(pos);
            hash.Add(pos);
            char currentGroupChar = map[pos];
            while (queue.Count > 0)
            {
                Vector2 currentPos = queue.Dequeue();
                foreach(Vector2 dir in dirs)
                {
                    Vector2 dirPos = currentPos + dir;
                    if (hash.Contains(dirPos)) continue;
                    if(map.TryGetValue(dirPos, out char c) && checkDelegate(currentGroupChar, c))
                    {
                        hash.Add(dirPos);
                        queue.Enqueue(dirPos);
                    }
                }
            }
        }
        return count;
    }
}
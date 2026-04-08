using System.Numerics;

class Program
{
    public static Vector2[] dirs = { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1) };
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int[] input = Array.ConvertAll(sr.ReadLine().Split(' '),int.Parse);

        int max = input[0];
        int start = input[1];
        int target = input[2];
        int up = input[3];
        int down = input[4];

        Dictionary<int, int> map = new();
        //index,cost

        Queue<int> queue = new();
        queue.Enqueue(start);
        map.Add(start, 0);
        while (queue.Count > 0)
        {
            int current = queue.Dequeue();
            int currentCost = map[current];

            if(target == current)
            {
                Console.WriteLine(currentCost);
                return;
            }
            int currentUp = current + up;
            if(currentUp <= max && !map.ContainsKey(currentUp))
            {
                queue.Enqueue(currentUp);
                map.Add(currentUp, currentCost+1);
            }

            int currentDown = current - down;
            if (currentDown > 0 && !map.ContainsKey(currentDown))
            {
                queue.Enqueue(currentDown);
                map.Add(currentDown, currentCost + 1);
            }
        }
        Console.WriteLine("use the stairs");
    }

}
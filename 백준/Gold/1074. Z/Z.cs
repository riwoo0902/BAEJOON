using System.Numerics;

class Program
{
    static void Main()
    {

        int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        Console.WriteLine(Z(new Vector2(input[2], input[1]), new Vector2(0,0), (int)Math.Pow(2, input[0])));
    }
    public static readonly Vector2[] dirs = { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
    public static bool isClear = false;
    public static int Z(Vector2 targetPos,Vector2 startPos,int size)
    {
        if(isClear) return 0;
        if (targetPos.X > startPos.X + size || targetPos.Y > startPos.Y + size) return size * size;
        if (size == 2)
        {
            int count = 0;
            foreach (Vector2 dir in dirs)
            {
                if (targetPos == startPos + dir)
                {
                    isClear = true;
                    return count;
                }
                count++;
            }
            return 4;
        }
        int nextSize = size / 2;

        int sum = 0;
        foreach(Vector2 dir in dirs)
        {
            if (isClear) break;
            sum += Z(targetPos, startPos + dir * nextSize, nextSize);
        }
        return sum;
    }
}
using System.Text;

class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        StringBuilder sb = new StringBuilder();
        Pick(0, input[0], 0, input[1], sb, new int[input[1]]);
        Console.WriteLine(sb.ToString());
    }
    public static void Pick(int start,int max,int depth,int maxDepth,StringBuilder sb, int[] arr)
    {
        if(depth == maxDepth)
        {
            sb.AppendLine(string.Join(" ",arr));
            return;
        }
        for(int i = start + 1; i <= max; i++)
        {
            arr[depth] = i;
            Pick(i, max, depth + 1, maxDepth, sb,arr);
        }
    }
}
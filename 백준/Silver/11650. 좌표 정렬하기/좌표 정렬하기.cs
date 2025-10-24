using System.Text;
class Program
{
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int a = int.Parse(sr.ReadLine());
        Vector2[] list = new Vector2[a];
        for(int i = 0; i < a; i++)
        {
            int[] b = Array.ConvertAll(sr.ReadLine().Split(" "),int.Parse);
            list[i] = new Vector2(b[0],b[1]);
        }
        Array.Sort(list);
        StringBuilder sb = new StringBuilder();
        foreach(Vector2 v in list) sb.Append(v.Print());
        Console.WriteLine(sb.ToString());
    }
    public class Vector2 : IComparable<Vector2>
    {
        public int x;
        public int y;
        public Vector2(int inputx, int inputy)
        {
            x = inputx;
            y = inputy;
        }
        int IComparable<Vector2>.CompareTo(Vector2? other)
        {
            return x != other.x ? x - other.x : y - other.y;
        }
        public string Print()
        {
            return $"{x} {y}\n";
        }
    }
}
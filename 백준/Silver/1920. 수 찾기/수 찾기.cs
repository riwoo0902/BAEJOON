using System.Text;
class Program
{
    static void Main()
    {
        Console.ReadLine();
        int[] a = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        Dictionary<int,bool> b = new Dictionary<int,bool>();
        foreach (int i in a) b.TryAdd(i, true);
        Console.ReadLine();
        int[] d = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        StringBuilder stringBuilder = new StringBuilder();
        bool c;
        foreach (int i in d)stringBuilder.Append(b.TryGetValue(i, out c) ? "1\n": "0\n");
        Console.WriteLine(stringBuilder.ToString());
    }
}
using System.Text;
class Program
{
    static void Main(string[] args)
    {
        int a = int.Parse(Console.ReadLine());
        int[] b = Array.ConvertAll(Console.ReadLine().Split(" "),int.Parse);
        int c = int.Parse(Console.ReadLine());
        int[] d = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        Dictionary<int,int> dic = new Dictionary<int,int>();
        foreach (int i in b) AddValue(dic,i);
        StringBuilder sb = new StringBuilder();
        foreach (int i in d) sb.Append($"{GetValue(dic,i)} ");
        Console.WriteLine(sb.ToString());
    }
    static void AddValue(Dictionary<int,int> a,int b)
    {
        if(a.TryGetValue(b, out int c))
        {
            a[b]++;
        }
        else
        {
            a.TryAdd(b, 1);
        }
    }
    static int GetValue(Dictionary<int, int> a, int b) => a.TryGetValue(b, out int c) == true ? c : 0; 
}
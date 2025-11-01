int a = int.Parse(Console.ReadLine());
int[] b = Array.ConvertAll(Console  .ReadLine().Split(" "), int.Parse);
int c = int.Parse(Console.ReadLine());
Dictionary<int,int> d = new Dictionary<int,int>();
foreach (int j in b)
{
    if (d.TryAdd(j, 1)) continue;
    else d[j]++;
}
Console.WriteLine(d.TryGetValue(c, out int i) ? i : 0);
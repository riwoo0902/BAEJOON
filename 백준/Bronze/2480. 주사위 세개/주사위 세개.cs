class Program
{
    static void Main()
    {
        Console.WriteLine(Retrue(Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse)));
    }
    static int Retrue(int[] a)
    {
        if (a[0] == a[1] && a[1] == a[2]) return 10000 + a[0] * 1000;
        else if(a[0] == a[1] || a[0] == a[2]) return 1000 + a[0] * 100;
        else if (a[1] == a[2]) return 1000 + a[1] * 100;
        return a.Max() * 100;
    }
}
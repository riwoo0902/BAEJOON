class Program
{
    static void Main()
    {
        int[] a = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

        Console.WriteLine(Gcd(a[0], a[1]));
        Console.WriteLine(Lcm(a[0], a[1]));
    }
    public static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    public static int Lcm(int a, int b)
    {
        if (a == 0 || b == 0)
        {
            return 0;
        }
        return Math.Abs(a * b) / Gcd(a, b);
    }
}
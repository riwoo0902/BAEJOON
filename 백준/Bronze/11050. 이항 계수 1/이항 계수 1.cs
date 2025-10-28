class Program
{
    static void Main()
    {
        int[] a = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        float value1 = 1;
        for (int i = 1; i <= a[0]; i++) value1 *= i;
        int value2 = 1;
        for (int i = 1; i <= a[1]; i++) value2 *= i;
        int value3 = 1;
        for (int i = 1; i <= a[0] - a[1]; i++) value2 *= i;
        Console.WriteLine(value1 / (value2 * value3));
    }
}
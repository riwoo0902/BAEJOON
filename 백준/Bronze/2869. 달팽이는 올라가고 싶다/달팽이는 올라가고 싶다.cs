using System.Numerics;
class Program
{
    static void Main()
    {
        BigInteger[] a = Array.ConvertAll(Console.ReadLine().Split(" "), BigInteger.Parse);
        BigInteger b = 1;
        BigInteger c = (a[2] - a[0]);
        BigInteger d = (a[0] - a[1]);
        b += c % d == 0 ? c / d : c / d + 1; 
        Console.WriteLine(b);
    }
}
using System.Numerics;

class Program
{
    static void Main()
    {
        int length = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();

        BigInteger value = 0;
        for (int i = 0; i < length; i++)
        {
            value += ((input[i] - 96) * Pow(i));
        }
        value %= 1234567891;
        Console.WriteLine(value);
    }
    

    static BigInteger Pow(int powValue)
    {
        BigInteger bigInteger = 1;
        for (int i = 0; i < powValue; i++)
        {
            bigInteger *= 31;
        }
        return bigInteger;
    }
}
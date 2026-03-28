using System.Numerics;
class Program
{
    static void Main()
    {
        Dictionary<int, BigInteger> data = new();
        Console.WriteLine(F(data, int.Parse(Console.ReadLine())) % 10007);
    }
    public static BigInteger F(Dictionary<int, BigInteger> dic,int value)
    {
        if (dic.ContainsKey(value)) return dic[value]; 
        if (value <= 1) return 1;
        BigInteger a = F(dic, value - 1) + F(dic, value - 2);
        dic.Add(value, a);
        return a;
    }
}
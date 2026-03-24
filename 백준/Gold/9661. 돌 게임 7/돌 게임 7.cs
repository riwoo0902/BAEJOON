using System.Numerics;
BigInteger a = BigInteger.Parse(Console.ReadLine());
a %= 5;
Console.WriteLine(a == 0 || a == 2 ? "CY" : "SK");
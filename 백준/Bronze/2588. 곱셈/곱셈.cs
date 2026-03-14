int a = int.Parse(Console.ReadLine());
string b = Console.ReadLine();
Console.WriteLine(a * (b[2] - 48));
Console.WriteLine(a * (b[1] - 48));
Console.WriteLine(a * (b[0] - 48));
Console.WriteLine(a * int.Parse(b));
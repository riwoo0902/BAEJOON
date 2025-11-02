int[] a = Array.ConvertAll(Console  .ReadLine().Split(" "), int.Parse);
int b = int.Parse(Console.ReadLine());
int c = a[0] * 60 + a[1] + b;
if (c >= 1440) c -= 1440;
Console.WriteLine($"{c/60} {c%60}");
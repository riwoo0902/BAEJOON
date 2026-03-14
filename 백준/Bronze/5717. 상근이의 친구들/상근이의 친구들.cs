while (true)
{
    int[] a = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
    if (a[0] == 0 && a[1] == 0) break;
    Console.WriteLine(a[0] + a[1]);
}
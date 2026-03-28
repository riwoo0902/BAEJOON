int input = int.Parse(Console.ReadLine());
int[] list = new int[input + 1];
for (int i = 2; i <= input; i++)
{
    list[i] = list[i - 1] + 1;
    if (i % 2 == 0) list[i] = Math.Min(list[i], list[i / 2] + 1);
    if (i % 3 == 0) list[i] = Math.Min(list[i], list[i / 3] + 1);
}
Console.WriteLine(list[input]);
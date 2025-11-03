int a = int.Parse(Console.ReadLine());
int[] arr = new int[a];
for (int i = 0; i < a; i++) arr[i] = int.Parse(Console.ReadLine());
long sum = 0;
for (int i = 0; i < a; i++)
{
    int SeeCount = 0;
    for (int j = i + 1; j < a; j++)
    {
        if (arr[i] > arr[j]) SeeCount++;
        else break;
    }
    sum += SeeCount;
}
Console.Write(sum);
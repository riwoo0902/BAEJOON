int[] a = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
int[] b = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
int maxValue = 0;
for(int i = 0; i < a[0]; i++)
{
    for (int j = 0; j < a[0]; j++)
    {
        if (i == j) continue;
        for (int k = 0; k < a[0]; k++)
        {
            if(j == k || i == k) continue;
            int c = b[i] + b[j] + b[k];
            if (c > maxValue && c <= a[1]) maxValue = c;
        }
    }
}
Console.WriteLine(maxValue);
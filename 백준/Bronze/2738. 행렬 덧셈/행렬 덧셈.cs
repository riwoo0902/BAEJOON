int[] arrSize = Array.ConvertAll(Console.ReadLine().Split(" "),int.Parse);
int[,] arr = new int[arrSize[0], arrSize[1]];
for(int i = 0; i < arrSize[0]; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
    for (int j = 0; j < arrSize[1]; j++)
    {
        arr[i, j] = input[j];
    }
}
for (int i = 0; i < arrSize[0]; i++)
{
    int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
    for (int j = 0; j < arrSize[1]; j++)
    {
        Console.Write($"{arr[i, j] + input[j]} ");
    }
    Console.WriteLine();
}
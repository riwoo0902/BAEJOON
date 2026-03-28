int[] input = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
int x = Math.Min(input[2] - input[0], input[0]);
int y = Math.Min(input[3] - input[1], input[1]);
Console.WriteLine(Math.Min(x, y));
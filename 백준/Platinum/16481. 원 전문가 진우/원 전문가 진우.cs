double[] arr = Array.ConvertAll(Console.ReadLine().Split(" "), double.Parse);
Console.WriteLine(arr[0] * arr[1] * arr[2] / ((arr[0] * arr[1]) + (arr[0] * arr[2]) + (arr[1] * arr[2])));
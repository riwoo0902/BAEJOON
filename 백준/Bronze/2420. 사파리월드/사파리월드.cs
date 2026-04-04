long[] arr = Array.ConvertAll(Console.ReadLine().Split(" "),long.Parse);
Console.WriteLine(arr.Max()-arr.Min());
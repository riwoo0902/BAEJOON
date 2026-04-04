long[] arrSize = Array.ConvertAll(Console.ReadLine().Split(" "), long.Parse);
Console.WriteLine((arrSize[0] + arrSize[1])* (arrSize[0] - arrSize[1]));
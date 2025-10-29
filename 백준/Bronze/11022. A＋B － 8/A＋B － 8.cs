StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int a = int.Parse(sr.ReadLine());
for(int i  = 0; i < a; i++)
{
    int[] b = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
    sw.WriteLine($"Case #{i+1}: {b[0]} + {b[1]} = {b[0] + b[1]}");
}
sw.Flush();
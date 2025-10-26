StreamReader sr = new StreamReader(Console.OpenStandardInput());
StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
int n = int.Parse(sr.ReadLine());
int[] arr = new int[10001];
for (int i = 0; i < n; i++) arr[int.Parse(sr.ReadLine())]++;
for(int i = 0;i < arr.Length; i++)
{
    for(int j = 0;j < arr[i]; j++)
    {
        sw.WriteLine(i);
    }
}
sw.Flush();
class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        float[] a = Array.ConvertAll(sr.ReadLine().Split(" "), float.Parse);

        float value = a[0] / a[1];
        int b = int.Parse(sr.ReadLine());
        for(int i = 0; i < b; i++)
        {
            float[] c = Array.ConvertAll(sr.ReadLine().Split(" "), float.Parse);
            float d = c[0] / c[1];
            if (value > d) value = d;
        }
        Console.WriteLine(value * 1000);
    }
}
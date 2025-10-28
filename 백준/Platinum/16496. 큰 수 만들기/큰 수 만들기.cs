internal class Program
{
    static void Main()
    {
        var sr = new StreamReader(Console.OpenStandardInput());
        var sw = new StreamWriter(Console.OpenStandardOutput());
        int a = int.Parse(sr.ReadLine());
        string[] numbers = sr.ReadLine().Split();
        Array.Sort(numbers, (x, y) => {
            string xy = x + y;
            string yx = y + x;
            return string.Compare(yx, xy);
        });
        string result = string.Join("", numbers);
        if (result.All(c => c == '0'))
            result = "0";
        sw.WriteLine(result);
        sw.Flush();
    }
}
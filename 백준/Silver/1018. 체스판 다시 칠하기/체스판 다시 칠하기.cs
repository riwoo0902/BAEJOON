class Program
{
    static char GetValue(bool input) => input ? 'W' : 'B';
    static char ChangeValue(char input) => input == 'W' ? 'B' : 'W';
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int[] a = Array.ConvertAll(sr.ReadLine().Split(" "),int.Parse);
        string[] b = new string[a[0]];
        for (int i = 0; i < a[0]; i++) b[i] = sr.ReadLine();

        int minValue = int.MaxValue;
        for (int i = 0; i <= a[0]-8; i++)
        {
            for (int j = 0; j <= a[1] -8; j++)
            {
                int c = Check(b, i, j);
                if (c < minValue) minValue = c;
            }
        }
        Console.WriteLine(minValue);
    }
    static int Check(string[] b,int startx, int starty)
    {
        int first1Count = 0;
        int first2Count = 0;

        bool first1 = true;
        bool first2 = false;
        for (int i = startx; i < startx+8; i++)
        {
            char first1Value = GetValue(first1);
            char first2Value = GetValue(first2);
            first1 = !first1;
            first2 = !first2;
            for (int j = starty; j < starty+8; j++)
            {
                if (b[i][j] == first1Value) first1Count++;
                if (b[i][j] == first2Value) first2Count++;
                first1Value = ChangeValue(first1Value);
                first2Value = ChangeValue(first2Value);
            }
        }
        return first1Count < first2Count ? first1Count : first2Count;
    }
}
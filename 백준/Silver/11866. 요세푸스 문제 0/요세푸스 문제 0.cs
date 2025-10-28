using System.Text;
class Program
{
    static void Main()
    {
        int[] a = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        int[] b = new int[a[0]];
        int[] c = new int[a[0]];
        for (int i = 0; i < a[0]; i++) b[i] = i+1;
        int checkIndex = 0;
        int inputIndex = 0;
        while (true)
        {
            checkIndex += a[1]-1;
            while (checkIndex > b.Length-1)
            {
                checkIndex -= b.Length;
            }
            c[inputIndex] = b[checkIndex];
            inputIndex++;
            b[checkIndex] = -1;
            b = DelNullInt(b);
            if (b.Length <= 0) break;
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("<");
        bool first = true;
        foreach (int i in c)
        {
            if (first)
            {
                sb.Append($"{i}");
                first = false;
            }
            else sb.Append($", {i}");
        }
        sb.Append(">");
        Console.WriteLine(sb.ToString());
    }
    static int[] DelNullInt(int[] a)
    {
        int[] b = new int[a.Length-1];
        int inputIndex = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if(a[i] != -1)
            {
                b[inputIndex++] = a[i];
            }
        }
        return b;
    }
}
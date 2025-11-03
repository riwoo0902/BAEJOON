using System.Text;

class Program
{
    static void Main()
    {
        int[] a = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);
        int[] b = new int[a[0]];
        for (int i = 0; i < b.Length; i++)
        {
            b[i] = i + 1;
        }
        int index = -1;
        List<int> list = new List<int>();
        while (b.Length > 0)
        {
            index += a[1];
            while (index >= b.Length)
            {
                index -= b.Length;
            }
            list.Add(b[index]);
            b = RemoveArray(b, index--);
        }
        StringBuilder sb = new StringBuilder();
        sb.Append("<");
        bool asd = false;
        foreach (int i in list)
        {
            if (asd)
            {
                sb.Append($", {i}");
            }
            else
            {
                sb.Append($"{i}");
                asd = true;
            }
        }
        sb.Append(">");
        Console.WriteLine(sb.ToString());
    }
    static int[] RemoveArray(int[] a ,int removeIndex)
    {
        int[] c = new int[a.Length-1];
        int index = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (i != removeIndex)
            {
                c[index++] = a[i];
            }
        }
        return c;
    }

}
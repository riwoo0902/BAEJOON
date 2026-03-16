class Program
{
    static void Main()
    {
        int[] a = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

        int length = a[1];

        int[] b = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

        Array.Sort(b);

        foreach (int i in b)
        {
            if(length >= i)
            {
                length += 1;
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(length);  

    }
}
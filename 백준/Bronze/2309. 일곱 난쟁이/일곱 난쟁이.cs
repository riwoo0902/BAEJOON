class Program
{
    static void Main()
    {
        List<int> list = new List<int>();

        for(int i = 0; i < 9; i++) list.Add(int.Parse(Console.ReadLine()));

        int x = -1;
        int y = -1;
        
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (i == j) continue;
                int sum = 0;
                for (int k = 0; k < 9; k++)
                {
                    if(k == i || k == j) continue;
                    sum += list[k];
                }
                if(sum == 100)
                {
                    x = i;
                    y = j;
                    goto go;
                }
            }
        }
        go:;
        List<int> list2 = new List<int>();
        for (int k = 0; k < 9; k++)
        {
            if (k == x || k == y) continue;
            list2.Add(list[k]);
        }
        list2.Sort();
        list2.ForEach(Console.WriteLine);
    }
}
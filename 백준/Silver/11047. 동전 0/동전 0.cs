class Program
{
    static void Main()
    {
        int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        List<int> list = new(10);

        int price = input[1];
        for (int i = 0; i < input[0]; i++) list.Add(int.Parse(Console.ReadLine()));
        int sum = 0;
        int count = 0;
        while(true)
        {
            int coinMaxValue = list.Max();
            if (sum + coinMaxValue <= price)
            {
                count++;
                sum += coinMaxValue;
                if (sum == price) break;
            }
            else list.Remove(coinMaxValue);
        }
        Console.WriteLine(count);
    }
}
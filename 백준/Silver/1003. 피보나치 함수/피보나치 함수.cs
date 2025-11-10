class Program
{
    private static Dictionary<int, Values> fibonacciValue = new();
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        for(int i = 0; i < a; i++)
        {
            int b = int.Parse(Console.ReadLine());
            Values c = fibonacci(b);
            Console.WriteLine($"{c.addZoreCount} {c.value}");
        }
    }
    static Values fibonacci(int n)
    {
        if(fibonacciValue.TryGetValue(n,out Values value))
        {
            return value;
        }
        if (n == 0)
        {
            return new Values(1, 0); ;
        }
        else if (n == 1)
        {
            return new Values(0,1);
        }
        else
        {
            Values c = fibonacci(n - 1);
            Values d = fibonacci(n - 2);
            Values e = new Values(c.addZoreCount + d.addZoreCount, c.value + d.value);
            fibonacciValue.Add(n,e);
            return e;
        }
    }
    public class Values
    {
        public int addZoreCount = 0;
        public int value = 0;
        public Values(int a,int b )
        {
            addZoreCount = a;
            value = b;
        }
    }
}
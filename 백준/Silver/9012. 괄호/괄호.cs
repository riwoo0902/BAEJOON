internal class Program
{
    static void Main(string[] args)
    {
        int inputCount = int.Parse(Console.ReadLine());
        for(int i = 0; i < inputCount; i++)
        {
            string inputValue = Console.ReadLine();
            int count = 0;
            foreach(char a in inputValue)
            {
                if(a == '(')
                {
                    count++;
                }
                else if (a == ')')
                {
                    if (count == 0)
                    {
                        count = 1;
                        break;
                    }
                    count--;
                }
            }
            if(count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
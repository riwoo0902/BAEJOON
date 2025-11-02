int a = int.Parse(Console.ReadLine());
Stack<int> stack = new Stack<int>();
for(int i = 0; i < a; i++)
{
    int b = int.Parse(Console.ReadLine());
    if(b != 0) stack.Push(b);
    else stack.Pop(); 
}
Console.WriteLine(stack.Sum());
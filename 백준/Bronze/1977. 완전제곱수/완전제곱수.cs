int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
List<int> list = new();
int c = 1;
for(int i = 0; i <= b; c+= 2) list.Add(i += c);
int sum = 0;
int min = int.MaxValue;
for(int i = a; i <= b; i++)
{
    if (!list.Contains(i)) continue;
    sum += i;
    if(min > i) min = i;
}
Console.WriteLine(min != int.MaxValue ? $"{sum}\n{min}" : -1);
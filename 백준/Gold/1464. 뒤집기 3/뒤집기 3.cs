string input = Console.ReadLine();
string value = input[0].ToString();
for(int i = 1; i < input.Length; i++)
{
    if (value[0] < input[i])
    {
        value += input[i];
    }
    else
    {
        value = input[i] + value;
    }
}
Console.WriteLine(value);
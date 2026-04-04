string input = Console.ReadLine();
for(int i = 0; i < input.Length; i++)
{
    char c = '0';
    if(input[i] > 'Z') c = (char)(input[i] - 'a' + 'A');
    else c = (char)(input[i] - 'A' + 'a');
    Console.Write(c);
}
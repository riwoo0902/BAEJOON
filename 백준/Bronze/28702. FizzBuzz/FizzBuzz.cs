class Program
{
    static void Main()
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();
        string c = Console.ReadLine();

        if (int.TryParse(a, out int result1)) Console.WriteLine(Check(result1 + 3));
        else if (int.TryParse(b, out int result2)) Console.WriteLine(Check(result2 + 2));
        else if (int.TryParse(c, out int result3)) Console.WriteLine(Check(result3 + 1));
    }
    static string Check(int input)
    {
        string value = "";
        if (input % 3 == 0) value += "Fizz";
        if (input % 5 == 0) value += "Buzz";
        if (value == "") value = input.ToString();
        return value;
    }
}
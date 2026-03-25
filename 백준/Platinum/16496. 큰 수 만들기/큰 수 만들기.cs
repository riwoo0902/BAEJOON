var sr = new StreamReader(Console.OpenStandardInput());
int a = int.Parse(sr.ReadLine());
string[] numbers = sr.ReadLine().Split();
Array.Sort(numbers, (x, y) => string.Compare(y + x, x + y));
string result = string.Join("", numbers);
if (result.All(c => c == '0'))result = "0";
Console.WriteLine(result);
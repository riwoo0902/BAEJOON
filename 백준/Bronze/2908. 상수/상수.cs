string[] a = Console.ReadLine().Split(" ");
char[] b = a[0].ToArray();
Array.Reverse(b);
char[] c = a[1].ToArray();
Array.Reverse(c);
int d = int.Parse(new string(b));
int e = int.Parse(new string(c));
Console.WriteLine(d > e ? d : e);
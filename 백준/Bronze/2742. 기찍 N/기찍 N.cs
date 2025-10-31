using System.Text;
int a = int.Parse(Console.ReadLine());
StringBuilder sb = new StringBuilder();
for (int i = a; i > 0; i--) sb.Append($"{i}\n");
Console.WriteLine(sb.ToString());
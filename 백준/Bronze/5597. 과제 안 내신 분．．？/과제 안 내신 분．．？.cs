List<int> list = new List<int>(30);
for (int i = 1; i <= 30; i++) list.Add(i);
for (int i = 0;i < 28; i++) list.Remove(int.Parse(Console.ReadLine()));
list.Sort();
Console.WriteLine(list[0]);
Console.WriteLine(list[1]);
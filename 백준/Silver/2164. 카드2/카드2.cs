int a = int.Parse(Console.ReadLine());
Queue<int> q = new Queue<int>();
for (int i = 1; i <= a; i++) q.Enqueue(i);
int c = 0;
while (true)
{
    c = q.Dequeue();
    if(q.Count == 0) break;
    q.Enqueue(q.Dequeue());
}
Console.WriteLine(c);
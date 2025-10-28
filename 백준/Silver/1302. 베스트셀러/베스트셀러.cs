StreamReader sr = new StreamReader(Console.OpenStandardInput());
int a = int.Parse(sr.ReadLine());
Dictionary<string,int> books = new Dictionary<string,int>();

for(int i = 0; i < a; i++)
{
    string b = sr.ReadLine();
    if(books.TryGetValue(b,out int t)) books[b]++;
    else books.Add(b,1);
}
int maxValue = 0;
string maxBook = "";

foreach(string c in books.Keys)
{
    if(books[c] > maxValue)
    {
        maxValue = books[c];
        maxBook = c;
    }
    else if(books[c] == maxValue)
    {
        if(c.CompareTo(maxBook) < 0) maxBook = c;
    }
}
Console.WriteLine(maxBook);
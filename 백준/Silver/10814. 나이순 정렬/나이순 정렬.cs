using System.Text;
class Program
{
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int a = int.Parse(sr.ReadLine());
        Data[] datas = new Data[a];
        for (int i = 0; i < a; i++)
        {
            string[] s = sr.ReadLine().Split(" ");
            datas[i] = new Data(int.Parse(s[0]), s[1],i);
        }
        Array.Sort(datas);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < a; i++)
        {
            sb.Append(datas[i].Print());
        }
        Console.WriteLine(sb.ToString());

    }
}
public class Data :IComparable<Data>
{
    public Data(int a,string b,int c)
    {
        age = a;
        name = b;
        ID = c;
    }
    public int ID;
    public int age;
    public string name;
    public string Print()
    {
        return $"{age} {name}\n";
    }
    public int CompareTo(Data? obj)
    {
        if(age == obj.age)return ID - obj.ID;
        return age - obj.age;
    }
}
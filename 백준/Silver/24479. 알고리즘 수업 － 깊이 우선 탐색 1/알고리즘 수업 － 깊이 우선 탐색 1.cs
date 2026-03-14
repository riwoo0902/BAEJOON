using System.Text;

class Program
{
    static void Main()
    {
        #region start
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        #endregion
        #region setting
        int[] inputs = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);

        int pointAmount = inputs[0];
        int lineAmount = inputs[1];
        int StartPoint = inputs[2];

        Dictionary<int, Point> pointDic = new();

        for (int i = 1; i <= pointAmount; i++)
        {
            pointDic.Add(i, new Point(i));
        }

        for (int i = 0; i < lineAmount; i++)
        {
            inputs = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);

            pointDic[inputs[0]].canMovePoint.Enqueue(inputs[1],inputs[1]);
            pointDic[inputs[1]].canMovePoint.Enqueue(inputs[0], inputs[0]);
        }

        #endregion
        DFS(pointDic, StartPoint, new Counter(1));
        #region Write
        StringBuilder sb = new StringBuilder();
        foreach(Point point in pointDic.Values)
        {
            sb.Append($"{point.checkNumder}\n");
        }
        Console.WriteLine(sb.ToString());
        #endregion
    }
    public static void DFS(Dictionary<int, Point> pointDic,int startPoint, Counter count)
    {
        pointDic[startPoint].checkNumder = count.count++;
        while (pointDic[startPoint].TryGetNextPoint(out int nextPoint))
        {
            if (pointDic[nextPoint].checkNumder != 0) continue;
            DFS(pointDic, nextPoint, count);
        }
    }
}

public class Counter
{
    public Counter(int a) => count = a;
    public int count = 1;
}
public class Point
{
    public Point(int id) => this.id = id;
    
    public int id;
    public PriorityQueue<int,int> canMovePoint = new();
    public int checkNumder = 0;
    public bool TryGetNextPoint(out int nextPoin)
    {
        nextPoin = 0;
        if (canMovePoint.Count != 0)
        {
            nextPoin = canMovePoint.Dequeue();
            return true;
        }
        return false;
    }
}
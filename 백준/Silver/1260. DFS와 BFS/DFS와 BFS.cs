using System.Text;

class Program
{
    static void Main()
    {
        #region StartInput
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int[] inputs = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);

        int pointCount = inputs[0];
        int lineCount = inputs[1];
        int startPoint = inputs[2];
        #endregion
        #region DataSetting
        Dictionary<int, Point> pointDic = new();
        for (int i = 1; i <= pointCount; i++) pointDic.Add(i, new Point(i));

        for (int i = 0; i < lineCount; i++)
        {
            inputs = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);

            pointDic[inputs[0]].canMovePoint.Add(inputs[1]);
            pointDic[inputs[1]].canMovePoint.Add(inputs[0]);
        }
        foreach(Point i in pointDic.Values)
        {
            i.canMovePoint.Sort();
            i.canMovePoint.Reverse();
        }
        #endregion

        Console.WriteLine(DFS(pointCount, lineCount, startPoint, pointDic));
        Console.WriteLine(BFS(pointCount, lineCount, startPoint, pointDic));
    }
    public static StringBuilder DFS(int pointCount,int lineCount,int startPoint, Dictionary<int, Point> pointDic)
    {
        StringBuilder sb = new();

        HashSet<int> cantMoveHash = new();

        Stack<int> movePoint = new();
        movePoint.Push(startPoint);

        while (movePoint.Count > 0)
        {
            int currentPoint = movePoint.Pop();
            if (cantMoveHash.Contains(currentPoint)) continue;
            cantMoveHash.Add(currentPoint);
            sb.Append($"{currentPoint} ");
            foreach (int point in pointDic[currentPoint].canMovePoint)
            {
                if(cantMoveHash.Contains(point)) continue;
                movePoint.Push(point);
            }
        }
        return sb;
    }
    public static StringBuilder BFS(int pointCount, int lineCount, int startPoint, Dictionary<int, Point> pointDic)
    {
        StringBuilder sb = new();
        foreach (Point i in pointDic.Values) i.canMovePoint.Sort();

        HashSet<int> cantMovePoint = new();
        Queue<int> movePoint = new();

        movePoint.Enqueue(startPoint);
        cantMovePoint.Add(startPoint);

        while(movePoint.Count > 0)
        {
            int currentPoint = movePoint.Dequeue();
            sb.Append($"{currentPoint} ");
            foreach (int point in pointDic[currentPoint].canMovePoint)
            {
                if(cantMovePoint.Contains(point)) continue;
                cantMovePoint.Add(point);
                movePoint.Enqueue(point);
            }
        }

        return sb;
    }
}
public class Point
{
    public int id;
    public List<int> canMovePoint = new();
    public Point(int id)
    {
        this.id = id;
    }
}
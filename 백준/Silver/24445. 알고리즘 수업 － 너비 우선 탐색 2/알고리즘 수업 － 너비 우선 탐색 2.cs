using System.Collections;
using System.Text;

class Program
{
    static void Main()
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());

        int[] inputs = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);

        int pointCount = inputs[0];
        int lineCount = inputs[1];
        int startPoint = inputs[2];

        Dictionary<int, Point> pointDic = new();

        for (int i = 1; i <= pointCount; i++) pointDic.Add(i,new Point(i));
        

        for (int i = 0; i< lineCount; i++)
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

        Queue<Point> canMovePoint = new();
        HashSet<int> cantMovePoint = new();

        Point currentPoint = pointDic[startPoint];

        canMovePoint.Enqueue(currentPoint);
        cantMovePoint.Add(currentPoint.id);

        int[] counts = new int[pointCount];
        int currentCount = 1;

        while (canMovePoint.Count > 0)
        {
            currentPoint = canMovePoint.Dequeue();
            counts[currentPoint.id-1] = currentCount++;
            foreach(int nextPoinId in currentPoint.canMovePoint)
            {
                if(cantMovePoint.Contains(nextPoinId)) continue;

                Point nextPoint = pointDic[nextPoinId];
                canMovePoint.Enqueue(nextPoint);
                cantMovePoint.Add(nextPoint.id);
            }
        }

        StringBuilder sb = new StringBuilder();
        foreach(int a in counts)
        {
            sb.Append($"{a}\n");
        }
        Console.WriteLine(sb);

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

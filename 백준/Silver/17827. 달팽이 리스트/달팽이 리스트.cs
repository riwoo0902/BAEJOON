using System.Text;
class Program
{
    static void Main(string[] args)
    {
        StreamReader sr = new StreamReader(Console.OpenStandardInput());
        int[] input1 = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse);
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(" "), int.Parse); ;
        int maxIndex = input1[0];
        int targetIndex = input1[2];
        int loopSize = maxIndex - targetIndex + 1;
        StringBuilder sb = new();
        for(int l = 0; l < input1[1]; l++)
        {
            int input2 = int.Parse(sr.ReadLine()) + 1;
            if(input2 < maxIndex)
            {
                sb.AppendLine(arr[input2 - 1].ToString());
                continue;
            }
            int point = input2 - targetIndex;
            point %= loopSize;
            sb.AppendLine(arr[targetIndex + point - 1].ToString());
        }
        Console.WriteLine(sb.ToString());
    }
}
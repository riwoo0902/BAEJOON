using System.Text;

class Program
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        StringBuilder text = new StringBuilder();
        for (int i = 0; i < input; i++)
        {
            string inputText = Console.ReadLine();
            if (text.ToString() == "")
            {
                text.Append(inputText);
                continue;
            }

            for (int j = 0; j < text.Length; j++)
            {
                if (text[j] == '?') continue;
                if (inputText[j] != text[j])
                {
                    text[j] = '?';
                }
            }
        }
        Console.WriteLine(text.ToString());
    }
}
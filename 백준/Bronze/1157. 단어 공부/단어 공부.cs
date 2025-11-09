string a = Console.ReadLine().ToUpper();
int[] c = new int[26];
foreach (char d in a) c[d - 65]++;
int maxIndex = 0;
int maxValue = 0;
for(int i = 0; i < c.Length; i++)
{
    if(c[i] > maxValue)
    {
        maxIndex = i;
        maxValue = c[i];
    }
    else if(c[i] == maxValue) maxIndex = -1;
}
Console.WriteLine(maxIndex != -1 ? (char)(maxIndex + 65) : "?" );
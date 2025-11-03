            int count = int.Parse(Console.ReadLine());
            int[] buildings = new int[count];
            long endValue = 0;
            for (int i = 0; i < count; i++) buildings[i] = (int.Parse(Console.ReadLine()));
            for (int i = 0; i < count; i++)
            {
                int vsum = 0;
                for (int j = 1; j < count - i; j++)
                {
                    if (buildings[i + j] < buildings[i]) vsum++;
                    else break;
                }
                endValue += vsum;
            }
            Console.WriteLine(endValue);
using System.Collections.Generic;
using System.Linq;

namespace SortUnitTests
{
    public static class InsertSort
    {
        public static int[] Sort(int[] randoms)
        {
            var sorted = new List<int>();
            sorted.Add(randoms.First());

            foreach (int random in randoms.Skip(1))
            {
                if (random < sorted[0])
                {
                    sorted.Insert(0, random);
                }
                else if (random > sorted[sorted.Count - 1])
                {
                    sorted.Add(random);
                }
                else
                {
                    for (int i = 0; i < sorted.Count; i++)
                    {
                        if (random < sorted[i])
                        {
                            sorted.Insert(i, random);
                            break;
                        }
                    }
                }
            }

            return sorted.ToArray();
        }
    }
}
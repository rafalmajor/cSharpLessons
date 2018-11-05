using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralSortUnitTests
{
    public static class InsertSort
    {
        public static T[] Sort<T>(T[] randoms) where T : IComparable<T>
        {
            var sorted = new List<T>();
            sorted.Add(randoms.First());

            foreach (T random in randoms.Skip(1))
            {
                if (random.CompareTo(sorted[0]) < 0 )
                {
                    sorted.Insert(0, random);
                }
                else if (random.CompareTo(sorted[sorted.Count - 1]) > 0)
                {
                    sorted.Add(random);
                }
                else
                {
                    for (int i = 0; i < sorted.Count; i++)
                    {
                        if (random.CompareTo(sorted[i]) < 0)
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
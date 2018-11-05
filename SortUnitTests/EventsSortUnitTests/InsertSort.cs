using System;
using System.Collections.Generic;
using System.Linq;

namespace EventsSortUnitTests
{
    public class InsertSort : ISort
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

        public int[] Input { private get; set; }

        public int[] Output { get; private set; }

        public event EventHandler Done;

        public void Sort()
        {
            var sorted = new List<int>();
            sorted.Add(this.Input.First());

            foreach (int random in this.Input.Skip(1))
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

            this.Output = sorted.ToArray();
            this.Done?.Invoke(this, EventArgs.Empty);
        }
    }
}
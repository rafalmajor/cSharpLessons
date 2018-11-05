using System;

namespace EventsSortUnitTests
{
    public interface ISort
    {
        int[] Input { set; }
        int[] Output { get; }
        event EventHandler Done;
        void Sort();
    }
}
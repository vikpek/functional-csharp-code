using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Exercises.Chapter1
{
    public static class Exercises
    {
        // 1. Write a function that negates a given predicate: whenvever the given predicate
        // evaluates to `true`, the resulting function evaluates to `false`, and vice versa.

        static Func<T, bool> negate<T>(this Func<T, bool> pred) => t => !pred(t);

        // 2. Write a method that uses quicksort to sort a `List<int>` (return a new list,
        // rather than sorting it in place).

        static List<int> QuickSort(this List<int> list)
        {
            Console.Write("{0}", list.Count);
            if (list.Count == 0) return new List<int>();

            int pivot = list[0];
            IEnumerable<int> rest = list.Skip(1);

            IEnumerable<int> small = from item in rest where item <= pivot select item;
            IEnumerable<int> large = from item in rest where pivot < item select item;

            return small.ToList().QuickSort().Append(pivot).Concat(large.ToList().QuickSort()).ToList();

        }
        
        [Test]
        public static void TestQuickSort()
        {
            var list = new List<int> {-100, 63, 30, 45, 1, 1000, -23, -67, 1, 2, 56, 75, 975, 432, -600, 193, 85, 12};
            var expected = new List<int>
                {-600, -100, -67, -23, 1, 1, 2, 12, 30, 45, 56, 63, 75, 85, 193, 432, 975, 1000};
            var actual = list.QuickSort();
            Assert.AreEqual(expected, actual);
        }

        // 3. Generalize your implementation to take a `List<T>`, and additionally a 
        // `Comparison<T>` delegate.

        // 4. In this chapter, you've seen a `Using` function that takes an `IDisposable`
        // and a function of type `Func<TDisp, R>`. Write an overload of `Using` that
        // takes a `Func<IDisposable>` as first
        // parameter, instead of the `IDisposable`. (This can be used to fix warnings
        // given by some code analysis tools about instantiating an `IDisposable` and
        // not disposing it.)
    }
}
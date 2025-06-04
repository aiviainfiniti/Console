using System;
using System.Linq;
using System.Collections.Generic;

namespace Distinct
{
    class DistinctCount
    {
        private static int[] DistinctList(int[] arr)
        {
            return [.. arr.Distinct()];

            // or older way
            // return arr.Distinct().ToArray();

            // or even older way
            // List<int> distinctList = new List<int>();
            // foreach (int num in arr)
            // {
            //     if (!distinctList.Contains(num))
            //     {
            //         distinctList.Add(num);
            //     }
            // }
            // return distinctList.ToArray();

            // or using HashSet
            // HashSet<int> distinctSet = new HashSet<int>();
            // foreach (int num in arr)
            // {
            //     distinctSet.Add(num);
            // }
            // return distinctSet.ToArray();
        }
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 2, 2, 3, 5, 5, 6, 6, 7, 8, 9, 9 };
            int[] input = new int[] { 1, 2, 2, 2, 3, 5, 5, 6, 6, 7, 8, 9, 9 };
            Console.WriteLine(input.Length - DistinctList(input).Length);
        }
    }
}
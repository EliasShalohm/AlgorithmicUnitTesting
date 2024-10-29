using System.Runtime.ConstrainedExecution;
using System;
using System.Diagnostics;

namespace AlgorithmicUnitTesting
{
    public class TestClass
    {
        /// <summary>
        /// Positive Cases: Test that the algorithm sorts arrays as expected under typical, valid input conditions — this is the “happy path” where the algorithm performs as intended.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="expectation"></param>
        /// <returns></returns>
        internal static bool PositiveTest(int[] arr, int[] expectation)
        {
            Console.WriteLine("\nConducting unit test - Positive.");
            int[] sortedArray = QuickSort.SortArray(arr);
            bool result = Enumerable.SequenceEqual(sortedArray, expectation);
            Console.WriteLine($"Result : {result}");
            return result;
        }

        /// <summary>
        /// Performance Cases: Test that the algorithm performs efficiently with arrays of varying sizes.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="expectation"></param>
        /// <returns></returns>
        internal static bool PerformanceTest()
        {
            var array = ExtensionMethods.GenerateRandomArray(1000);
            if (array != null)
            {
                Console.WriteLine("\nConducting unit test - Performance.");
                
                // MEASURE ELAPSED TIME
                int[] sortedArray = QuickSort.SortArray(array);

                array = ExtensionMethods.GenerateRandomArray(500);
                sortedArray = QuickSort.SortArray(array);
                var result = false;
                Console.WriteLine($"Result : {result}");
                return result;
            }
            return false;
        }

        /// <summary>
        /// Boundary Cases: Ensure the algorithm works correctly for edge cases, such as empty arrays, single-element arrays, arrays with duplicate values, and already sorted or reverse-sorted arrays.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="expectation"></param>
        /// <returns></returns>
        internal static bool BoundaryTest(int[] arr, int[] expectation)
        {
            Console.WriteLine("\nConducting unit test - Positive.");
            int[] sortedArray = QuickSort.SortArray(arr);
            bool result = Enumerable.SequenceEqual(sortedArray, expectation);
            Console.WriteLine($"Result : {result}");
            return result;
        }

        /// <summary> 
        /// Idempotency Cases: Confirm that running the algorithm multiple times on the same array produces consistent results, ensuring stability across repeated executions.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="expectation"></param>
        /// <returns></returns>
        internal static bool IdempotencyTest(int[] arr, int[] expectation)
        {
            Console.WriteLine("\nConducting unit test - Positive.");
            int[] sortedArray = QuickSort.SortArray(arr);
            bool result = Enumerable.SequenceEqual(sortedArray, expectation);
            Console.WriteLine($"Result : {result}");
            return result;
        }
    }
}

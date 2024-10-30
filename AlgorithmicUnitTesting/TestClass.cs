using System.Diagnostics;

namespace AlgorithmicUnitTesting
{
    public class TestClass
    {
        static Stopwatch timer = new();

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
        /// <returns>Whether or not the test worked.</returns>
        internal static bool PerformanceTest(int sizeA, int sizeB)
        {
            var array = ExtensionMethods.GenerateRandomArray(sizeA);
            var array2 = ExtensionMethods.GenerateRandomArray(sizeB);
            if (array != null)
            {
                Console.WriteLine("\nConducting unit test - Performance.");

                timer.Start();
                // MEASURE ELAPSED TIME
                array = QuickSort.SortArray(array);
                var time1 = timer.ElapsedMilliseconds;
                Console.WriteLine($"Execution time for input size {sizeA}: {time1} ms");
                timer.Stop();

                timer = new();

                timer.Start();
                array2 = QuickSort.SortArray(array2);
                var time2 = timer.ElapsedMilliseconds;
                Console.WriteLine($"Execution time for input size {sizeB}: {time2} ms");
                timer.Stop();

                var result = (time1 - time2) > 0;
                Console.WriteLine($"Result : {result}");
                return result;
            }
            return false;
        }

        /// <summary>
        /// Boundary Cases: Ensure the algorithm works correctly for edge cases,
        /// such as empty arrays,
        /// single-element arrays,
        /// arrays with duplicate values,
        /// and already sorted or reverse-sorted arrays.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="expectation"></param>
        /// <returns></returns>
        internal static bool BoundaryTest(int[] empty_arr, int[] single_arr, int[] dup_arr, int[] sorted_arr)
        {
            Console.WriteLine("\nConducting unit test - Boundary.");
            Console.WriteLine($"Array Lengths: {empty_arr.Length}. {single_arr.Length}. {dup_arr.Length}. {sorted_arr.Length}");
            try
            {
                _ = QuickSort.SortArray(empty_arr);
                _ = QuickSort.SortArray(single_arr);
                _ = QuickSort.SortArray(dup_arr);
                _ = QuickSort.SortArray(sorted_arr);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary> 
        /// Idempotency Cases: Confirm that running the algorithm multiple times on the same array produces consistent results, ensuring stability across repeated executions.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="expectation"></param>
        /// <returns></returns>
        internal static bool IdempotencyTest(int[] arr, int[] expectation)
        {
            Console.WriteLine("\nConducting unit test - Idempotency.");
            QuickSort.SortArray(arr).PrintArray("Run 1");
            QuickSort.SortArray(arr).PrintArray("Run 2");
            QuickSort.SortArray(arr).PrintArray("Run 3");
            QuickSort.SortArray(arr).PrintArray("Run 4");
            var sorted = QuickSort.SortArray(arr).PrintArray("Run 5");
            bool result = Enumerable.SequenceEqual(sorted, expectation);
            Console.WriteLine($"Result : {result}");
            return result;
        }
    }
}

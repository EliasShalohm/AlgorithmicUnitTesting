// See https://aka.ms/new-console-template for more information
using AlgorithmicUnitTesting;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
        int[] sortedArr = new int[] { -4, 0, 2, 5, 6, 11, 18, 22, 51, 67 };

        arr.PrintArray("Original");
        sortedArr.PrintArray("Expected Sorted");

        QuickSort.SortArray(arr, 0, arr.Length - 1);

#if DEBUG
        Debug.Assert(TestClass.PositiveTest(arr, sortedArr));
        Debug.Assert(TestClass.PerformanceTest());
#endif

    }

}

public static class ExtensionMethods
{
    public static int[] PrintArray(this int[] array, string form)
    {
        Console.WriteLine($"{form} array : ");
        foreach (var item in array)
        {
            Console.Write(" " + item);
        }
        Console.WriteLine();
        return array;
    }
    public static int[]? GenerateRandomArray(int length)
    {
        Random rand = new();
        if (length > 0)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = rand.Next(0, array.Length);
            }
            return array;
        }
        return null;
    }
}
/*

Negative Cases: Verify that the algorithm gracefully handles invalid or unexpected inputs,
such as incorrect data types (e.g., strings instead of numbers) or out-of-range values.

Performance Cases: Test that the algorithm performs efficiently with arrays of varying sizes. You might use small arrays, large arrays, or arrays with different levels of pre-sortedness.

Boundary Cases: Ensure the algorithm works correctly for edge cases, such as empty arrays, single-element arrays, arrays with duplicate values, and already sorted or reverse-sorted arrays.

Idempotency Cases: Confirm that running the algorithm multiple times on the same array produces consistent results, ensuring stability across repeated executions.
 */
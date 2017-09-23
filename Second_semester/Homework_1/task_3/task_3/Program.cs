using System;

namespace task_3
{
    class Program
    {
        /// if the length of array is less than 10, QuickSort uses a InsertSort
        private static void InsertSort(int[] array, int left, int right)
        {
            for (int i = left + 1; i <= right; ++i)
            {
                for (int j = i; j > left; --j)
                {
                    if (array[j] < array[j - 1])
                    {
                        var temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                    }
                    else
                        break;
                }
            }
        }

        static void QuickSort(int[] array, int left, int right)
        {
            if (right - left <= 10)
            {
                InsertSort(array, left, right);
                return;
            }
            int referenceCell = array[left + (right - left) / 2];
            int i = left;
            int j = right;
            while (i <= j)
            {
                while (array[i] < referenceCell)
                    ++i;
                while (array[j] > referenceCell)
                    --j;
                if (i <= j)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i;
                    --j;
                }
            }
            if (i < right)
            {
                QuickSort(array, i, right);
            }
            if (left < j)
            {
                QuickSort(array, left, j);
            }
        }

        static void Main(string[] args)
        {
            Random randomMumber = new Random();
            Console.WriteLine("Enter the length of array");
            var length = 0;
            length = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                array[i] = randomMumber.Next(0, 100);
            }

            foreach (int element in array)
            {
                Console.Write(element + " ");
            }

            Console.WriteLine();
            QuickSort(array, 0, length - 1);

            foreach (int element in array)
            {
                Console.Write(element + " ");
            }
        }
    }
}

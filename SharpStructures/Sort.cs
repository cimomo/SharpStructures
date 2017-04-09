/*
 * Copyright (C) Kai Chen
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpStructures
{
    public class Sort
    {
        public static void BubbleSort(int[] data)
        {
            int numToSort = data.Length;

            while (numToSort > 0)
            {
                for (int i = 1; i < numToSort; i++)
                {
                    if (data[i] < data[i - 1])
                    {
                        Swap(data, i, i-1);
                    }
                }

                numToSort--;
            }
        }

        public static void SelectionSort(int[] data)
        {
            int numToSort = data.Length;
            int max = 0;

            while (numToSort > 0)
            {
                max = 0;
                for (int i = 1; i < numToSort; i++)
                {
                    if (data[max] < data[i])
                    {
                        max = i;
                    }
                }

                Swap(data, max, numToSort - 1);
                numToSort--;
            }
        }

        public static void InsertionSort(int[] data)
        {
            int numSorted = 1;

            while (numSorted < data.Length)
            {
                int tmp = data[numSorted];

                for (int i = numSorted; i > 0; i--)
                {
                    if (tmp < data[i - 1])
                    {
                        data[i] = data[i - 1];
                    }
                    else
                    {
                        data[i] = tmp;
                        break;
                    }
                }

                numSorted++;
            }
        }

        public static void MergeSort(int[] data)
        {
            int[] temp = new int[data.Length];
            MergeSortRecursive(data, temp, 0, data.Length - 1);
        }

        public static void QuickSort(int[] data)
        {
            QuickSortRecursive(data, 0, data.Length - 1);
        }

        private static void Swap(int[] data, int i, int j)
        {
            Assertion.Pre(i < data.Length && j < data.Length && i >= 0 && j >= 0);
            int tmp = data[i];
            data[i] = data[j];
            data[j] = tmp;
        }

        private static void Merge(int[] data, int[] temp, int low, int middle, int high)
        {
            int ri = low;
            int ti = low;
            int di = middle;

            while (ti < middle && di <= high)
            {
                if (data[di] < temp[ti])
                {
                    data[ri++] = data[di++];
                }
                else
                {
                    data[ri++] = temp[ti++];
                }
            }

            while (ti < middle)
            {
                data[ri++] = temp[ti++];
            }
        }

        private static void MergeSortRecursive(int[] data, int[] temp, int low, int high)
        {
            int n = high - low + 1;
            int middle = low + n / 2;

            if (n < 2)
            {
                return;
            }

            for (int i = low; i < middle; i++)
            {
                temp[i] = data[i];
            }

            MergeSortRecursive(temp, data, low, middle - 1);
            MergeSortRecursive(data, temp, middle, high);
            Merge(data, temp, low, middle, high);
        }

        private static int Partition(int[] data, int left, int right)
        {
            while (true)
            {
                while (left < right && data[left] < data[right])
                {
                    right--;
                }

                if (left < right)
                {
                    Swap(data, left++, right);
                }
                else
                {
                    return left;
                }

                while (left < right && data[left] < data[right])
                {
                    left++;
                }

                if (left < right)
                {
                    Swap(data, left, right--);
                }
                else
                {
                    return right;
                }
            }
        }

        private static void QuickSortRecursive(int[] data, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivot = Partition(data, left, right);

            QuickSortRecursive(data, left, pivot - 1);
            QuickSortRecursive(data, pivot + 1, right);
        }
    }
}

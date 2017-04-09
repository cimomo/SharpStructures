/*
 * Copyright (C) Kai Chen
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SharpStructures
{
    [TestFixture]
    class SortTest
    {
        int[] data;

        [SetUp]
        public void TestSetup()
        {
            data = new int[] {2, 100, -5, -7, 0, 101, 4, -100, 0, 2, 3, -1};
        }

        [Test]
        public void TestBubbleSort()
        {
            Assert.IsFalse(IsSorted(data));
            Sort.BubbleSort(data);
            Assert.IsTrue(IsSorted(data));
        }

        [Test]
        public void TestSelectionSort()
        {
            Assert.IsFalse(IsSorted(data));
            Sort.SelectionSort(data);
            Assert.IsTrue(IsSorted(data));
        }

        [Test]
        public void TestInsertionSort()
        {
            Assert.IsFalse(IsSorted(data));
            Sort.InsertionSort(data);
            Assert.IsTrue(IsSorted(data));
        }

        [Test]
        public void TestMergeSort()
        {
            Assert.IsFalse(IsSorted(data));
            Sort.MergeSort(data);
            Assert.IsTrue(IsSorted(data));
        }

        [Test]
        public void TestQuickSort()
        {
            Assert.IsFalse(IsSorted(data));
            Sort.QuickSort(data);
            Assert.IsTrue(IsSorted(data));
        }

        private static bool IsSorted(int[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] < data[i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}

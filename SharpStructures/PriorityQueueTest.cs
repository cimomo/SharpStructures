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
    class PriorityQueueTest
    {
        PriorityQueue<int> vh;

        [SetUp]
        public void TestSetup()
        {
            InitializeVectorHeap();
        }

        [Test]
        public void TestAddPeekRemoveVectorHeap()
        {
            TestAddPeekRemove(vh);
        }

        private void InitializeVectorHeap()
        {
            vh = new VectorHeap<int>();
            Assert.IsTrue(vh.IsEmpty());
            Assert.AreEqual(0, vh.Size);
        }

        private void TestAddPeekRemove(PriorityQueue<int> pq)
        {
            vh.Add(5);
            Assert.IsFalse(vh.IsEmpty());
            Assert.AreEqual(1, vh.Size);
            Assert.AreEqual(5, vh.Peek());

            vh.Add(0);
            Assert.AreEqual(2, vh.Size);
            Assert.AreEqual(0, vh.Peek());

            vh.Add(10);
            Assert.AreEqual(3, vh.Size);
            Assert.AreEqual(0, vh.Peek());

            vh.Add(1);
            vh.Add(4);
            vh.Add(6);
            vh.Add(9);
            vh.Add(2);
            vh.Add(3);
            vh.Add(8);
            vh.Add(7);
            Assert.AreEqual(11, vh.Size);
            Assert.AreEqual(0, vh.Peek());

            int value = vh.Remove();
            Assert.AreEqual(0, value);
            Assert.AreEqual(10, vh.Size);
            Assert.AreEqual(1, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(1, value);
            Assert.AreEqual(9, vh.Size);
            Assert.AreEqual(2, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(2, value);
            Assert.AreEqual(8, vh.Size);
            Assert.AreEqual(3, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(3, value);
            Assert.AreEqual(7, vh.Size);
            Assert.AreEqual(4, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(4, value);
            Assert.AreEqual(6, vh.Size);
            Assert.AreEqual(5, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(5, value);
            Assert.AreEqual(5, vh.Size);
            Assert.AreEqual(6, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(6, value);
            Assert.AreEqual(4, vh.Size);
            Assert.AreEqual(7, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(7, value);
            Assert.AreEqual(3, vh.Size);
            Assert.AreEqual(8, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(8, value);
            Assert.AreEqual(2, vh.Size);
            Assert.AreEqual(9, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(9, value);
            Assert.AreEqual(1, vh.Size);
            Assert.AreEqual(10, vh.Peek());

            value = vh.Remove();
            Assert.AreEqual(10, value);
            Assert.AreEqual(0, vh.Size);
            Assert.IsTrue(vh.IsEmpty());

        }
    }
}

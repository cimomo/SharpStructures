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
    class ListTest
    {
        List<int> sList;
        List<int> dList;
        List<int> cList;

        [SetUp]
        public void TestSetup()
        {
            CreateSinglyLinkedList();
            CreateDoublyLinkedList();
            CreateCircularList();
        }

        [Test]
        public void TestPeekSingly()
        {
            TestPeek(sList);
        }

        [Test]
        public void TestPeekTailSingly()
        {
            TestPeekTail(sList);
        }

        [Test]
        public void TestAddToHeadSingly()
        {
            TestAddToHead(sList);
        }

        [Test]
        public void TestAddToTailSingly()
        {
            TestAddToTail(sList);
        }

        [Test]
        public void TestRemoveFromHeadSingly()
        {
            TestRemoveFromHead(sList);
        }

        [Test]
        public void TestRemoveFromTailSingly()
        {
            TestRemoveFromTail(sList);
        }

        [Test]
        public void TestContainsSingly()
        {
            TestContains(sList);
        }

        [Test]
        public void TestRemoveSingly()
        {
            TestRemove(sList);
        }

        [Test]
        public void TestPeekDoubly()
        {
            TestPeek(dList);
        }

        [Test]
        public void TestPeekTailDoubly()
        {
            TestPeekTail(dList);
        }

        [Test]
        public void TestAddToHeadDoubly()
        {
            TestAddToHead(dList);
        }

        [Test]
        public void TestAddToTailDoubly()
        {
            TestAddToTail(dList);
        }

        [Test]
        public void TestRemoveFromHeadDoubly()
        {
            TestRemoveFromHead(dList);
        }

        [Test]
        public void TestRemoveFromTailDoubly()
        {
            TestRemoveFromTail(dList);
        }

        [Test]
        public void TestContainsDoubly()
        {
            TestContains(dList);
        }

        [Test]
        public void TestRemoveDoubly()
        {
            TestRemove(dList);
        }

        [Test]
        public void TestPeekCircular()
        {
            TestPeek(cList);
        }

        [Test]
        public void TestPeekTailCircular()
        {
            TestPeekTail(cList);
        }

        [Test]
        public void TestAddToHeadCircular()
        {
            TestAddToHead(cList);
        }

        [Test]
        public void TestAddToTailCircular()
        {
            TestAddToTail(cList);
        }

        [Test]
        public void TestRemoveFromHeadCircular()
        {
            TestRemoveFromHead(cList);
        }

        [Test]
        public void TestRemoveFromTailCircular()
        {
            TestRemoveFromTail(cList);
        }

        [Test]
        public void TestContainsCircular()
        {
            TestContains(cList);
        }

        [Test]
        public void TestRemoveCircular()
        {
            TestRemove(cList);
        }

        private void CreateSinglyLinkedList()
        {
            sList = new SinglyLinkedList<int>();
            Assert.AreEqual(0, sList.Size);

            sList.Add(0);
            sList.Add(1);
            sList.Add(2);
            Assert.AreEqual(3, sList.Size);
        }

        private void CreateDoublyLinkedList()
        {
            dList = new DoublyLinkedList<int>();
            Assert.AreEqual(0, dList.Size);

            dList.Add(0);
            dList.Add(1);
            dList.Add(2);
            Assert.AreEqual(3, dList.Size);
        }

        private void CreateCircularList()
        {
            cList = new CircularList<int>();
            Assert.AreEqual(0, cList.Size);

            cList.Add(0);
            cList.Add(1);
            cList.Add(2);
            Assert.AreEqual(3, cList.Size);
        }

        private void TestPeek(List<int> list)
        {
            int v = list.Peek();
            Assert.AreEqual(2, v);
        }

        private void TestPeekTail(List<int> list)
        {
            int v = list.PeekTail();
            Assert.AreEqual(0, v);
        }

        private void TestAddToHead(List<int> list)
        {
            list.AddToHead(100);
            int v = list.Peek();
            Assert.AreEqual(100, v);
        }

        private void TestAddToTail(List<int> list)
        {
            list.AddToTail(101);
            int v = list.PeekTail();
            Assert.AreEqual(101, v);
        }

        private void TestRemoveFromHead(List<int> list)
        {
            int v = list.RemoveFromHead();
            Assert.AreEqual(2, v);
            Assert.AreEqual(2, list.Size);
        }

        private void TestRemoveFromTail(List<int> list)
        {
            int v = list.RemoveFromTail();
            Assert.AreEqual(0, v);
            Assert.AreEqual(2, list.Size);
        }

        private void TestContains(List<int> list)
        {
            Assert.IsTrue(list.Contains(1));
            Assert.IsFalse(list.Contains(100));
        }

        private void TestRemove(List<int> list)
        {
            Assert.AreEqual(0, list.Remove(100));

            int v = list.Remove(2);
            Assert.AreEqual(2, v);
            Assert.AreEqual(2, list.Size);

            v = list.Remove(0);
            Assert.AreEqual(0, v);
            Assert.AreEqual(1, list.Size);

            v = list.Remove(1);
            Assert.AreEqual(1, v);
            Assert.AreEqual(0, list.Size);
        }
    }
}

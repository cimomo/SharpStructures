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
    class QueueTest
    {
        Queue<int> vq;
        Queue<int> lq;
        Queue<int> aq;

        [SetUp]
        public void TestSetup()
        {
            InitializeVectorQueue();
            InitializeListQueue();
            InitializeArrayQueue();
        }

        [Test]
        public void TestEnqueueDequeueVector()
        {
            TestEnqueueDequeue(vq);
        }

        [Test]
        public void TestEnqueueDequeueList()
        {
            TestEnqueueDequeue(lq);
        }

        [Test]
        public void TestEnqueueDequeueArray()
        {
            TestEnqueueDequeue(aq);
        }

        [Test]
        public void TestClearVector()
        {
            TestClear(vq);
        }

        [Test]
        public void TestClearList()
        {
            TestClear(lq);
        }

        [Test]
        public void TestClearArray()
        {
            TestClear(aq);
        }

        private void InitializeVectorQueue()
        {
            vq = new VectorQueue<int>();
            Assert.IsTrue(vq.IsEmpty());
            Assert.AreEqual(0, vq.Size);
        }

        private void InitializeListQueue()
        {
            lq = new ListQueue<int>();
            Assert.IsTrue(lq.IsEmpty());
            Assert.AreEqual(0, lq.Size);
        }

        private void InitializeArrayQueue()
        {
            aq = new ArrayQueue<int>(10);
            Assert.IsTrue(aq.IsEmpty());
            Assert.AreEqual(0, lq.Size);
        }

        private void TestEnqueueDequeue(Queue<int> queue)
        {
            queue.Enqueue(0);
            Assert.IsFalse(queue.IsEmpty());
            Assert.AreEqual(1, queue.Size);
            Assert.AreEqual(0, queue.Peek());

            queue.Enqueue(1);
            Assert.AreEqual(2, queue.Size);
            Assert.AreEqual(0, queue.Peek());

            queue.Enqueue(2);
            Assert.AreEqual(3, queue.Size);
            Assert.AreEqual(0, queue.Peek());

            int v = queue.Dequeue();
            Assert.AreEqual(2, queue.Size);
            Assert.AreEqual(0, v);

            v = queue.Dequeue();
            Assert.AreEqual(1, queue.Size);
            Assert.AreEqual(1, v);

            v = queue.Dequeue();
            Assert.AreEqual(0, queue.Size);
            Assert.AreEqual(2, v);
        }

        private void TestClear(Queue<int> queue)
        {
            queue.Clear();
            Assert.AreEqual(0, queue.Size);
        }
    }
}

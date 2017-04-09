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
    class StackTest
    {
        Stack<int> vs;
        Stack<int> ls;

        [SetUp]
        public void TestSetup()
        {
            InitializeVectorStack();
            InitializeListStack();
        }

        [Test]
        public void TestPushPopVector()
        {
            TestPushPop(vs);
        }

        [Test]
        public void TestPushPopList()
        {
            TestPushPop(ls);
        }

        [Test]
        public void TestClearVector()
        {
            TestClear(vs);
        }

        [Test]
        public void TestClearList()
        {
            TestClear(ls);
        }

        private void InitializeVectorStack()
        {
            vs = new VectorStack<int>();
            Assert.IsTrue(vs.IsEmpty());
            Assert.AreEqual(0, vs.Size);
        }

        private void InitializeListStack()
        {
            ls = new ListStack<int>();
            Assert.IsTrue(ls.IsEmpty());
            Assert.AreEqual(0, ls.Size);
        }

        private void TestPushPop(Stack<int> stack)
        {
            stack.Push(0);
            Assert.IsFalse(stack.IsEmpty());
            Assert.AreEqual(1, stack.Size);
            Assert.AreEqual(0, stack.Peek());

            stack.Push(1);
            Assert.AreEqual(2, stack.Size);
            Assert.AreEqual(1, stack.Peek());

            stack.Push(2);
            Assert.AreEqual(3, stack.Size);
            Assert.AreEqual(2, stack.Peek());

            int v = stack.Pop();
            Assert.AreEqual(2, stack.Size);
            Assert.AreEqual(2, v);

            v = stack.Pop();
            Assert.AreEqual(1, stack.Size);
            Assert.AreEqual(1, v);

            v = stack.Pop();
            Assert.AreEqual(0, stack.Size);
            Assert.AreEqual(0, v);
        }

        private void TestClear(Stack<int> stack)
        {
            stack.Clear();
            Assert.AreEqual(0, stack.Size);
        }
    }
}

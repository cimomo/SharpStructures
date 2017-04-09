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
    class BinaryTreeTest
    {
        BinaryTree<int> tree;

        [SetUp]
        public void TestSetup()
        {
            tree = new BinaryTree<int>();
            Assert.IsTrue(tree.IsEmpty());
            Assert.IsFalse(tree.IsValid());
            Assert.AreEqual(0, tree.Size);
        }

        [Test]
        public void TestInsert()
        {
            tree.Insert(100);
            Assert.IsFalse(tree.IsEmpty());
            Assert.IsTrue(tree.IsValid());
            Assert.AreEqual(1, tree.Size);
            Assert.AreEqual(100, tree.GetValue());
        }

        [Test]
        public void TestRemove()
        {
            tree.Insert(100);
            tree.MoveLeft();
            tree.Insert(101);
            Assert.AreEqual(2, tree.Size);
            Assert.AreEqual(101, tree.GetValue());
            tree.Remove();
            Assert.AreEqual(1, tree.Size);
            Assert.AreEqual(100, tree.GetValue());
        }

        [Test]
        public void TestSetGetValue()
        {
            tree.Insert(100);
            tree.MoveRight();
            tree.Insert(102);
            Assert.AreEqual(102, tree.GetValue());
            tree.SetValue(103);
            Assert.AreEqual(103, tree.GetValue());
        }

        [Test]
        public void TestReset()
        {
            tree.Insert(100);
            tree.MoveLeft();
            tree.Insert(101);
            tree.MoveRight();
            tree.Insert(102);
            tree.Reset();
            Assert.AreEqual(100, tree.GetValue());
        }

        [Test]
        public void TestClear()
        {
            tree.Insert(100);
            tree.MoveLeft();
            tree.Insert(101);
            tree.MoveRight();
            tree.Insert(102);
            tree.Clear();
            Assert.IsTrue(tree.IsEmpty());
            Assert.IsFalse(tree.IsValid());
            Assert.AreEqual(0, tree.Size);
        }

        [Test]
        public void TestIsValid()
        {
            Assert.IsFalse(tree.IsValid());
            tree.Insert(100);
            Assert.IsTrue(tree.IsValid());
            tree.MoveLeft();
            Assert.IsFalse(tree.IsValid());
        }

        [Test]
        public void TestHasLeft()
        {
            tree.Insert(100);
            tree.MoveLeft();
            tree.Insert(101);
            tree.MoveUp();
            Assert.IsTrue(tree.HasLeft());
            Assert.IsFalse(tree.HasRight());
        }

        [Test]
        public void TestHasRight()
        {
            tree.Insert(100);
            tree.MoveRight();
            tree.Insert(102);
            tree.MoveUp();
            Assert.IsFalse(tree.HasLeft());
            Assert.IsTrue(tree.HasRight());
        }

        [Test]
        public void TestHasParent()
        {
            tree.Insert(100);
            tree.MoveLeft();
            tree.Insert(101);
            Assert.IsTrue(tree.HasParent());
            tree.MoveUp();
            Assert.IsFalse(tree.HasParent());
            tree.MoveRight();
            tree.Insert(102);
            Assert.IsTrue(tree.HasParent());
        }

        [Test]
        public void TestIsLeft()
        {
            tree.Insert(100);
            tree.MoveLeft();
            tree.Insert(101);
            Assert.IsTrue(tree.IsLeft());
            Assert.IsFalse(tree.IsRight());
        }

        [Test]
        public void TestIsRight()
        {
            tree.Insert(100);
            tree.MoveRight();
            tree.Insert(102);
            Assert.IsFalse(tree.IsLeft());
            Assert.IsTrue(tree.IsRight());
        }
    }
}

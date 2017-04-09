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
    class IteratorTest
    {
        Iterator<int> vi;
        Iterator<int> preIter;
        Iterator<int> inIter;
        Iterator<int> postIter;
        Iterator<int> levelIter;

        [SetUp]
        public void TestSetup()
        {
            InitializeVectorIterator();
            InitializeBinaryTreePreorderIterator();
            InitializeBinaryTreeInorderIterator();
            InitializeBinaryTreePostorderIterator();
            InitializeBinaryTreeLevelorderIterator();
        }

        [Test]
        public void TestIterationVector()
        {
            TestIteration(vi);
        }

        [Test]
        public void TestIterationBinaryTreePreorder()
        {
            TestIteration(preIter);
        }

        [Test]
        public void TestResetVector()
        {
            TestReset(vi);
        }

        [Test]
        public void TestResetBinaryTreePreorder()
        {
            TestReset(preIter);
        }

        [Test]
        public void TestIterationBinaryTreeInorder()
        {
            TestIteration(inIter);
        }

        [Test]
        public void TestResetBinaryTreeInorder()
        {
            TestReset(inIter);
        }

        [Test]
        public void TestIterationBinaryTreePostorder()
        {
            TestIteration(postIter);
        }

        [Test]
        public void TestResetBinaryTreePostorder()
        {
            TestReset(postIter);
        }

        [Test]
        public void TestIterationBinaryTreeLevelorder()
        {
            TestIteration(levelIter);
        }

        [Test]
        public void TestResetBinaryTreeLevelorder()
        {
            TestReset(levelIter);
        }

        private void InitializeVectorIterator()
        {
            Vector<int> v = new Vector<int>();
            v.AddElement(0);
            v.AddElement(1);
            v.AddElement(2);

            vi = v.GetElements();
        }

        private void InitializeBinaryTreePreorderIterator()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(0);
            tree.MoveLeft();
            tree.Insert(1);
            tree.MoveUp();
            tree.MoveRight();
            tree.Insert(2);
            tree.MoveLeft();
            tree.Insert(3);
            tree.MoveUp();
            tree.MoveRight();
            tree.Insert(4);

            preIter = tree.GetPreorderElements();
        }

        private void InitializeBinaryTreeInorderIterator()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(1);
            tree.MoveLeft();
            tree.Insert(0);
            tree.MoveUp();
            tree.MoveRight();
            tree.Insert(3);
            tree.MoveLeft();
            tree.Insert(2);
            tree.MoveUp();
            tree.MoveRight();
            tree.Insert(4);

            inIter = tree.GetInorderElements();
        }

        private void InitializeBinaryTreePostorderIterator()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(4);
            tree.MoveLeft();
            tree.Insert(0);
            tree.MoveUp();
            tree.MoveRight();
            tree.Insert(3);
            tree.MoveLeft();
            tree.Insert(1);
            tree.MoveUp();
            tree.MoveRight();
            tree.Insert(2);

            postIter = tree.GetPostorderElements();
        }

        private void InitializeBinaryTreeLevelorderIterator()
        {
            BinaryTree<int> tree = new BinaryTree<int>();
            tree.Insert(0);
            tree.MoveLeft();
            tree.Insert(1);
            tree.MoveUp();
            tree.MoveRight();
            tree.Insert(2);
            tree.MoveLeft();
            tree.Insert(3);
            tree.MoveUp();
            tree.MoveRight();
            tree.Insert(4);

            levelIter = tree.GetLevelorderElements();
        }

        private void TestIteration(Iterator<int> iter)
        {
            for (int expected = 0; iter.HasMore(); expected++, iter.Next())
            {
                int v = iter.GetValue();
                Assert.AreEqual(expected, v);
            }
        }

        private void TestReset(Iterator<int> iter)
        {
            Assert.AreEqual(0, iter.GetValue());
            Assert.AreEqual(0, iter.Next());
            Assert.AreEqual(1, iter.GetValue());
            Assert.AreEqual(1, iter.Next());
            iter.Reset();
            Assert.AreEqual(0, iter.GetValue());
        }
    }
}

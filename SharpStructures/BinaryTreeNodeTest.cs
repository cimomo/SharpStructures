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
    class BinaryTreeNodeTest
    {
        BinaryTreeNode<int> node;

        [SetUp]
        public void TestSetup()
        {
            node = new BinaryTreeNode<int>(0);
            Assert.IsNull(node.GetParent());
            Assert.IsNull(node.GetLeft());
            Assert.IsNull(node.GetRight());
            Assert.AreEqual(0, node.GetValue());
        }

        [Test]
        public void TestSetGetValue()
        {
            node.SetValue(100);
            Assert.AreEqual(100, node.GetValue());
        }

        [Test]
        public void TestSetGetIsLeft()
        {
            BinaryTreeNode<int> left = new BinaryTreeNode<int>(100);
            node.SetLeft(left);
            Assert.AreEqual(left, node.GetLeft());
            Assert.IsNull(node.GetRight());
            Assert.AreEqual(node, left.GetParent());
            Assert.IsTrue(left.IsLeft());
            Assert.IsFalse(left.IsRight());
        }

        [Test]
        public void TestSetGetIsRight()
        {
            BinaryTreeNode<int> right = new BinaryTreeNode<int>(101);
            node.SetRight(right);
            Assert.IsNull(node.GetLeft());
            Assert.AreEqual(right, node.GetRight());
            Assert.AreEqual(node, right.GetParent());
            Assert.IsFalse(right.IsLeft());
            Assert.IsTrue(right.IsRight());
        }
    }
}

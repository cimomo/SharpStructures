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
    class VectorTest
    {
        Vector<int> v;

        [SetUp]
        public void Initialize()
        {
            v = new Vector<int>();

            Assert.AreEqual(0, v.Count);

            v = new Vector<int>(1);

            Assert.AreEqual(0, v.Count);
        }

        [Test]
        public void TestAddRemoveElement()
        {
            for (int i = 0; i < 3; i++)
            {
                v.AddElement(i);
                Assert.AreEqual(i + 1, v.Count);
            }

            for (int i = 0; i < v.Count; i++)
            {
                int value = v.GetElementAt((int)i);
                Assert.AreEqual(i, value);
            }

            int c = v.Count;
            bool result;

            for (int i = 0; i < c; i++)
            {
                result = v.RemoveElement(i);
                Assert.IsTrue(result);
            }

            Assert.AreEqual(0, v.Count);

            result = v.RemoveElement(191);
            Assert.IsFalse(result);
        }

        [Test]
        public void TestSetGetElementAt()
        {
            v.AddElement(0);

            v.SetElementAt(100, 0);

            int result = v.GetElementAt(0);
            Assert.AreEqual(100, result);

            v.SetElementAt(0, 0);

            result = v.GetElementAt(0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestInsertRemoveElementAt()
        {
            int initCount = 3;

            for (int i = 0; i < initCount; i++)
            {
                v.AddElement(i);
            }

            v.InsertElementAt(100, 0);

            Assert.AreEqual(v.Count, initCount+1);

            int value = v.GetElementAt(0);

            Assert.AreEqual(value, 100);

            v.RemoveElementAt(0);

            Assert.AreEqual(v.Count, initCount);

            for (int i = 0; i < v.Count; i++)
            {
                value = v.GetElementAt((int)i);
                Assert.AreEqual(i, value);
            }

            for (int i = 0; i < initCount; i++)
            {
                bool result = v.RemoveElement(i);
                Assert.IsTrue(result);
            }

            Assert.AreEqual(0, v.Count);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidSetElementAt()
        {
            v.SetElementAt(1, 100);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidGetElementAt()
        {
            v.GetElementAt(100);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidInsertElementAt()
        {
            v.InsertElementAt(1, 100);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidRemoveElementAt()
        {
            v.RemoveElementAt(100);
        }

        [Test]
        public void TestClear()
        {
            v.Clear();
            Assert.AreEqual(0, v.Count);
        }
    }
}

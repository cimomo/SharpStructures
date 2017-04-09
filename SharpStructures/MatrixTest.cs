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
    class MatrixTest
    {
        Matrix<int> m;

        [SetUp]
        public void Initialize()
        {
            m = new Matrix<int>(2, 2);

            Assert.AreEqual(2, m.Width);
            Assert.AreEqual(2, m.Height);
        }

        [Test]
        public void TestSetGetElementAt()
        {
            m.SetElementAt(0, 0, 0);
            m.SetElementAt(1, 0, 1);
            m.SetElementAt(10, 1, 0);
            m.SetElementAt(11, 1, 1);

            int x00 = (int)m.GetElementAt(0, 0);
            int x01 = (int)m.GetElementAt(0, 1);
            int x10 = (int)m.GetElementAt(1, 0);
            int x11 = (int)m.GetElementAt(1, 1);

            Assert.AreEqual(0, x00);
            Assert.AreEqual(1, x01);
            Assert.AreEqual(10, x10);
            Assert.AreEqual(11, x11);
        }

        [Test]
        public void TestInsertRowAt()
        {
            m.SetElementAt(10, 1, 0);
            m.SetElementAt(11, 1, 1);
            m.InsertRowAt(1);

            Assert.AreEqual(3, m.Height);

            int x20 = (int)m.GetElementAt(2, 0);
            int x21 = (int)m.GetElementAt(2, 1);

            Assert.AreEqual(10, x20);
            Assert.AreEqual(11, x21);
        }

        [Test]
        public void TestInsertColumnAt()
        {
            m.SetElementAt(1, 0, 1);
            m.SetElementAt(11, 1, 1);

            m.InsertColumnAt(1);

            Assert.AreEqual(3, m.Width);

            int x02 = (int)m.GetElementAt(0, 2);
            int x12 = (int)m.GetElementAt(1, 2);

            Assert.AreEqual(1, x02);
            Assert.AreEqual(11, x12);
        }

        [Test]
        public void TestRemoveRowAt()
        {
            m.SetElementAt(10, 1, 0);
            m.SetElementAt(11, 1, 1);

            Vector<int> row = m.RemoveRowAt(1);

            Assert.AreEqual(1, m.Height);

            int x10 = (int)row.GetElementAt(0);
            int x11 = (int)row.GetElementAt(1);

            Assert.AreEqual(10, x10);
            Assert.AreEqual(11, x11);
        }

        [Test]
        public void TestRemoveColumnAt()
        {
            m.SetElementAt(1, 0, 1);
            m.SetElementAt(11, 1, 1);

            Vector<int> column = m.RemoveColumnAt(1);

            Assert.AreEqual(1, m.Width);

            int x01 = (int)column.GetElementAt(0);
            int x11 = (int)column.GetElementAt(1);

            Assert.AreEqual(1, x01);
            Assert.AreEqual(11, x11);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidGetElementAt()
        {
            m.GetElementAt(100,100);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidSetElementAt()
        {
            m.SetElementAt(0, 100, 100);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidInsertRowAt()
        {
            m.InsertRowAt(100);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidInsertColumnAt()
        {
            m.InsertColumnAt(100);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidRemoveRowAt()
        {
            m.RemoveRowAt(100);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestInvalidRemoveColumnAt()
        {
            m.RemoveColumnAt(100);
        }
    }
}

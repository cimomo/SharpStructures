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
    class DoublyLinkedListElementTest
    {
        DoublyLinkedListElement<int> element;

        [SetUp]
        public void TestSetup()
        {
            element = new DoublyLinkedListElement<int>(1);
        }

        [Test]
        public void TestSetGetValue()
        {
            Assert.AreEqual(1, (int)element.GetValue());
            element.SetValue(2);
            Assert.AreEqual(2, (int)element.GetValue());
        }

        [Test]
        public void TestSetGetPrevious()
        {
            Assert.AreEqual(null, element.GetPrevious());
            DoublyLinkedListElement<int> e = new DoublyLinkedListElement<int>(2, element, null);
            Assert.AreEqual(element, e.GetPrevious());
            Assert.AreEqual(e, element.GetNext());
            DoublyLinkedListElement<int> e2 = new DoublyLinkedListElement<int>(3);
            element.SetPrevious(e2);
            Assert.AreEqual(e2, element.GetPrevious());
            Assert.AreEqual(element, e2.GetNext());
        }

        [Test]
        public void TestSetGetNext()
        {
            Assert.AreEqual(null, element.GetNext());
            DoublyLinkedListElement<int> e = new DoublyLinkedListElement<int>(2, null, element);
            Assert.AreEqual(element, e.GetNext());
            Assert.AreEqual(e, element.GetPrevious());
            DoublyLinkedListElement<int> e2 = new DoublyLinkedListElement<int>(3);
            element.SetNext(e2);
            Assert.AreEqual(e2, element.GetNext());
            Assert.AreEqual(element, e2.GetPrevious());
        }
    }
}

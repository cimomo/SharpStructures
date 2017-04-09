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
    class SinglyLinkedListElementTest
    {
        SinglyLinkedListElement<int> element;

        [SetUp]
        public void TestSetup()
        {
            element = new SinglyLinkedListElement<int>(1);
        }

        [Test]
        public void TestSetGetValue()
        {
            Assert.AreEqual(1, (int)element.GetValue());
            element.SetValue(2);
            Assert.AreEqual(2, (int)element.GetValue());
        }

        [Test]
        public void TestSetGetNext()
        {
            Assert.AreEqual(null, element.GetNext());
            SinglyLinkedListElement<int> e = new SinglyLinkedListElement<int>(2, element);
            Assert.AreEqual(element, e.GetNext());
            SinglyLinkedListElement<int> e2 = new SinglyLinkedListElement<int>(3, null);
            element.SetNext(e2);
            Assert.AreEqual(e2, element.GetNext());
        }
    }
}

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
    class AssertionTest
    {
        [Test]
        public void TestAssertionSucceeded()
        {
            Assertion.Pre(true);
            Assertion.Post(true);
            Assertion.Assert(true);
        }

        [Test]
        [ExpectedException("SharpStructures.PreconditionFailedException")]
        public void TestPreFailed()
        {
            Assertion.Pre(false);
        }

        [Test]
        [ExpectedException("SharpStructures.PostconditionFailedException")]
        public void TestPostFailed()
        {
            Assertion.Post(false);
        }

        [Test]
        [ExpectedException("SharpStructures.AssertionFailedException")]
        public void TestAssertionFailed()
        {
            Assertion.Assert(false);
        }

        [Test]
        [ExpectedException("SharpStructures.AssertionFailedException")]
        public void TestAssertionFail()
        {
            Assertion.Fail();
        }
    }
}

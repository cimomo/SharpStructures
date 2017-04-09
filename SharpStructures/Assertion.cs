/*
 * Copyright (C) Kai Chen
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpStructures
{
    public class Assertion
    {
        public static void Pre(bool test)
        {
            if (!test)
            {
                throw new PreconditionFailedException();
            }
        }

        public static void Post(bool test)
        {
            if (!test)
            {
                throw new PostconditionFailedException();
            }
        }

        public static void Assert(bool test)
        {
            if (!test)
            {
                throw new AssertionFailedException();
            }
        }

        public static void Fail()
        {
            throw new AssertionFailedException();
        }
    }
}

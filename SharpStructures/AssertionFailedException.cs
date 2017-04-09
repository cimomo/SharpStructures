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
    public class AssertionFailedException : Exception
    {
    }

    public class PreconditionFailedException : AssertionFailedException
    {
    }

    public class PostconditionFailedException : AssertionFailedException
    {
    }
}

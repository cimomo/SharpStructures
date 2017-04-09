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
    public abstract class Iterator<T>
    {
        public abstract bool HasMore();

        public abstract T Next();

        public abstract T GetValue();

        public abstract void Reset();
    }
}

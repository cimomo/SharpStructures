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
    public abstract class PriorityQueue<T> where T : IComparable
    {
        public abstract int Size
        {
            get;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public abstract T Peek();

        public abstract void Add(T value);

        public abstract T Remove();

        public abstract void Clear();
    }
}

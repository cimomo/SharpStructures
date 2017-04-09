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
    public abstract class Queue<T>
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

        public abstract void Enqueue(T value);

        public abstract T Dequeue();

        public abstract void Clear();
    }
}

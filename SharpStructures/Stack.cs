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
    public abstract class Stack<T>
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

        public abstract void Push(T value);

        public abstract T Pop();

        public abstract void Clear();
    }
}

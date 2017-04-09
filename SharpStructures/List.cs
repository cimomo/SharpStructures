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
    public abstract class List<T>
    {
        public abstract int Size
        {
            get;
        }

        public bool IsEmpty()
        {
            return this.Size == 0;
        }

        public abstract void Clear();

        public void Add(T value)
        {
            AddToHead(value);
        }

        public abstract void AddToHead(T value);

        public abstract void AddToTail(T value);

        public abstract T Peek();

        public abstract T PeekTail();

        public abstract T RemoveFromHead();

        public abstract T RemoveFromTail();

        public abstract bool Contains(T value);

        public abstract T Remove(T value);
    }
}

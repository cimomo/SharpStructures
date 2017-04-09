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
    public class ArrayQueue<T> : Queue<T>
    {
        private T[] data;
        private int head;
        private int count;

        public ArrayQueue(int maxSize)
        {
            this.data = new T[maxSize];
            this.head = 0;
            this.count = 0;
        }

        public override int Size
        {
            get { return this.count; }
        }

        public override T Peek()
        {
            Assertion.Pre(!this.IsEmpty());
            return this.data[this.head];
        }

        public override void Enqueue(T value)
        {
            Assertion.Pre(!this.IsFull());
            int tail = (this.head + this.count) % this.data.Length;
            this.data[tail] = value;
            this.count++;
        }

        public override T Dequeue()
        {
            Assertion.Pre(!this.IsEmpty());
            T toReturn = this.data[this.head];
            this.head = (this.head + 1) % this.data.Length;
            this.count--;
            return toReturn;
        }

        private bool IsFull()
        {
            return this.Size >= this.data.Length;
        }

        public override void Clear()
        {
            this.head = 0;
            this.count = 0;
        }
    }
}

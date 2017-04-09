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
    public class ListQueue<T> : Queue<T>
    {
        private List<T> data;

        public override int Size
        {
            get { return data.Size; }
        }

        public ListQueue()
        {
            this.data = new DoublyLinkedList<T>();
        }

        public override T Peek()
        {
            return this.data.Peek();
        }

        public override void Enqueue(T value)
        {
            this.data.AddToTail(value);
        }

        public override T Dequeue()
        {
            Assertion.Pre(this.Size != 0);
            return this.data.RemoveFromHead();
        }

        public override void Clear()
        {
            this.data.Clear();
        }
    }
}

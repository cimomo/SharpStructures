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
    public class ListStack<T> : Stack<T>
    {
        private List<T> data;

        public ListStack()
        {
            this.data = new SinglyLinkedList<T>();
        }

        public override int Size
        {
            get
            {
                return this.data.Size;
            }
        }

        public override T Peek()
        {
            Assertion.Pre(this.data.Size != 0);
            return this.data.Peek();
        }

        public override void Push(T value)
        {
            this.data.AddToHead(value);
        }

        public override T Pop()
        {
            Assertion.Pre(this.data.Size != 0);
            return this.data.RemoveFromHead();
        }

        public override void Clear()
        {
            this.data.Clear();
        }
    }
}

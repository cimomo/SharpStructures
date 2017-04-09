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
    public class VectorStack<T> : Stack<T>
    {
        private Vector<T> data;

        public VectorStack()
        {
            this.data = new Vector<T>();
        }

        public override int Size
        {
            get
            {
                return this.data.Count;
            }
        }

        public override T Peek()
        {
            Assertion.Pre(this.data.Count != 0);
            return this.data.GetElementAt(this.data.Count - 1);
        }

        public override void Push(T value)
        {
            this.data.AddElement(value);
        }

        public override T Pop()
        {
            Assertion.Pre(this.data.Count != 0);
            return this.data.RemoveElementAt(this.data.Count - 1);
        }

        public override void Clear()
        {
            this.data.Clear();
        }
    }
}

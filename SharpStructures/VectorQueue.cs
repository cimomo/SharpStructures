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
    public class VectorQueue<T> : Queue<T>
    {
        private Vector<T> data;

        public VectorQueue()
        {
            this.data = new Vector<T>();
        }

        public override int Size
        {
            get { return this.data.Count; }
        }

        public override T Peek()
        {
            Assertion.Pre(this.Size != 0);
            return this.data.GetElementAt(0);
        }

        public override void Enqueue(T value)
        {
            this.data.AddElement(value);
        }

        public override T Dequeue()
        {
            Assertion.Pre(this.Size != 0);
            return this.data.RemoveElementAt(0);
        }

        public override void Clear()
        {
            this.data.Clear();
        }
    }
}

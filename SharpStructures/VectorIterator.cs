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
    public class VectorIterator<T> : Iterator<T>
    {
        private Vector<T> vector;
        private int current;

        public VectorIterator(Vector<T> vector)
        {
            this.vector = vector;
            Reset();
        }

        public override bool HasMore()
        {
            return this.current < this.vector.Count;
        }

        public override T GetValue()
        {
            return this.vector.GetElementAt(this.current);
        }

        public override T Next()
        {
            Assertion.Pre(HasMore());
            return this.vector.GetElementAt(this.current++);
        }

        public override void Reset()
        {
            this.current = 0;
        }
    }
}

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
    public class VectorHeap<T> : PriorityQueue<T> where T : IComparable
    {
        protected Vector<T> data;

        public override int Size
        {
            get
            {
                return this.data.Count;
            }
        }

        public VectorHeap()
        {
            Clear();
        }

        public override T Peek()
        {
            Assertion.Pre(!IsEmpty());

            return this.data.GetElementAt(0);
        }

        public override void Add(T value)
        {
            this.data.AddElement(value);
            PercolateUp(this.Size - 1);
        }

        public override T Remove()
        {
            Assertion.Pre(!IsEmpty());

            T value = Peek();

            this.data.SetElementAt(this.data.GetElementAt(this.Size-1), 0);
            this.data.RemoveElementAt(this.Size - 1);

            if (this.Size > 1)
            {
                PushDownRoot(0);
            }

            return value;
        }

        public override void Clear()
        {
            this.data = new Vector<T>();
        }

        protected int GetParentOf(int i)
        {
            return (i - 1) / 2;
        }

        protected int GetLeftChildOf(int i)
        {
            return i * 2 + 1;
        }

        protected int GetRightChildOf(int i)
        {
            return i * 2 + 2;
        }

        protected void PercolateUp(int leaf)
        {
            T value = this.data.GetElementAt(leaf);
            int parent = GetParentOf(leaf);

            while (leaf > 0 && value.CompareTo(data.GetElementAt(parent)) < 0)
            {
                data.SetElementAt(data.GetElementAt(parent), leaf);
                leaf = parent;
                parent = GetParentOf(leaf);
            }

            data.SetElementAt(value, leaf);
        }

        protected void PushDownRoot(int root)
        {
            int heapSize = this.Size;
            T value = this.data.GetElementAt(root);

            while (root < heapSize)
            {
                int child = GetLeftChildOf(root);

                if (child < heapSize)
                {
                    int right = GetRightChildOf(root);

                    if (right < heapSize &&
                        this.data.GetElementAt(right).CompareTo(this.data.GetElementAt(child)) < 0)
                    {
                        child = right;
                    }

                    if (this.data.GetElementAt(child).CompareTo(value) < 0)
                    {
                        this.data.SetElementAt(this.data.GetElementAt(child), root);
                        root = child;
                    }
                    else
                    {
                        this.data.SetElementAt(value, root);
                        return;
                    }
                }
                else
                {
                    this.data.SetElementAt(value, root);
                    return;
                }
            }
        }
    }
}

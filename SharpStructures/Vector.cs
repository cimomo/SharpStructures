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
    public class Vector<T>
    {
        protected T[] data;
        protected int count;
        protected int initialCapacity;

        public int Count
        {
            get { return this.count; }
        }

        public Vector() : this(10)
        {
        }

        public Vector(int n)
        {
            this.initialCapacity = n;
            Clear();
        }

        public void Clear()
        {
            this.data = new T[this.initialCapacity];
            this.count = 0;
        }

        public T GetElementAt(int index)
        {
            Assertion.Pre(index < this.count);

            return this.data[index];
        }

        public void SetElementAt(T value, int index)
        {
            Assertion.Pre(index < this.count);

            this.data[index] = value;
        }

        public void AddElement(T value)
        {
            EnsureCapacity(this.count + 1);
            this.data[this.count++] = value;
        }

        public bool RemoveElement(T value)
        {
            int i;
            for (i = 0; i < this.count; i ++)
            {
                if (this.data[i].Equals(value))
                {
                    break;
                }
            }

            if (i >= this.count)
            {
                return false;
            }

            this.count--;

            for (; i < this.count; i ++)
            {
                this.data[i] = this.data[i + 1];
            }

            return true;
        }

        public void InsertElementAt(T value, int index)
        {
            Assertion.Pre(index < this.count);

            EnsureCapacity(this.count + 1);

            for (int i = this.count; i > index; i--)
            {
                this.data[i] = this.data[i - 1];
            }

            this.data[index] = value;

            this.count++;
        }

        public T RemoveElementAt(int index)
        {
            Assertion.Pre(index < this.count);

            this.count--;

            T o = this.data[index];

            for (int i = index; i < this.count; i++)
            {
                this.data[i] = this.data[i + 1];
            }

            return o;
        }

        public Iterator<T> GetElements()
        {
            return new VectorIterator<T>(this);
        }

        protected void EnsureCapacity(int capacity)
        {
            int currentCapacity = data.Count();

            if (currentCapacity >= capacity)
            {
                return;
            }

            int newCapacity = currentCapacity;

            if (newCapacity == 0)
            {
                newCapacity = 1;
            }
            else
            {
                newCapacity *= 2;
            }

            T[] newData = new T[newCapacity];

            for (int i = 0; i < this.count; i ++)
            {
                newData[i] = this.data[i];
            }

            this.data = newData;
        }
    }
}

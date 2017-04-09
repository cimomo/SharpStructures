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
    public class DoublyLinkedListElement<T>
    {
        private T value;
        protected DoublyLinkedListElement<T> previous;
        protected DoublyLinkedListElement<T> next;

        public DoublyLinkedListElement(T value, DoublyLinkedListElement<T> previous, DoublyLinkedListElement<T> next)
        {
            this.value = value;
            this.previous = previous;

            if (previous != null)
            {
                previous.next = this;
            }

            this.next = next;

            if (next != null)
            {
                next.previous = this;
            }
        }

        public DoublyLinkedListElement(T value) : this(value, null, null)
        {
        }

        public DoublyLinkedListElement<T> GetPrevious()
        {
            return this.previous;
        }

        public void SetPrevious(DoublyLinkedListElement<T> previous)
        {
            this.previous = previous;

            if (previous != null)
            {
                previous.next = this;
            }
        }

        public DoublyLinkedListElement<T> GetNext()
        {
            return this.next;
        }

        public void SetNext(DoublyLinkedListElement<T> next)
        {
            this.next = next;

            if (next != null)
            {
                next.previous = this;
            }
        }

        public T GetValue()
        {
            return this.value;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }
    }
}

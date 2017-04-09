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
    public class SinglyLinkedListElement<T>
    {
        private T value;
        protected SinglyLinkedListElement<T> next;

        public SinglyLinkedListElement(T value, SinglyLinkedListElement<T> next)
        {
            this.value = value;
            this.next = next;
        }

        public SinglyLinkedListElement(T value) : this(value, null)
        {
        }

        public SinglyLinkedListElement<T> GetNext()
        {
            return this.next;
        }

        public void SetNext(SinglyLinkedListElement<T> next)
        {
            this.next = next;
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

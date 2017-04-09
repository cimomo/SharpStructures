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
    public class DoublyLinkedList<T> : List<T>
    {
        private DoublyLinkedListElement<T> head;
        private DoublyLinkedListElement<T> tail;

        public DoublyLinkedList()
        {
            Clear();
        }

        public override int Size
        {
            get 
            {
                DoublyLinkedListElement<T> finger = this.head;
                int size = 0;

                while (finger != null)
                {
                    size++;
                    finger = finger.GetNext();
                }

                return size;
            }
        }

        public override void Clear()
        {
            this.head = null;
            this.tail = null;
        }

        public override void AddToHead(T value)
        {
            this.head = new DoublyLinkedListElement<T>(value, null, this.head);

            if (this.tail == null)
            {
                this.tail = this.head;
            }
        }

        public override void AddToTail(T value)
        {
            this.tail = new DoublyLinkedListElement<T>(value, this.tail, null);

            if (this.head == null)
            {
                this.head = this.tail;
            }
        }

        public override T Peek()
        {
            Assertion.Pre(this.head != null);
            return this.head.GetValue();
        }

        public override T PeekTail()
        {
            Assertion.Pre(this.tail != null);
            return this.tail.GetValue();
        }

        public override T RemoveFromHead()
        {
            Assertion.Pre(this.head != null);

            DoublyLinkedListElement<T> oldHead = this.head;

            this.head = this.head.GetNext();

            if (this.head == null)
            {
                this.tail = null;
            }
            else
            {
                this.head.SetPrevious(null);
            }

            return oldHead.GetValue();
        }

        public override T RemoveFromTail()
        {
            Assertion.Pre(this.tail != null);

            DoublyLinkedListElement<T> oldTail = this.tail;

            this.tail = this.tail.GetPrevious();

            if (this.tail == null)
            {
                this.head = null;
            }
            else
            {
                this.tail.SetNext(null);
            }

            return oldTail.GetValue();
        }

        public override bool Contains(T value)
        {
            Assertion.Pre(value != null);

            DoublyLinkedListElement<T> finger = this.head;

            while (finger != null && !value.Equals(finger.GetValue()))
            {
                finger = finger.GetNext();
            }

            return (finger != null);
        }

        public override T Remove(T value)
        {
            Assertion.Pre(value != null);

            DoublyLinkedListElement<T> finger = this.head;

            while (finger != null && ! value.Equals(finger.GetValue()))
            {
                finger = finger.GetNext();
            }

            if (finger == null)
            {
                return default(T);
            }

            if (finger.GetPrevious() != null)
            {
                finger.GetPrevious().SetNext(finger.GetNext());
            }
            else
            {
                this.head = finger.GetNext();
            }

            if (finger.GetNext() != null)
            {
                finger.GetNext().SetPrevious(finger.GetPrevious());
            }
            else
            {
                this.tail = finger.GetPrevious();
            }

            return finger.GetValue();
        }
    }
}

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
    public class SinglyLinkedList<T> : List<T>
    {
        private SinglyLinkedListElement<T> head;
        private int count;

        public SinglyLinkedList()
        {
            Clear();
        }

        public override int Size
        {
            get 
            {
                return this.count;
            }
        }

        public override void Clear()
        {
            this.head = null;
            this.count = 0;
        }

        public override void AddToHead(T value)
        {
            this.head = new SinglyLinkedListElement<T>(value, this.head);
            this.count++;
        }

        public override void AddToTail(T value)
        {
            SinglyLinkedListElement<T> newTail = new SinglyLinkedListElement<T>(value);

            if (this.head == null)
            {
                this.head = newTail;
            }
            else
            {
                SinglyLinkedListElement<T> finger = this.head;

                while (finger.GetNext() != null)
                {
                    finger = finger.GetNext();
                }

                finger.SetNext(newTail);
            }
            this.count++;
        }

        public override T Peek()
        {
            Assertion.Pre(this.head != null);
            return this.head.GetValue();
        }

        public override T PeekTail()
        {
            Assertion.Pre(this.head != null);

            SinglyLinkedListElement<T> finger = this.head;

            while (finger.GetNext() != null)
            {
                finger = finger.GetNext();
            }

            return finger.GetValue();
        }

        public override T RemoveFromHead()
        {
            Assertion.Pre(this.head != null);

            SinglyLinkedListElement<T> oldHead = this.head;

            this.head = this.head.GetNext();

            this.count--;

            return oldHead.GetValue();
        }

        public override T RemoveFromTail()
        {
            Assertion.Pre(this.head != null);

            SinglyLinkedListElement<T> previous = null;
            SinglyLinkedListElement<T> finger = this.head;

            while (finger.GetNext() != null)
            {
                previous = finger;
                finger = finger.GetNext();
            }

            if (previous == null)
            {
                this.head = null;
            }
            else
            {
                previous.SetNext(finger.GetNext());
            }

            this.count--;

            return finger.GetValue();
        }

        public override bool Contains(T value)
        {
            Assertion.Pre(value != null);

            SinglyLinkedListElement<T> finger = this.head;

            while (finger != null && !value.Equals(finger.GetValue()))
            {
                finger = finger.GetNext();
            }

            return (finger != null);
        }

        public override T Remove(T value)
        {
            Assertion.Pre(value != null);

            SinglyLinkedListElement<T> finger = this.head;
            SinglyLinkedListElement<T> previous = null;

            while (finger != null && ! value.Equals(finger.GetValue()))
            {
                previous = finger;
                finger = finger.GetNext();
            }

            if (finger == null)
            {
                return default(T);
            }
            
            if (previous == null)
            {
                this.head = finger.GetNext();
            }
            else
            {
                previous.SetNext(finger.GetNext());
            }

            this.count--;

            return finger.GetValue();
        }
    }
}

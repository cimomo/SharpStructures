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
    public class CircularList<T> : List<T>
    {
        private SinglyLinkedListElement<T> tail;
        private int count;

        public CircularList()
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
            this.tail = null;
            this.count = 0;
        }

        public override void AddToHead(T value)
        {
            SinglyLinkedListElement<T> newHead = new SinglyLinkedListElement<T>(value);

            if (this.tail == null)
            {
                this.tail = newHead;
            }
            else
            {
                SinglyLinkedListElement<T> head = this.tail.GetNext();
                newHead.SetNext(head);
            }

            this.tail.SetNext(newHead);
            this.count++;
        }

        public override void AddToTail(T value)
        {
            AddToHead(value);
            this.tail = this.tail.GetNext();
        }

        public override T Peek()
        {
            Assertion.Pre(this.tail != null);
            return this.tail.GetNext().GetValue();
        }

        public override T PeekTail()
        {
            Assertion.Pre(this.tail != null);
            return this.tail.GetValue();
        }

        public override T RemoveFromHead()
        {
            Assertion.Pre(this.tail != null);

            SinglyLinkedListElement<T> head = this.tail.GetNext();

            if (this.tail == head)
            {
                this.tail = null;
            }
            else
            {
                this.tail.SetNext(head.GetNext());
            }

            this.count--;

            return head.GetValue();
        }

        public override T RemoveFromTail()
        {
            Assertion.Pre(this.tail != null);

            SinglyLinkedListElement<T> finger = this.tail;
            SinglyLinkedListElement<T> oldTail = this.tail;

            while (finger.GetNext() != this.tail)
            {
                finger = finger.GetNext();
            }

            if (finger == this.tail)
            {
                this.tail = null;
            }
            else
            {
                finger.SetNext(this.tail.GetNext());
                this.tail = finger;
            }

            this.count--;
            return oldTail.GetValue();
        }

        public override bool Contains(T value)
        {
            Assertion.Pre(value != null);

            SinglyLinkedListElement<T> finger = this.tail;

            if (finger == null)
            {
                return false;
            }

            do
            {
                if (value.Equals(finger.GetValue()))
                {
                    return true;
                }

                finger = finger.GetNext();
            } while (finger != this.tail);

            return false;
        }

        public override T Remove(T value)
        {
            Assertion.Pre(value != null);

            if (this.tail == null)
            {
                return default(T);
            }

            if (value.Equals(this.tail.GetValue()))
            {
                return RemoveFromTail();
            }

            SinglyLinkedListElement<T> finger = this.tail.GetNext();
            SinglyLinkedListElement<T> previous = null;

            while (finger != tail && ! value.Equals(finger.GetValue()))
            {
                previous = finger;
                finger = finger.GetNext();
            }

            if (finger == tail)
            {
                return default(T);
            }
            
            if (previous == null)
            {
                return RemoveFromHead();
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

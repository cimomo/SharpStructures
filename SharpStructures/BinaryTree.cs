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
    public class BinaryTree<T>
    {
        protected BinaryTreeNode<T> root;
        protected BinaryTreeNode<T> cursor;
        protected BinaryTreeNode<T> prior;
        protected int size;
        protected bool wentLeft;

        public BinaryTree()
        {
            Clear();
        }

        public void Clear()
        {
            this.root = this.cursor = this.prior = null;
            this.size = 0;
            this.wentLeft = false;
        }

        public void Reset()
        {
            this.cursor = this.root;
            this.prior = null;
        }

        public bool IsValid()
        {
            return this.cursor != null;
        }

        public T GetValue()
        {
            Assertion.Pre(IsValid());
            return this.cursor.GetValue();
        }

        public void SetValue(T value)
        {
            Assertion.Pre(IsValid());
            this.cursor.SetValue(value);
        }

        public bool HasParent()
        {
            return (this.cursor != null && this.cursor.GetParent() != null);
        }

        public bool HasLeft()
        {
            return (this.cursor != null && this.cursor.GetLeft() != null);
        }

        public bool HasRight()
        {
            return (this.cursor != null && this.cursor.GetRight() != null);
        }

        public bool IsLeft()
        {
            return (this.cursor != null && this.cursor.IsLeft());
        }

        public bool IsRight()
        {
            return (this.cursor != null && this.cursor.IsRight());
        }

        public void MoveUp()
        {
            Assertion.Pre(IsValid());
            Assertion.Pre(HasParent());
            this.prior = null;
            this.cursor = this.cursor.GetParent();
        }

        public void MoveLeft()
        {
            Assertion.Pre(IsValid());
            this.prior = this.cursor;
            this.cursor = this.cursor.GetLeft();
            this.wentLeft = true;
        }

        public void MoveRight()
        {
            Assertion.Pre(IsValid());
            this.prior = this.cursor;
            this.cursor = this.cursor.GetRight();
            this.wentLeft = false;
        }

        public void Insert(T value)
        {
            Assertion.Pre(!IsValid());
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);

            if (root == null)
            {
                Assertion.Assert(this.prior == null);
                this.root = this.cursor = node;
            }
            else
            {
                Assertion.Assert(this.prior != null);

                if (wentLeft)
                {
                    this.prior.SetLeft(this.cursor = node);
                }
                else
                {
                    this.prior.SetRight(this.cursor = node);
                }
            }
            this.size++;
        }

        public T Remove()
        {
            Assertion.Pre(IsValid());
            Assertion.Pre(!(HasLeft() || HasRight()));

            T value = GetValue();

            if (IsLeft())
            {
                MoveUp();
                this.cursor.SetLeft(null);
            }
            else if (IsRight())
            {
                MoveUp();
                this.cursor.SetRight(null);
            }
            else
            {
                this.root = this.cursor = this.prior = null;
            }

            this.size--;
            return value;
        }

        public int Size
        {
            get { return this.size; }
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public Iterator<T> GetPreorderElements()
        {
            return new BinaryTreePreorderInterator<T>(this.root);
        }

        public Iterator<T> GetInorderElements()
        {
            return new BinaryTreeInorderIterator<T>(this.root);
        }

        public Iterator<T> GetPostorderElements()
        {
            return new BinaryTreePostorderIterator<T>(this.root);
        }

        public Iterator<T> GetLevelorderElements()
        {
            return new BinaryTreeLevelorderIterator<T>(this.root);
        }
    }
}

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
    public class BinaryTreeNode<T>
    {
        protected T value;
        protected BinaryTreeNode<T> parent;
        protected BinaryTreeNode<T> left;
        protected BinaryTreeNode<T> right;

        public BinaryTreeNode(T value) : this(value, null, null)
        {
        }

        public BinaryTreeNode(T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.value = value;
            SetLeft(left);
            SetRight(right);
        }

        public BinaryTreeNode<T> GetParent()
        {
            return this.parent;
        }

        public BinaryTreeNode<T> GetLeft()
        {
            return this.left;
        }

        public BinaryTreeNode<T> GetRight()
        {
            return this.right;
        }

        public T GetValue()
        {
            return this.value;
        }

        protected void SetParent(BinaryTreeNode<T> newParent)
        {
            this.parent = newParent;
        }

        public void SetLeft(BinaryTreeNode<T> newLeft)
        {
            if (this.left != null)
            {
                this.left.SetParent(null);
            }

            this.left = newLeft;

            if (this.left != null)
            {
                this.left.SetParent(this);
            }
        }

        public void SetRight(BinaryTreeNode<T> newRight)
        {
            if (this.right != null)
            {
                this.right.SetParent(null);
            }

            this.right = newRight;

            if (this.right != null)
            {
                this.right.SetParent(this);
            }
        }

        public void SetValue(T newValue)
        {
            this.value = newValue;
        }

        public bool IsLeft()
        {
            return (this.parent != null && this.parent.GetLeft() == this);
        }

        public bool IsRight()
        {
            return (this.parent != null && this.parent.GetRight() == this);
        }
    }
}

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
    public class BinaryTreePreorderInterator<T> : Iterator<T>
    {
        protected BinaryTreeNode<T> root;
        protected Stack<BinaryTreeNode<T>> todo;

        public BinaryTreePreorderInterator(BinaryTreeNode<T> root)
        {
            this.root = root;
            this.todo = new ListStack<BinaryTreeNode<T>>();
            Reset();
        }

        public override bool HasMore()
        {
            return !this.todo.IsEmpty();
        }

        public override T GetValue()
        {
            return this.todo.Peek().GetValue();
        }

        public override T Next()
        {
            Assertion.Pre(HasMore());

            BinaryTreeNode<T> node = this.todo.Pop();

            if (node.GetRight() != null)
            {
                this.todo.Push(node.GetRight());
            }

            if (node.GetLeft() != null)
            {
                this.todo.Push(node.GetLeft());
            }

            return node.GetValue();
        }

        public override void Reset()
        {
            this.todo.Clear();

            if (this.root != null)
            {
                this.todo.Push(this.root);
            }
        }
    }
}

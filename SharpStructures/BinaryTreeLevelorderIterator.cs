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
    public class BinaryTreeLevelorderIterator<T> : Iterator<T>
    {
        protected BinaryTreeNode<T> root;
        protected Queue<BinaryTreeNode<T>> todo;

        public BinaryTreeLevelorderIterator(BinaryTreeNode<T> root)
        {
            this.root = root;
            this.todo = new ListQueue<BinaryTreeNode<T>>();
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

            BinaryTreeNode<T> node = this.todo.Dequeue();

            if (node.GetLeft() != null)
            {
                this.todo.Enqueue(node.GetLeft());
            }
            if (node.GetRight() != null)
            {
                this.todo.Enqueue(node.GetRight());
            }

            return node.GetValue();
        }

        public override void Reset()
        {
            this.todo.Clear();
            this.todo.Enqueue(this.root);
        }
    }
}

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
    public class BinaryTreePostorderIterator<T> : Iterator<T>
    {
        protected BinaryTreeNode<T> root;
        protected Stack<BinaryTreeNode<T>> todo;

        public BinaryTreePostorderIterator(BinaryTreeNode<T> root)
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
            T value = node.GetValue();

            if (!this.todo.IsEmpty())
            {
                BinaryTreeNode<T> parent = this.todo.Peek();

                if (node == parent.GetLeft())
                {
                    node = parent.GetRight();

                    while (node != null)
                    {
                        this.todo.Push(node);

                        if (node.GetLeft() != null)
                        {
                            node = node.GetLeft();
                        }
                        else
                        {
                            node = node.GetRight();
                        }
                    }
                }
            }

            return value;
        }

        public override void Reset()
        {
            this.todo.Clear();

            BinaryTreeNode<T> node = this.root;

            while (node != null)
            {
                this.todo.Push(node);

                if (node.GetLeft() != null)
                {
                    node = node.GetLeft();
                }
                else
                {
                    node = node.GetRight();
                }
            }
        }
    }
}

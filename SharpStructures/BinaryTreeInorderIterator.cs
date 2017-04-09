﻿/*
 * Copyright (C) Kai Chen
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpStructures
{
    public class BinaryTreeInorderIterator<T> : Iterator<T>
    {
        protected BinaryTreeNode<T> root;
        protected Stack<BinaryTreeNode<T>> todo;

        public BinaryTreeInorderIterator(BinaryTreeNode<T> root)
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

            node = node.GetRight();

            while (node != null)
            {
                this.todo.Push(node);
                node = node.GetLeft();
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
                node = node.GetLeft();
            }
        }
    }
}

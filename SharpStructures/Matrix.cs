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
    public class Matrix<T> 
    {
        protected Vector<Vector<T>> rows;

        public int Width
        {
            get 
            {
                return this.rows.Count == 0 ? 0 : (this.rows.GetElementAt(0)).Count;
            }
        }

        public int Height
        {
            get
            {
                return this.rows.Count;
            }
        }

        public Matrix(int width, int height)
        {
            this.rows = new Vector<Vector<T>>(height);

            for (int i = 0; i < height; i++)
            {
                Vector<T> row = new Vector<T>(width);
                this.rows.AddElement(row);

                for (int j = 0; j < width; j++)
                {
                    row.AddElement(default(T));
                }
            }
        }

        public T GetElementAt(int r, int c)
        {
            Assertion.Pre(r < this.Height);
            Assertion.Pre(c < this.Width);

            Vector<T> row = this.rows.GetElementAt(r);

            return row.GetElementAt(c);
        }

        public void SetElementAt(T value, int r, int c)
        {
            Assertion.Pre(r < this.Height);
            Assertion.Pre(c < this.Width);

            Vector<T> row = this.rows.GetElementAt(r);

            row.SetElementAt(value, c);
        }

        public void InsertRowAt(int r)
        {
            Assertion.Pre(r < this.Height);

            Vector<T> row = new Vector<T>(this.Width);

            for (int i = 0; i < this.Width; i++)
            {
                row.AddElement(default(T));
            }

            this.rows.InsertElementAt(row, r);
        }

        public void InsertColumnAt(int c)
        {
            Assertion.Pre(c < this.Width);

            for (int i = 0; i < this.Height; i++)
            {
                Vector<T> row = this.rows.GetElementAt(i);
                row.InsertElementAt(default(T), c);
            }
        }

        public Vector<T> RemoveRowAt(int r)
        {
            Assertion.Pre(r < this.Height);

            Vector<T> row = this.rows.RemoveElementAt(r);

            return row;
        }

        public Vector<T> RemoveColumnAt(int c)
        {
            Assertion.Pre(c < this.Width);

            Vector<T> column = new Vector<T>();

            for (int i = 0; i < this.Height; i++)
            {
                Vector<T> row = this.rows.GetElementAt(i);
                column.AddElement(row.RemoveElementAt(c));
            }

            return column;
        }
    }
}

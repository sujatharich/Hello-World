// -----------------------------------------------------------------------
//  <copyright file="IteratorPattern.cs" company="Microsoft Corporation">
//      Copyright (C) Microsoft Corporation. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace Patterns.Behavioral
{
    using System.Collections;
    using System.Collections.Generic;

    public class IteratorPattern : IEnumerable<int>, IEnumerator<int>
    {
        private const int Size = 10;
        private readonly int[] elements = new int[IteratorPattern.Size];
        private int track;

        public IteratorPattern()
        {
            this.Reverse = false; // Default is not reverse
            for (int i = 0; i < IteratorPattern.Size; i++)
            {
                this.elements[i] = i;
            }
        }

        public bool Reverse { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            this.Reset();
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool MoveNext()
        {
            if (this.Reverse)
            {
                this.track--;
                if (this.track < 0)
                {
                    return false;
                }
                return true;
            }
            else
            {
                this.track++;
                if (this.track >= IteratorPattern.Size)
                {
                    return false;
                }
                return true;
            }
        }

        public void Reset()
        {
            if (this.Reverse)
            {
                this.track = IteratorPattern.Size;
            }
            else
            {
                this.track = -1;
            }
        }

        public int Current
        {
            get { return this.elements[this.track]; }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public void Dispose()
        {
        }
    }
}

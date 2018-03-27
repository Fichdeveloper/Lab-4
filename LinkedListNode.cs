using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_proj_C
{
    class LinkedListNode<R>: IComparable<R> where R :IComparable<R>
    {
        public LinkedListNode(R value)
        {
            this.Value = value;
        }

        public R Value { get; internal set; }

        public LinkedListNode<R> Next{get;internal set;}
        public LinkedListNode<R> Previous{get;internal set; }

        public int CompareTo(R other)
        {
            return Value.CompareTo(other);
        }


    }
}
 


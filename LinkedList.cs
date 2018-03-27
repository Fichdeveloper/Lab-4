using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_proj_C
{
    class LinkedList<T> : System.Collections.Generic.IEnumerable<T> where T:IComparable<T>
    {
        public LinkedListNode<T> head;
        public LinkedListNode<T> tail;
        
        public int Count
        {
            get; private set;
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(value);

            if (Count == 0)
            {
                head = node;
            }
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            Count++;
        }


        public void ShowList(LinkedList<T> list)
        {
            foreach (T i in list)
            {
                Console.Write(i + " <-> ");     
            }
        }


        public LinkedListNode<T> Find_Before_Node(T before_node)
        {
            LinkedListNode<T> copy_before = new LinkedListNode<T>(before_node);
            
            while (head != null)
            {
                T value = head.Value;

                if (value.CompareTo(copy_before.Value) == 0)
                {
                    return head;                                     
                }
                head = head.Next;
            }
            return null;
        }

        public void Insert(T before_node,T node)
        {
            LinkedListNode<T> copy_node = new LinkedListNode<T>(node);
            LinkedListNode<T> prev_value=null;
            LinkedListNode<T> copy_head = head;
            
            LinkedListNode<T> before_value = Find_Before_Node(before_node);

            head = copy_head;
            
            while (head != null)
            {
                T value = head.Value;

                if (value.CompareTo(copy_node.Value) == 0)
                {
                    prev_value.Next = null;
                    head.Previous = null;

                    if (head.Next!=null)
                    {
                        prev_value.Next = head.Next;
                        head.Next.Previous = prev_value;

                    }

                    if (before_value.Previous == null)
                    {
                        LinkedListNode<T> temp = copy_head;
                        copy_head = head;
                        copy_head.Next = temp;                     
                    }
                    else
                    {
                        before_value.Previous.Next = head;
                        head.Previous = before_value.Previous;
                        head.Next = before_value;
                    }
                }
                prev_value = head;
                head = head.Next;                
            }
            head = copy_head;
        }

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
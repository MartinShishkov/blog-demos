using System;

namespace _206.Reverse_Linked_List
{
    public class ListNode<T>
    {
        public ListNode(T val, ListNode<T> next = null)
        {
            this.Value = val;
            this.Next = next;
        }

        public T Value { get; }

        public ListNode<T> Next { get; set; }

        public void Insert(T value)
        {
            if (this.Next == null)
            {
                this.Next = new ListNode<T>(value);
            }
            else
            {
                this.Next.Insert(value);
            }
        }

        public void Print()
        {
            var p = this;
            while (p != null)
            {
                Console.WriteLine(p.Value);
                p = p.Next;
            }
        }
    }
}

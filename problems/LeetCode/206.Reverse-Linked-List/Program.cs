using System;

namespace _206.Reverse_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] {1, 2, 3, 4, 5};

            var list = ListFromArray(input);
            list.Print();

            var r = Reverse(list);
            Console.WriteLine(r.Value);
        }

        static ListNode<int> ListFromArray(int[] array)
        {
            var head = new ListNode<int>(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                head.Insert(array[i]);
            }

            return head;
        }

        static ListNode<int> Reverse(ListNode<int> head)
        {
            ListNode<int> prev = null;
            ListNode<int> current = head;
            ListNode<int> next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            return prev;
        }
    }
}

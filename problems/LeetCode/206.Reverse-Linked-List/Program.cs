namespace _206.Reverse_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new[] {1, 2, 3, 4, 5};

            var list = ListFromArray(input);
            //list.Print();

            var r = Reverse(list);
            r.Print();
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

        static ListNode<int> ReverseIterative(ListNode<int> head)
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

        // recursive
        static ListNode<int> Reverse(ListNode<int> head)
        {
            // we should be asking the code to reverse a smaller
            // and smaller list until there's only 1 element left
            // and the reversed version of that is itself

            if (head == null || head.Next == null)
                return head;

            var reversed = Reverse(head.Next);
            head.Next.Next = head;
            head.Next = null;

            return reversed;
        }
    }
}

using System;

namespace LinkedList
{
    public class Test
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            var first = list.AddLast(5);
            var node = list.AddLast(2);
            var last = list.AddLast(3);

            //list.RemoveFirst();
            //list.RemoveFirst();
            list.Clear();
            //list.AddAfter(node, 5555);
            //list.AddAfter(last, 666);
            //list.AddAfter(first, 33);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            //Console.WriteLine(list.Contains(2));
        }
    }
}
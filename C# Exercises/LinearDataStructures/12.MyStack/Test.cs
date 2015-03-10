using System;

class Test
{
    static void Main(string[] args)
    {
        MyStack<int> stack = new MyStack<int>();
        stack.Push(4);
        stack.Push(5);
        stack.Push(6);

        Console.WriteLine(stack.Peek());
        Console.WriteLine(stack.Count);

        //int[] arr = stack.ToArray();
        //Console.WriteLine(String.Join(",", arr));
        //stack.Clear();
        //var value = stack.Pop();
        //Console.WriteLine(value);
        //value = stack.Pop();
        //Console.WriteLine(value);
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}
using System;

class Test
{
    static void Main(string[] args)
    {
        MyQueue<int> queu = new MyQueue<int>(4);
        queu.Enqueue(18);
        queu.Enqueue(12);
        queu.Enqueue(321);
        queu.Enqueue(2);

        queu.Dequeue();
        int[] arr = queu.ToArray();
        Console.WriteLine(String.Join(",", arr));
        //Console.WriteLine(queu.Contains(2));
        //queu.Clear();
        // var value = queu.Dequeue();
        // value = queu.Dequeue();
        // Console.WriteLine(value);

        //Console.WriteLine(queu.Count);
        //foreach (var item in queu)
        //{
        //    Console.WriteLine(item);
        //}
    }
}
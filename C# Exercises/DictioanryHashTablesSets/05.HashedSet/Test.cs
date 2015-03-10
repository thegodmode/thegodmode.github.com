using System;
using System.Linq;

class Test
{
    static void Main(string[] args)
    {
        HashedSet<int> set = new HashedSet<int>(2);
        HashedSet<int> set1 = new HashedSet<int>(5);
        set.Add(3);
        set.Add(4);
        set.Add(5);
        set.Add(6);
        set.Add(7);

        set1.Add(5);
        set1.Add(7);
        set1.Add(13);
        set1.Add(43);
        set1.Add(123);

        var intersect = set.Intersect(set1);
        foreach (var item in intersect)
        {
            Console.WriteLine(item);
        }



        //Console.WriteLine("Count:{0}", set.Count);
        
        //set.Remove(5);

        //set.Add(15);
        //Console.WriteLine("Find:{0}", set.Find(3));
        //Console.WriteLine("Items");
        //foreach (var item in set)
        //{
        //    Console.WriteLine(item);
        //}
        //Console.WriteLine("Count:{0}", set.Count);

        //set.Clear();
        //Console.WriteLine("Count:{0}", set.Count);
        //foreach (var item in set)
        //{
        //    Console.WriteLine(item);
        //}


    }
}
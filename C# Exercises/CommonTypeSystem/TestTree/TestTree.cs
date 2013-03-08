using System;
using BinarySearchTrees;

namespace TestTree
{
    class TestTree
    {
        static void Main(string[] args)
        {
            BinarySearchTree<double> tree = new BinarySearchTree<double>(5.5);
            tree.AddChild(10.3);
            tree.AddChild(4.7);
            tree.AddChild(20.4);
            tree.AddChild(141.6);
            Console.WriteLine(tree);
          //  Console.WriteLine(tree.Find(5.5));

            tree.RemoveChild(141.6);
            Console.WriteLine(tree);
        }
    }
}
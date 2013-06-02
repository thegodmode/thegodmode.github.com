using System;
using System.Collections.Generic;
using System.Linq;

namespace TreesAndTraversal
{
    class TreeTraverse
    {
        static void Main(string[] args)
        {
            Dictionary<TreeNode<int>, List<TreeNode<int>>> dic = new Dictionary<TreeNode<int>, List<TreeNode<int>>>();

            ReadUserInput(dic);

            // find root
            var root = FindRoot(dic);
            Console.WriteLine("The Root is {0}", root.Value);

            // find leaves
            var leafNodes = FindLeaveNodes(dic);
            Console.Write("The leaves are: ");
            foreach (var item in leafNodes)
            {
                Console.Write(item.Value + " ");
            }

            // find middleNodes
            Console.WriteLine();
            var middleNodes = FindMiddleNodes(dic);
            Console.Write("The middleNodes are: ");
            foreach (var item in middleNodes)
            {
                Console.Write(item.Value + " ");
            }

            // generateTree
            Tree<int> tree = GenerateTree(dic);

            // findLongestPath
            Console.WriteLine();
            int pathLength = FindLongestPath(tree);
            Console.WriteLine("The longest path is: {0}", pathLength);

            // findAllPathWithGivenSum S
            int sum = 6;
            var paths = FindAllPathWithGivenSum(tree, sum);
            Console.WriteLine("All paths which sum is: {0} are:", sum);
            foreach (var path in paths)
            {
                Console.WriteLine("Path: {0}", string.Join(",", path));
            }
        }

        private static List<List<int>> FindAllPathWithGivenSum(Tree<int> tree, int sum)
        {
            List<List<int>> resultPaths = new List<List<int>>();
            var root = tree.Root;
            Queue<Tuple<TreeNode<int>, List<int>>> que = new Queue<Tuple<TreeNode<int>, List<int>>>();
            var tuple = new Tuple<TreeNode<int>, List<int>>(root, new List<int>());
            que.Enqueue(tuple);

            while (que.Count != 0)
            {
                var currentTuple = que.Dequeue();
                var parent = currentTuple.Item1;
                var path = currentTuple.Item2;
                path.Add(parent.Value);

                if (path.Sum() == sum)
                {
                    resultPaths.Add(path);
                }

                if (parent.HasChild())
                {
                    var children = parent.GetChildren();
                    foreach (var child in children)
                    {
                        var newTuple = new Tuple<TreeNode<int>, List<int>>(child, new List<int>(path));
                        que.Enqueue(newTuple);
                    }

                    if (path.Count != 1)
                    {
                        var tuplet = new Tuple<TreeNode<int>, List<int>>(parent, new List<int>());
                        que.Enqueue(tuplet);
                    }
                }
            }

            return resultPaths;
        }

        private static int FindLongestPath(Tree<int> tree)
        {
            int pathLength = 0;
            var root = tree.Root;
            Queue<Tuple<TreeNode<int>, int>> que = new Queue<Tuple<TreeNode<int>, int>>();
            var tuple = new Tuple<TreeNode<int>, int>(root, pathLength);
            que.Enqueue(tuple);

            while (que.Count != 0)
            {
                var currentTuple = que.Dequeue();
                var currentPathLength = currentTuple.Item2;
                var parent = currentTuple.Item1;

                if (currentPathLength > pathLength)
                {
                    pathLength = currentPathLength;
                }

                if (parent.HasChild())
                {
                    var children = parent.GetChildren();
                    foreach (var child in children)
                    {
                        var newTuple = new Tuple<TreeNode<int>, int>(child, currentPathLength + 1);
                        que.Enqueue(newTuple);
                    }
                }
            }

            return pathLength;
        }

        private static Tree<int> GenerateTree(Dictionary<TreeNode<int>, List<TreeNode<int>>> dic)
        {
            if (dic == null)
            {
                throw new ArgumentException("dic", "Dictionary can't be null");
            }

            Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();
            var root = FindRoot(dic);
            Tree<int> newTree = new Tree<int>(root);
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var parent = queue.Dequeue();
               
                if (dic.ContainsKey(parent))
                {
                    var children = dic[parent];
                    foreach (var item in children)
                    {
                        parent.AddChild(item);
                        queue.Enqueue(item);
                    }
                }
            }

            return newTree;
        }

        private static List<TreeNode<int>> FindMiddleNodes(Dictionary<TreeNode<int>, List<TreeNode<int>>> dic)
        {
            if (dic == null)
            {
                throw new ArgumentException("dic", "Dictionary can't be null");
            }

            var parents = dic.Keys.ToList();
            var root = FindRoot(dic);
            parents.Remove(root);
            return parents;
        }

        private static List<TreeNode<int>> FindLeaveNodes(Dictionary<TreeNode<int>, List<TreeNode<int>>> dic)
        {
            if (dic == null)
            {
                throw new ArgumentException("dic", "Dictionary can't be null");
            }
            var parents = dic.Keys;
            var children = dic.Values.SelectMany(x => x).ToList();

            var leaves = children.Except(parents);
            return leaves.ToList();
        }

        private static TreeNode<int> FindRoot(Dictionary<TreeNode<int>, List<TreeNode<int>>> dic)
        {
            if (dic == null)
            {
                throw new ArgumentException("dic", "Dictionary can't be null");
            }

            var parents = dic.Keys;
            var children = dic.Values.SelectMany(x => x).ToList();

            foreach (var parent in parents)
            {
                if (!children.Contains(parent))
                {
                    return parent;
                }
            }

            throw new InvalidOperationException("There is no root");
        }
      
        private static void ReadUserInput(Dictionary<TreeNode<int>, List<TreeNode<int>>> dic)
        {
            if (dic == null)
            {
                throw new ArgumentException("dic", "Dictionary can't be null");
            }

            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N - 1; i++)
            {
                var args = Console.ReadLine();
                var argsToArray = args.Split(' ');
                var parent = new TreeNode<int>(int.Parse(argsToArray[0]));
                var child = new TreeNode<int>(int.Parse(argsToArray[1]));

                if (!dic.ContainsKey(parent))
                {
                    dic.Add(parent, new List<TreeNode<int>>()
                    {
                        child
                    });
                }
                else
                {
                    dic[parent].Add(child);
                }
            }
        }
    }
}
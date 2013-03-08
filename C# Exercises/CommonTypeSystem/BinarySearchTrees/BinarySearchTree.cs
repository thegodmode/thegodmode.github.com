using System;
using System.Linq;

namespace BinarySearchTrees
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private TreeNode<T> root;

        public BinarySearchTree(T value)
        {
            root = new TreeNode<T>(value);
        }
     
        public void AddChild(T value)
        {
            var currentNode = root;
            var newNode = new TreeNode<T>(value);

            while (true)
            {
                if (newNode < currentNode)
                {
                    if (ReferenceEquals(currentNode.LeftChild, null))
                    {
                        currentNode.LeftChild = newNode;
                        break;
                    }

                    currentNode = currentNode.LeftChild;
                    continue;
                }

                if (newNode > currentNode)
                {
                    if (ReferenceEquals(currentNode.RightChild, null))
                    {
                        currentNode.RightChild = newNode;
                        break;
                    }

                    currentNode = currentNode.RightChild;
                    continue;
                }
            }
        }

        public bool Find(T value)
        {
            var currentNode = root;
            var newNode = new TreeNode<T>(value);
            if (ReferenceEquals(currentNode, null))
            {
                return false;
            }
            while (true)
            {
                if (newNode < currentNode)
                {
                    if (!ReferenceEquals(currentNode.LeftChild, null))
                    {
                        if (currentNode.LeftChild == newNode)
                        {
                            return true;
                        }
                        currentNode = currentNode.LeftChild;
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

                if (newNode > currentNode)
                {
                    if (!ReferenceEquals(currentNode.RightChild, null))
                    {
                        if (currentNode.RightChild == newNode)
                        {
                            return true;
                        }
                        currentNode = currentNode.RightChild;
                        continue;
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public void RemoveChild(T value)
        {
            var currentNode =  root;
            var newNode = new TreeNode<T>(value);
            if (value == null)
            {
                throw new ArgumentException("Value must be different then null!");
            }
            while (true)
            {
                if (currentNode == newNode)
                {
                    if (currentNode.LeftChild == null && currentNode.RightChild == null)
                    {
                        currentNode = null;
                        return;
                    }

                    if (currentNode.LeftChild != null && currentNode.RightChild != null)
                    {
                        currentNode.Value = FindLeftNullChild(currentNode.RightChild);
                        return;
                    }

                    if (currentNode.LeftChild != null)
                    {
                        currentNode = currentNode.LeftChild;
                        return;
                    }

                    if (currentNode.RightChild != null)
                    {
                        currentNode = currentNode.RightChild;
                        return;
                    }
                }

                if (newNode < currentNode)
                {
                    currentNode = currentNode.LeftChild;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }
            }
        }

        private T FindLeftNullChild(TreeNode<T> treeNode)
        {
            if (treeNode.LeftChild == null)
            {
                T val = treeNode.Value;
                treeNode = null;
                return val;
            }

            return FindLeftNullChild(treeNode.LeftChild);
        }

        public override string ToString()
        {
            return string.Format("{0}", root);
        }
    }
}
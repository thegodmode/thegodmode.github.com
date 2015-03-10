using System;
using System.Linq;

namespace TreesAndTraversal
{
    public class Tree<T>
    {
        private TreeNode<T> root;
        
        public Tree(TreeNode<T> root)
        {
            this.Root = root;
        }

        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
            set
            {
                this.root = value;
            }
        }
    }
}
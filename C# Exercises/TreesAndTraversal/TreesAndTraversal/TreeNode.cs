using System;
using System.Collections.Generic;
using System.Linq;

namespace TreesAndTraversal
{
    public class TreeNode<T>
    {
        private T value;
        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }

        public TreeNode()
        {
            this.Value = value;
            this.Children = new List<TreeNode<T>>();
        }

        private List<TreeNode<T>> Children
        {
            get
            {
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + this.value.GetHashCode();
                return result;
            }
        }

        public bool Equals(TreeNode<T> value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }
            return Equals(this.value, value.value);
        }

        public override bool Equals(object obj)
        {
            TreeNode<T> temp = obj as TreeNode<T>;
            if (temp == null)
            {
                return false;
            }
            return this.Equals(temp);
        }

        public void AddChild(TreeNode<T> child)
        {
            this.Children.Add(child);
        }

        public bool HasChild()
        {
            if (this.Children.Count != 0)
            {
                return true;
            }
            return false;
        }

        public List<TreeNode<T>> GetChildren()
        {
            return this.Children;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            private set
            {
                this.value = value;
            }
        }
    }
}
using System;
using System.Text;

namespace BinarySearchTrees
{
    internal class TreeNode<T> : IEquatable<TreeNode<T>> where T : IComparable
    {
        private T value;
        private TreeNode<T> leftChild;
        private TreeNode<T> rightChild;

        public TreeNode(T value)
        {
            this.value = value;
        }

        public TreeNode<T> LeftChild
        {
            get
            {
                return leftChild;
            }
            set
            {
                leftChild = value;
            }
        }

        public TreeNode<T> RightChild
        {
            get
            {
                return rightChild;
            }
            set
            {
                rightChild = value;
            }
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + value.GetHashCode();
                result = result * 23 + leftChild.GetHashCode();
                result = result * 23 + rightChild.GetHashCode();
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
            return Equals(value.Value, this.Value);
        }

        public override bool Equals(object obj)
        {
            TreeNode<T> temp = obj as TreeNode<T>;
            if (temp == null) return false;
            return Equals(temp);
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public static bool operator ==(TreeNode<T> left, TreeNode<T> right)
        {
            return Object.Equals(left, right);
        }

        public static bool operator !=(TreeNode<T> left, TreeNode<T> right)
        {
            return !Object.Equals(left, right);
        }

        public static bool operator <(TreeNode<T> left, TreeNode<T> right)
        {
            if (left.Value.CompareTo(right.Value) < 0)
            {
                return true;
            }

            return false;
        }

        public static bool operator >(TreeNode<T> left, TreeNode<T> right)
        {
            if (left.Value.CompareTo(right.Value) > 0)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("[" + this.Value + " ");

            // Leaf node
            if (this.LeftChild != null)
            {
                str.Append("Left: " + this.LeftChild.ToString());
            }

            if (this.RightChild != null)
            {
                str.Append("Right: " + this.RightChild.ToString());
            }

            str.Append("] ");

            return str.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task10__6_
{
    public class BinaryTreeNode<T> : IComparable<T>
        where T : IComparable
    {
        public BinaryTreeNode(T value)
        {
            Value = value;
        }
        
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public T Value { get; private set; }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private Node rootNode = null;
        public void Insert(T value)
        {
            if (rootNode == null)
                rootNode = new Node(value);

            bool IsLeft = value.CompareTo(rootNode.Value) <= 0;

            if(IsLeft)
            {

            }
        }


        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }
            public T Value;
            public Node<T> Left;
            public Node<T> Right;
        }
    }
}

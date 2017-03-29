using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions
{

    class RedBlackBST<T> where T : IComparable
    {
        public class Node
        {
            public Node(T value, Node previous)
            {
                Value = value;
                IsBlack = false;
                Parent = previous;
            }

            public Node(Node node, Node parent)
            {
                this.Value = node.Value;
                this.Right = node.Right;
                this.Left = node.Left;
                this.Parent = parent;
            }

            public void Set(Node other)
            {
                this.Value = other.Value;
                this.Right = other.Right;
                this.Left = other.Left;
                this.IsBlack = other.IsBlack;
                //this.parent should remain the same
            }
            public T Value;
            public Node Left;
            public Node Right;
            public Node Parent;
            public bool IsBlack;
            public Node OtherChild(Node child) => Left == child ? Right : Left;
            public bool IsRed => !IsBlack;
            public Node Uncle => Parent?.Parent?.OtherChild(Parent);
            public Node GrantParent => Parent?.Parent;
        }

        int blackHeight = 0;
        Node RootNode = null;

        public void Insert(T value)
        {
            Insert(ref RootNode, null, value);
        }

        private void Insert(ref Node current, Node previous, T value, int blackCount = 0)
        {
            if (current == null)
            {
                current = new Node(value, previous); // new Red Node
                Rebalance(current);
            }
            else if (value.CompareTo(current.Value) <= 0)
                Insert(ref current.Left, current, value);
            else
                Insert(ref current.Right, current, value);
        }

        public void Rebalance(Node newNode)
        {
            if (newNode.Parent != null && newNode.Parent.IsBlack)
            {
                return;
            }
            if(newNode.Parent == null)
            {
                newNode.IsBlack = true;
                return;
            }

            if(newNode.Uncle.IsRed)
            {
                newNode.Uncle.IsBlack = true;
                newNode.Parent.IsBlack = true;
                newNode.GrantParent.IsBlack = false;
                Rebalance(newNode.GrantParent);
            }
            else
            {
                // We need to rotate
                newNode.Parent.IsBlack = true;
                newNode.GrantParent.IsBlack = false;
                Rotate(newNode.Parent);
            }
        }

        public void Rotate(Node node)
        {
            if(node.Parent == null)
            {
                return;
            }

            Node tempNewNode = new Node(node.Parent, node);
            if (node.Parent.Left == node)
            {
                // left logic
                tempNewNode.Left = node.Right;
                node.Right = tempNewNode;
            }
            else
            {
                // right logic
                tempNewNode.Right = node.Left;
                node.Left = tempNewNode;
            }
        }

        public void Delete(T value)
        {
            Delete(ref RootNode, value);
        }

        private void Delete(ref Node current, T value)
        {
            if (current == null)
                return;
            else if (value.CompareTo(current.Value) == 0)
            {
                //DeleteNode(ref current); // deletes and rebalances
                Delete(ref current, value);
            }
            else if (value.CompareTo(current.Value) < 0)
                Delete(ref current.Left, value);
            else
                Delete(ref current.Right, value);
        }
    }
}

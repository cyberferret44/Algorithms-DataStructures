using FUNdamentals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions.BinarySearchTree
{
    public class BinarySearchTree<T> where T : IComparable
    {
        private Node RootNode = null;

        public void Insert(T value)
        {
            Insert(ref RootNode, value);
        }

        private void Insert(ref Node current, T value)
        {
            if (current == null)
                current = new Node(value);
            else if (value.CompareTo(current.Value) <= 0)
                Insert(ref current.Left, value);
            else
                Insert(ref current.Right, value);
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
                DeleteNode(ref current); // deletes and rebalances
                Delete(ref current, value);
            }
            else if (value.CompareTo(current.Value) < 0)
                Delete(ref current.Left, value);
            else
                Delete(ref current.Right, value);
        }

        private void DeleteNode(ref Node node)
        {
            if (node.Left == null && node.Right == null)
                node = null;
            else if (node.Left == null)
                node = node.Right;
            else if (node.Right == null)
                node = node.Left;
            else
            {
                Node previousNode = node;
                var currentNode = node.Left;
                while (currentNode.Right != null)
                {
                    Node temp = currentNode;
                    currentNode = currentNode.Right;
                    previousNode = temp;
                }
                if(previousNode == node)
                    node = node.Left;
                else
                {
                    previousNode.Right = currentNode.Left;
                    currentNode.Left = node.Left;
                    currentNode.Right = node.Right;
                    node = currentNode;
                }
            }
        }

        public List<T> GetInOrderTraversal()
        {
            return GetInOrderTraversal(RootNode, new List<T>());
        }

        private List<T> GetInOrderTraversal(Node current, List<T> result)
        {
            if (current != null)
            {
                GetInOrderTraversal(current.Left, result);
                result.Add(current.Value);
                GetInOrderTraversal(current.Right, result);
            }
            return result;
        }

        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }
            public T Value;
            public Node Left;
            public Node Right;
        }
    }
}

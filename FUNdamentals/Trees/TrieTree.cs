using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals.Trees
{
    class TrieTree
    {
        private Node RootNode;

        public TrieTree()
        {
            RootNode = new Node(' ');
        }

        private class Node
        {
            public Node(char c)
            {
                key = c;
            }
            public char key;
            public List<Node> children; // Could use a HashSet here, but the overhead is probably not worth it
        }

        public void Insert(string value)
        {
            Node currentNode = RootNode;
            foreach(char c in value)
            {
                Node matchingNode = currentNode.children.FirstOrDefault(x => x.key == c);
                if (matchingNode != null)
                {
                    currentNode = matchingNode;
                }
                else
                {
                    Node newChild = new Node(c);
                    currentNode.children.Add(newChild);
                    currentNode = newChild;
                }
            }
        }

        public bool Contains(string value)
        {
            Node currentNode = RootNode;
            foreach (char c in value)
            {
                Node matchingNode = currentNode.children.FirstOrDefault(x => x.key == c);
                if (matchingNode != null)
                {
                    currentNode = matchingNode;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeQuestions
{
    public class Node<T> where T : IComparable
    {
        public T value;
        public Node<T> Left;
        public Node<T> Right;
        bool IsBlack;
    }

    class RedBlackBST<T> where T : IComparable
    {
        public void Insert(T value)
        {

        }
    }
}

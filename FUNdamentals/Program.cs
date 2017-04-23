using FUNdamentals.Concurrency;
using FUNdamentals.Graphs;
using FUNdamentals.InterviewQuestions;
using FUNdamentals.NP_Complete;
using FUNdamentals.SortingAlgorithms;
using PracticeQuestions.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNdamentals
{
    class Program
    {
        public static void Main()
        {
            List<string> map = new List<string>
            {
                "      S      ",
                "             ",
                "  █      █   ",
                "  █      █   ",
                "  ████████   ",
                "             ",
                "        F    "
            };
            Grid grid = new Grid(map);
        }
    }
}

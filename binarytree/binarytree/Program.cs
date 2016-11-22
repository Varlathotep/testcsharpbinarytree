using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        public static void Main(string[] args)
        {
            Node test = new Node(0);
            for (int i = 1, count = (int)(Math.Pow(2, 12)) - 1; i < count; i++)
            {
                Node.Insert(ref test, i);
            }
            long totalWeight = Node.GetTotalWeight(test);
            Node largestSubtree = Node.FindLargestSubtree(test);
            int hits = Node.hits;
        }
    }
}

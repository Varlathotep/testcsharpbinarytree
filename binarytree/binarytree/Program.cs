using System;

namespace BinaryTree
{
    class Program
    {
        public static void Main(string[] args)
        {
            Node testBinaryTree = new Node(0);
            for (int i = 1, count = (int)(Math.Pow(2, 12)) - 1; i < count; i++)
            {
                Node.RandomInsert(ref testBinaryTree, i);
            }
            long totalWeight = Node.GetTotalWeight(testBinaryTree);
            Node largestSubtree = Node.FindLargestSubtree(testBinaryTree);
            Node foundNode = Node.Find(testBinaryTree, 16);
        }
    }
}

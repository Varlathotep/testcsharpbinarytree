using System;

namespace BinaryTree
{
    /// <summary>
    /// A (simple?) binary tree implementation in C#.
    /// </summary>
    public class Node
    {
        public int weight;
        long size;
        public Node left;
        public Node right;
        public static Random rnd = new Random();

        /// <summary>
        /// Creates the node using the initial weight value passed to it.
        /// </summary>
        /// <param name="weight">The weight of the node. This used during the calculation of the weight of any given subtree.</param>
        public Node(int weight)
        {
            this.weight = weight;
            size = 1;
            left = null;
            right = null;
        }

        /// <summary>
        /// Inserts the node containing the weight.
        /// </summary>
        /// <param name="node">The node to be inserted into.</param>
        /// <param name="weight">The weight of the node being inserted.</param>
        /// <returns></returns>
        public static void Insert(ref Node node, int weight)
        {
            if (node == null)
            {
                node = new Node(weight);
            }
            else if (node.weight > weight)
            {
                Insert(ref node.left, weight);
            }
            else
            {
                Insert(ref node.right, weight);
            }
            FixSize(node);
        }

        /// <summary>
        /// Inserts the node containing the weight.
        /// </summary>
        /// <param name="node">The node to be inserted into.</param>
        /// <param name="weight">The weight of the node being inserted.</param>
        /// <returns></returns>
        public static void RandomInsert(ref Node node, int weight)
        {
            if (node == null)
            {
                node = new Node(weight);
            }
            else if (rnd.Next() % (node.size + 1) == 0)
            {
                InsertRoot(ref node, weight);
            }
            else if (node.weight > weight)
            {
                RandomInsert(ref node.left, weight);
            }
            else
            {
                RandomInsert(ref node.right, weight);
            }
            FixSize(node);
        }

        /// <summary>
        /// Inserts the new root tree and rotates the tree around the given point based off of the weight of the node.
        /// </summary>
        /// <param name="node">The node to be inserted into.</param>
        /// <param name="weight">The weight of the new node.</param>
        /// <returns>The newly rotated node.</returns>
        public static void InsertRoot(ref Node node, int weight)
        {
            if (node == null)
            {
                node = new Node(weight);
            }
            else if (weight < node.weight)
            {
                InsertRoot(ref node.left, weight);
                RotateRight(ref node);
            }
            else
            {
                InsertRoot(ref node.right, weight);
                RotateLeft(ref node);
            }
        }

        /// <summary>
        /// Rotates the tree right around the node passed.
        /// </summary>
        /// <param name="node">The subtree to be rotated.</param>
        /// <returns>The newly rotated subtree.</returns>
        public static void RotateRight(ref Node node)
        {
            Node left = node.left;
            if (left is Node)
            {
                node.left = left.right;
                left.right = node;
                FixSize(node);
                FixSize(left);
                node = left;
            }
            else
            {
                node = null;
            }
        }

        /// <summary>
        /// Rotates the tree left around the node passed.
        /// </summary>
        /// <param name="node">The subtree to be rotated.</param>
        /// <returns>The newly rotated subtree.</returns>
        public static void RotateLeft(ref Node node)
        {
            Node right = node.right;
            if (right is Node)
            {
                node.right = right.left;
                right.left = node;
                FixSize(node);
                FixSize(right);
                node = right;
            }
            else
            {
                node = null;
            }
        }

        /// <summary>
        /// Sets the size of the node.
        /// </summary>
        /// <param name="size">The size property.</param>
        public static void SetSize(ref Node node, long size)
        {
            node.size = size;
        }

        /// <summary>
        /// Returns the provided node's size, or 0 if the node is null.
        /// </summary>
        /// <param name="node">The node having its size checked.</param>
        /// <returns>The size of the node.</returns>
        public static long GetSize(ref Node node)
        {
            long size = 0;
            if (node is Node)
            {
                size = node.size;
            }
            return size;
        }

        /// <summary>
        /// (Should) corrects the size of the binary tree.
        /// </summary>
        /// <param name="node">The node having its size corrected.</param>
        public static void FixSize(Node node)
        {
            long newSize = 1 + GetSize(ref node.left) + GetSize(ref node.right);
            Node.SetSize(ref node, newSize);
        }

        /// <summary>
        /// Finds the largest subtree by getting the total weight of both the left and right branches and then comparing the total weight of both branches against each other.
        /// </summary>
        /// <param name="node">The node to be searched.</param>
        /// <returns>The node containing the largest subtree.</returns>
        public static Node FindLargestSubtree(Node node)
        {
            Node returnedNode = null;
            if (node is Node)
            {
                long leftTotalWeight = GetTotalWeight(node.left);
                long rightTotalWeight = GetTotalWeight(node.right);
                if (leftTotalWeight > rightTotalWeight)
                {
                    returnedNode = node.left;
                }
                else
                {
                    returnedNode = node.right;
                }
            }
            return returnedNode;
        }

        /// <summary>
        /// Finds the node containing the weight.
        /// </summary>
        /// <param name="node">The node to be searched.</param>
        /// <param name="weight">The weight to be searched by.</param>
        /// <returns>The node that has been found containing the given weight or null if no node is found.</returns>
        public static Node Find(Node node, int weight)
        {
            Node searchNode = null;
            if (node is Node)
            {
                if (node.weight == weight)
                {
                    searchNode = node;
                }
                else if (node.weight > weight)
                {
                    searchNode = Find(node.left, weight);
                }
                else
                {
                    searchNode = Find(node.right, weight);
                }
            }
            return searchNode;
        }

        /// <summary>
        /// Recursively calculates the total weight of the subtree starting at the provided node.
        /// </summary>
        /// <param name="node">The starting node of the calculation.</param>
        /// <returns>The total calculated weight.</returns>
        public static long GetTotalWeight(Node node)
        {
            long weight = 0;
            if (node is Node)
            {
                weight = node.weight;
                if (node.left is Node)
                {
                    weight += GetTotalWeight(node.left);
                }
                if (node.right is Node)
                {
                    weight += GetTotalWeight(node.right);
                }
            }
            return weight;
        }
    }
}

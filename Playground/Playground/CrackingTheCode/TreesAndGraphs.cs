using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using DataStructuresPlayground.Domains.BinaryTree;

namespace Playground.CrackingTheCode
{
    /// <summary>
    /// Chapter 4 - Interview Questions: Trees and Graphs
    /// </summary>
    public class TreesAndGraphs
    {
        /**
	    Given a sorted (increasing order) array with unique integer elements, write an algorithm to create a binary search tree with minimal height

	    Let’s suppose the following sorted increasing array: 
	    [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

	    A binary search tree with minimal height is a tree containing all leaf nodes in the same level.
	    In order to be a binary search tree, the tree must contain the smallest elements on the left, the highest elements to the right and the root node is the smallest one. It should be a complete and balanced binary tree.

        */
        
        public class BinaryTreeNode
        {
            // Fields and Properties
            public int Value { get; set; }
            public BinaryTreeNode? Left { get; set; }
            public BinaryTreeNode? Right { get; set; }
            public int Size { get; set; }

            // Methods
            public BinaryTreeNode(int value)
            {
                Value = value;
                Size = 1;
            }

            /// <summary>
            /// Inserts a node in order.
            /// </summary>
            /// <param name="newValue"></param>
            public void InsertInOrder(int newValue)
            {
                if (newValue < Value)
                {
                    if (Left == null)
                        Left = new BinaryTreeNode(newValue);
                    else
                        Left.InsertInOrder(newValue);
                }
                else
                {
                    if (Right == null)
                        Right = new BinaryTreeNode(newValue);
                    else
                        Right.InsertInOrder(newValue);
                }

                Size++;
            }

            /// <summary>
            /// Gets a random node with equal probability for each node
            /// Only works for complete binary search trees
            /// </summary>
            /// <returns></returns>
            public BinaryTreeNode GetRandomNode()
            {
                int leftSize = Left == null ? 0 : Left.Size;
                Random rand = new Random();

                int index = rand.Next(Size);

                if (index < Size && Left != null)
                    return Left.GetRandomNode();
                
                if (index == leftSize)
                    return this;
                
                return Right == null ? this : Right.GetRandomNode();
            }
        }

        /// <summary>
        /// Receives an ordered int array and populates a binary search tree
        /// Time complexity: O(N), where N is the array count
        /// </summary>
        /// <param name="orderedArray"></param>
        /// <param name="treeHeight"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /*public LinkedList<BinaryTreeNode> BSTMinHeight(int[] orderedArray)
        {
            var minHeightTree = new LinkedList<BinaryTreeNode>();

            if (orderedArray.Length.Equals(0))
                throw new Exception("orderedArray is empty.");

            var currentNode = new BinaryTreeNode(orderedArray[0]);
            var currentValue = orderedArray[0];
            minHeightTree.AddFirst(currentNode);

            if (orderedArray.Length.Equals(1))
                return minHeightTree;

            // Given that the array is increasingly ordered
            for (int i = 1; i < orderedArray.Length; i++)
            {
                var nodeToAppend = new BinaryTreeNode(orderedArray[i]);

                if (orderedArray[i] <= currentNode.Value)
                {
                    // node must go to the left
                    if (currentNode.Left == null)
                        currentNode.Left = nodeToAppend;
                    else
                    {
                        currentNode = currentNode.Left;
                    }
                        
                }
                else // otherwise, go to the right since it is greater
                {
                    // node must go to the left
                    if (currentNode.Right == null)
                        currentNode.Right = nodeToAppend;
                    else
                    {
                        currentNode = currentNode.Right;
                    }
                }
                    
                if (currentNode.Left != null && currentNode.Right != null)
                {
                    // Adds the node to the minHeightTree. Only adds a node if both left and right are filled.
                    minHeightTree.AddFirst(nodeToAppend);

                    // Updates the reference to the current node and value
                    currentNode = nodeToAppend;
                }
            }

            return minHeightTree;
        }*/

        public LinkedList<BinaryTreeNode?> BSTMinHeight(int[] orderedArray)
        {
            var list = new LinkedList<BinaryTreeNode?>();
            list.AddFirst(BSTMinNode(orderedArray, 0, orderedArray.Length - 1));

            return list;
        }

        /// <summary>
        /// Recursively creates a BST min height node.
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public BinaryTreeNode? BSTMinNode(int[] numbers, int start, int end)
        {
            if (end < start)
                return null;

            int mid = (start + end) / 2;
            BinaryTreeNode? node = new BinaryTreeNode(numbers[mid]);
            node.Left = BSTMinNode(numbers, start, mid - 1);
            node.Right = BSTMinNode(numbers, mid + 1, end);

            return node;
        }

        /// <summary>
        /// Gets the height of a BST tree
        /// </summary>
        public int GetBSTHeight(BinaryTreeNode? treeNode)
        {
            if (treeNode == null) return 0;

            int leftHeight = GetBSTHeight(treeNode.Left);
            int rightHeight = GetBSTHeight(treeNode.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public List<LinkedList<BinaryTreeNode?>> ListOfDepths(BinaryTreeNode? root)
        {
            List<LinkedList<BinaryTreeNode?>> depthsList = new List<LinkedList<BinaryTreeNode?>>();
            CreateLevelLinkedList(root, depthsList, 0);
            return depthsList;
        }

        /// <summary>
        /// Exercise 4.3 - List of Depths - Depth-first search
        /// </summary>
        /// <param name="root"></param>
        /// <param name="dephtsList"></param>
        /// <param name="level"></param>
        public void CreateLevelLinkedList(BinaryTreeNode? root, List<LinkedList<BinaryTreeNode?>> dephtsList, int level)
        {
            if (root == null) return;

            LinkedList<BinaryTreeNode?> list = null;

            if (dephtsList.Count == level)
            {
                // Levels are always traversed in order. So, if this is the first time we've
                // visited level i, we must have seen levels 0 through i -1.
                // We can therefore safely add the level at the end.
                list = new LinkedList<BinaryTreeNode?>();
                dephtsList.Add(list);
            }
            else
            {
                list = dephtsList[level];
            }

            var nodeToAdd = new LinkedListNode<BinaryTreeNode?>(root);
            list.AddFirst(nodeToAdd);
            CreateLevelLinkedList(root.Left, dephtsList, level + 1);
            CreateLevelLinkedList(root.Right, dephtsList, level + 1);
        }

        /// <summary>
        /// Exercise 4.3 - List of Depths - Breadth-first search
        /// </summary>
        public List<LinkedList<BinaryTreeNode?>> ListOfDepthsBFS(BinaryTreeNode? root)
        {
            List<LinkedList<BinaryTreeNode?>> dephtsList = new List<LinkedList<BinaryTreeNode?>>();
            
            // Visit the root
            LinkedList<BinaryTreeNode?> current = new LinkedList<BinaryTreeNode?>();

            if (root != null)
            {
                current.AddFirst(root);
            }

            while (current.Count > 0)
            {
                dephtsList.Add(current); // add the previous level
                LinkedList<BinaryTreeNode?> parents = current; // Go to next level
                current = new LinkedList<BinaryTreeNode?>();

                foreach (var parent in parents)
                {
                    // Visit the children
                    if (parent.Left != null)
                        current.AddFirst(parent.Left);

                    if (parent.Right != null)
                        current.AddFirst(parent.Right);
                }
            }

            return dephtsList;
        }

        /// <summary>
        /// Exercise 4.4
        /// Time Complexity: O(n)
        /// In order to check if tree is balanced or not, we need to check both left and right nodes subtrees and see if the difference in heights is greater than 1.
        /// Traverse the nodes using a breadth-first search algorithm, so we can pass through all sub nodes first
        /// For each subnode, we will get the height of the tree, considering the subnode as the root.
        /// if Math.Abs(left height - right height) is more than 1, then tree is unbalanced.
        /// otherwise, tree is balanced
        /// Write a method to find the height of a tree given a root node.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsTreeBalanced(BinaryTreeNode? root)
        {
            // Traverse the tree and check both left and right nodes.
            Queue<BinaryTreeNode?> treeNodes = new Queue<BinaryTreeNode?>();
            treeNodes.Enqueue(root);

            while (treeNodes.Count > 0)
            {
                BinaryTreeNode? currentNode = treeNodes.Dequeue();
                int leftHeight = 0;
                int rightHeight = 0;

                if (currentNode.Left != null)
                {
                    leftHeight = GetTreeHeight(currentNode.Left);
                    treeNodes.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    rightHeight = GetTreeHeight(currentNode.Right);
                    treeNodes.Enqueue(currentNode.Right);
                }

                if (Math.Abs(leftHeight - rightHeight) > 1)
                    return false;
            }

            return true;
        }

        public int GetTreeHeight(BinaryTreeNode? treeNode)
        {
            if (treeNode == null)
            {
                return -1;
            }

            int leftHeight = GetTreeHeight(treeNode.Left);
            int rightHeight = GetTreeHeight(treeNode.Right);

            if (leftHeight > rightHeight)
                return leftHeight + 1;
            else
                return rightHeight + 1;
        }

        /// <summary>
        /// Exercise 4.5 - Trees and Graphs
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBinarySearchTree(BinaryTreeNode? root)
        {
            if (root == null) return true;

            if (
                (root.Left != null && root.Value.CompareTo(root.Left.Value) < 0) ||
                (root.Right != null && root.Value.CompareTo(root.Right.Value) > 0) ||
                ((root.Left != null && root.Right != null) && root.Left.Value.CompareTo(root.Right.Value) > 0)
            )
                return false;
            
            return IsBinarySearchTree(root.Left) && IsBinarySearchTree(root.Right);
        }

        public bool CheckBST(BinaryTreeNode? root)
        {
            return CheckBST(root, null, null);
        }

        public bool CheckBST(BinaryTreeNode? root, int? min, int? max)
        {
            if (root == null) return true;

            if ((min != null && root.Value <= min) || (max != null && root.Value > max))
                return false;

            if (!CheckBST(root.Left, min, root.Value) || !CheckBST(root.Right, root.Value, max))
                return false;

            return true;
        }

        /// <summary>
        /// Exercise 4.6
        /// Find the successor node
        /// Time Complexity: O(log N) to traverse the nodes
        /// Space Complexity: O(N) as I created a list with all nodes and levels
        /// </summary>
        /// <remarks>
        ///     **** My understanding of this problem was not correct. So, my implementation works but it is different.
        /// </remarks>
        /// <param name="root"></param>
        /// <param name="node"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public int? NextSuccessorNode(BinaryTreeNode? root, BinaryTreeNode? node)
        {
            List<KeyValuePair<int, int>> nodesByLevel = new List<KeyValuePair<int, int>>();

            // Root starts at level 1
            MapNodesLevel(root, nodesByLevel, 1);

            // Select the node  and get the next level
            return GetNextSuccessor(nodesByLevel, node.Value);
        }

        public void MapNodesLevel(BinaryTreeNode? root, List<KeyValuePair<int, int>> nodesByLevel, int level)
        {
            // means I reached the end
            if (root == null)
                return;

            // Add the node and the value to the list
            nodesByLevel.Add(new KeyValuePair<int, int>(level, root.Value));

            // Store the next level
            MapNodesLevel(root.Left, nodesByLevel, level + 1);
            MapNodesLevel(root.Right, nodesByLevel, level + 1);
        }

        public int? GetNextSuccessor(List<KeyValuePair<int, int>> nodesByLevel, int target)
        {
            var currentNodeList = nodesByLevel.Where(_ => _.Value.Equals(target)).OrderBy(_ => _.Value);
            
            if (!currentNodeList.Any()) 
                return null;

            var nextNode = nodesByLevel.Where(_ => _.Key.Equals(currentNodeList.First().Key + 1));

            return nextNode.Any() ? nextNode.First().Value : null;
        }

        /// <summary>
        /// Exercise 4.8
        /// Find Common Ancestor
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public BinaryTreeNode? CommonAncestor(BinaryTreeNode? root, BinaryTreeNode? p, BinaryTreeNode? q)
        {
            // Error check: one node is not in the tree.
            if (!Covers(root, p) || !Covers(root, q))
                return null;

            return AncestorHelper(root, p, q);
        }

        public BinaryTreeNode? AncestorHelper(BinaryTreeNode? root, BinaryTreeNode? p, BinaryTreeNode? q)
        {
            if (root == null || root == p || root == q)
                return root;

            bool pIsOnLeft = Covers(root.Left, p);
            bool qIsOnLeft = Covers(root.Left, q);

            // p and q are on different sides. Root is the ancestor.
            if (pIsOnLeft != qIsOnLeft)
                return root;
                
            BinaryTreeNode? childSide = pIsOnLeft ? root.Left : root.Right;

            return AncestorHelper(childSide, p, q);
        }

        public bool Covers(BinaryTreeNode? root, BinaryTreeNode? node)
        {
            if (root == null) return false;
            if (root == node) return true;

            return Covers(root.Left, node) || Covers(root.Right, node);
        }

        /// <summary>
        /// Exercise 4.10
        /// Checks if T2 is a subtree of T1
        /// </summary>
        /// <remarks>
        ///     Strategy:
        ///     - Get both roots of each binary tree
        ///     - Traverse t1 searching the t2 root node. For that, we can use Breadth First Search, so we can traverse all the nodes.
        ///     - If the node is found, then we perform a Breadth First Search on this t1 node.
        ///     - We can perform a BFS at the same time in T2, and when we dequeue the node to find the solution, we compare each node
        ///     - If we reach the end of T2 queue, that means all items are equal and T2 is a subtree of T1. Otherwise, we return false and continue with DFS.
        ///     - In order to keep track of visited nodes on BFS, we can use separated hash maps.
        ///
        ///     Time Complexity:
        ///     - We would have O(n) time complexity for the first traversal using BFS, and O(t) for the second traversal using T2.
        ///     - The final time complexity would be O(n*t), where n is the number of nodes from T1 and t is the number of nodes for T2.
        ///
        ///     Questions:
        ///     - What if we would have a binary search tree instead of a tree?
        ///         - Then the search would be faster
        /// </remarks>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public bool CheckSubtree(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            // Base case
            if (t1 == null || t2 == null) return false;

            bool isSubtree = false;

            // Perform Depth First search on T1 for the root node of T2
            Queue<BinaryTreeNode> qT1 = new Queue<BinaryTreeNode>();
            Dictionary<BinaryTreeNode, bool> visitedT1 = new Dictionary<BinaryTreeNode, bool>();

            qT1.Enqueue(t1);

            while (qT1.Count > 0)
            {
                var currentT1Node = qT1.Dequeue();

                if (currentT1Node == null)
                    continue;

                // Node found, let's compare both trees
                if (visitedT1.ContainsKey(currentT1Node)) 
                    continue;

                // first comparison will avoid searching the tree for different items
                if (currentT1Node.Value.Equals(t2.Value) && CompareTrees(currentT1Node, t2))
                {
                    isSubtree = true;
                    break;
                }

                qT1.Enqueue(currentT1Node.Left);
                qT1.Enqueue(currentT1Node.Right);

                visitedT1.Add(currentT1Node, true);
            }

            return isSubtree;
        }

        /// <summary>
        /// Compare both trees.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns>If they are equal, return true. False otherwise.</returns>
        private bool CompareTrees(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            Dictionary<BinaryTreeNode, bool> visitedNodes = new Dictionary<BinaryTreeNode, bool>();
            Queue<BinaryTreeNode> qT1 = new Queue<BinaryTreeNode>();
            Queue<BinaryTreeNode> qT2 = new Queue<BinaryTreeNode>();

            // those will be dequeued and enqueued at the same time.
            qT1.Enqueue(t1);
            qT2.Enqueue(t2);

            while (qT2.Count > 0)
            {
                var currentT1Node = qT1.Dequeue();
                var currentT2Node = qT2.Dequeue();

                // Visiting the node
                if (currentT1Node != null && currentT2Node != null && currentT1Node.Value.Equals(currentT2Node.Value))
                {
                    if (!visitedNodes.ContainsKey(currentT2Node))
                    {
                        qT1.Enqueue(currentT1Node.Left);
                        qT1.Enqueue(currentT1Node.Right);
                        qT2.Enqueue(currentT2Node.Left);
                        qT2.Enqueue(currentT2Node.Right);

                        // As T1 is only mirrored, then I just need one queue to track visited items.
                        visitedNodes.Add(currentT2Node, true);
                    }
                }
                else
                {
                    // if both values are null, then continue. Tree is supposed to be equal.
                    if (currentT1Node == null && currentT2Node == null)
                        continue;

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Exercise 4.10
        /// Checks if t2 is a subtree of t1
        /// Uses a recursive approach
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public bool CheckSubTreeRecursive(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            // t2 null is always a subtree of t1
            if (t2 == null) 
                return true;

            return SubTree(t1, t2);
        }

        private bool SubTree(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            // If bigger tree is null, t2 is still not found
            if (t1 == null)
                return false;

            if (t1.Value == t2.Value && MatchTree(t1, t2))
                return true;

            return SubTree(t1.Left, t2) || SubTree(t1.Right, t2);
        }

        private bool MatchTree(BinaryTreeNode t1, BinaryTreeNode t2)
        {
            if (t1 == null && t2 == null)
                return true; // nothing left in the subtree

            if (t1 == null || t2 == null)
                return false; // one of the trees is empty, so they don't match

            if (!t1.Value.Equals(t2.Value))
                return false;

            return MatchTree(t1.Left, t2.Left) && MatchTree(t1.Right, t2.Right);
        }

        /// <summary>
        /// Exercise 4.11
        /// Get a random node given a binary tree.
        /// </summary>
        /// <remarks>
        ///     Strategy:
        ///     - Approach 1:
        ///         - As all nodes should be equally likely to be chosen, we might need the amount of nodes to get a random order.
        ///         - Assuming that we don't have the number of nodes, we need to calculate them first.
        ///         - Traverse through the tree once just to get the number of nodes.
        ///         - Use the random class to get a random number between 1 and the number of nodes
        ///         - Traverse the tree again using the same algorithm
        ///         - Return the node defined by the random sequence number taken.
        ///     - Approach 2:
        ///         - We can traverse the tree just once and, for each visit, decide if the node will be taken or not.
        ///         - We can use the value of each node and check if it is divisible by a random number between 1 and 5, for example
        ///         - if yes, we return that node
        ///
        /// Hints: #42, #54, #62, #75, #89, #99, #112, #119
        /// </remarks>
        /// <param name="root"></param>
        /// <returns></returns>
        public BinaryTreeNode GetRandomNode(BinaryTreeNode root)
        {
            // tree is null, no need to get any node.
            if (root == null)
                return null;

            // Set a seed between 1 and 10
            Random randNumber = new Random();
            int seed = randNumber.Next(1, 10);
            
            // Traverse through the tree using a pre-order traversal
            if (ShouldGetNode(root, seed))
                return root;

            var randLeftNode = GetRandomNode(root.Left);
            var randRightNode = GetRandomNode(root.Right);

            if (randLeftNode != null)
                return randLeftNode;
            
            return randRightNode;
        }

        private bool ShouldGetNode(BinaryTreeNode node, int seed)
        {
            if (node.Value % seed == 0)
                return true;

            return false;
        }

        /// <summary>
        /// Calculates the percentage for each node in the binary tree for GetRandomNode method.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="samplesCount"></param>
        /// <returns></returns>
        public Dictionary<int, float> GetRandomNodeStatistic(BinaryTreeNode root, float samplesCount)
        {
            var statistics = new Dictionary<int, float>();
            var treeValuesCount = new Dictionary<int, int>();

            if (samplesCount <= 0)
                samplesCount = 1;

            for (int i = 0; i < samplesCount; i++)
            {
                BinaryTreeNode randNode = GetRandomNode(root);

                if (randNode == null)
                {
                    i--;
                    continue;
                }
                
                if (treeValuesCount.ContainsKey(randNode.Value))
                    treeValuesCount[randNode.Value]++;
                else
                    treeValuesCount.Add(randNode.Value, 1);
            }

            foreach (KeyValuePair<int, int> treeValue in treeValuesCount)
            {
                float percentage = (treeValue.Value / samplesCount);
                statistics.Add(treeValue.Key, percentage * 100);
            }

            return statistics;
        }

        /// <summary>
        /// Calculates the percentage for each node in the binary tree for GetRandomNode method.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="samplesCount"></param>
        /// <returns></returns>
        public Dictionary<int, float> GetBalancedRandomNodeStatistic(BinaryTreeNode root, float samplesCount)
        {
            var statistics = new Dictionary<int, float>();
            var treeValuesCount = new Dictionary<int, int>();

            if (samplesCount <= 0)
                samplesCount = 1;

            for (int i = 0; i < samplesCount; i++)
            {
                BinaryTreeNode randNode = root.GetRandomNode();

                if (randNode == null)
                {
                    i--;
                    continue;
                }

                if (treeValuesCount.ContainsKey(randNode.Value))
                    treeValuesCount[randNode.Value]++;
                else
                    treeValuesCount.Add(randNode.Value, 1);
            }

            foreach (KeyValuePair<int, int> treeValue in treeValuesCount)
            {
                float percentage = (treeValue.Value / samplesCount);
                statistics.Add(treeValue.Key, percentage * 100);
            }

            return statistics;
        }

        /// <summary>
        ///     Paths with Sum: You are given a binary tree in which each node contains an integer value
        ///     (which might be positive or negative). Design an algorithm to count the number of paths that sum to a given value.
        ///     The path does not need to start or end at the root or a leaf, but it must go downwards (traveling only from parent nodes to child nodes).
        ///     Hints:#6, #14, #52, #68, #77, #87, #94, #103, #108, #115
        /// </summary>
        /// <remarks>
        ///     Consider an example:
        ///     Binary tree:
        ///
        ///              5
        ///         4         6
        ///      2     3   6     8
        ///
        ///     Let's say the given value is 12.
        ///     To reach this sum, we can use the following paths:
        ///         5, 4, 3
        ///         6, 6
        ///     So, the answer would be 2.
        ///
        ///     Strategy:
        ///         - Since it goes only downwards, we can start the sum with the root node.
        ///         - For each child node of root, we can use BFS to traverse widely and check using DFS on each
        ///         - In order to check if a node will be linked to items that will give a sum, we can traverse the tree using DFS
        ///         - For each node, we try to build a path to the sum.
        ///             - While the sum is smaller than the target value, keep adding the values
        ///             - If the sum of the values in a given path is greater, than that path is not the one we want
        ///             - If the sum is exactly the same, then the path is a valid one. Increment the totalPaths then.
        ///
        ///     Time Complexity:
        ///     - first BFS will be O(n) where n is the number of nodes
        ///     - second DFS will be O(m) where m is the number of the nodes in a path
        ///     - final time complexity will be something like O(n*m)
        ///     - Space complexity would be something like O(n) (queue and hashset for the BFS) and O(1) for DFS. Overall space complexity is O(n);
        /// </remarks>
        public int PathsWithSums(BinaryTreeNode root, int targetSum)
        {
            int totalPaths = 0;
            Queue<BinaryTreeNode> queueNodes = new Queue<BinaryTreeNode>();
            HashSet<BinaryTreeNode> visitedNodes = new HashSet<BinaryTreeNode>();
            
            queueNodes.Enqueue(root);

            while (queueNodes.Count > 0)
            {
                var currentNode = queueNodes.Dequeue();

                if (visitedNodes.Contains(currentNode) || currentNode == null)
                    continue;
                
                totalPaths += GetPaths(currentNode, targetSum, 0, 0);
                queueNodes.Enqueue(currentNode.Left);
                queueNodes.Enqueue(currentNode.Right);
                visitedNodes.Add(currentNode);
            }
            
            return totalPaths;
        }

        public int GetPaths(BinaryTreeNode node, int targetSum, int currentSum, int paths)
        {
            if (node == null) // reached the end
            {
                if (targetSum.Equals(currentSum))
                    return paths++; //it is a valid path
                
                return 0;
            }
                
            if (node.Value + currentSum < targetSum)
            {
                currentSum += node.Value;
                paths = GetPaths(node.Left, targetSum, currentSum, paths) + GetPaths(node.Right, targetSum, currentSum, paths);
            }
            else if ((node.Value + currentSum) > targetSum)
            {
                return 0;
            }
            else
            {
                paths++; // valid path is found, since the sum has reached the targetSum
            }

            return paths;
        }

        /// <summary>
        /// Exercise 4.9
        /// Print all sequences of a binary search tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        //public List<LinkedList<int>> AllSequences(BinaryTreeNode root)
        //{
        //    List<LinkedList<int>> result = new List<LinkedList<int>>();

        //    if (root == null)
        //    {
        //        result.Add(new LinkedList<int>());
        //        return result;
        //    }

        //    LinkedList<int> prefix = new LinkedList<int>();
        //    prefix.AddFirst(root.Value);

        //    // Recurse on left and right subtrees
        //    List<LinkedList<int>> leftSequence = AllSequences(root.Left);
        //    List<LinkedList<int>> rightSequence = AllSequences(root.Right);

        //    // Weave together each list from the left and right sides
        //    foreach (var left in leftSequence)
        //    {
        //        foreach (var right in rightSequence)
        //        {
        //            var weaved = new List<LinkedList<int>>();
        //            WeaveLists(left, right, weaved, prefix);
        //            result.Add(weaved);
        //        }
        //    }

        //    return result;
        //}

        //// Weave lists together in all possible ways. 
        //public void WeaveLists(LinkedList<int> first, LinkedList<int> second, List<LinkedList<int>> results,
        //    LinkedList<int> prefix)
        //{

        //    // One list is empty. Add a remainder to [a cloned]  prefix and store the result.
        //    if (first.Count == 0 || second.Count == 0
        //    {
        //        LinkedList<int> result = prefix;
        //        result.Append(first);

        //    })
        //}
    }
}

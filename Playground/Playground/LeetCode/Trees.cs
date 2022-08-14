using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Playground.LeetCode
{
    //Definition for a binary tree node.
    public class TreeNode
    {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
         {
             this.val = val;
             this.left = left;
             this.right = right;
         }
    }

    public class Trees
    {
        public static int MaxDepth(TreeNode root)
        {
            /* RECURSIVE SOLUTION BY GEEKS FOR GEEKS
             
            if (node == null)
                return 0;
            else
            {
                //compute the depth of each subtree 
                int lDepth = MaxDepth(node.left);
                int rDepth = MaxDepth(node.right);

                //use the larger one
                if (lDepth > rDepth)
                    return (lDepth + 1);
                else
                    return (rDepth + 1);
            }*/

            /** MY SOLUTION (DOES NOT WORK FOR ALL CASES)
            int depthLeft = 1;
            int depthRight = 1;

            // If root is null, there is no depth.
            if (root == null)
                return 0;

            Queue<TreeNode> qLeft = new Queue<TreeNode>();
            Queue<TreeNode> qRight = new Queue<TreeNode>();

            qLeft.Enqueue(root.left);
            qRight.Enqueue(root.right);
            

            while (qLeft.Count > 0 || qRight.Count > 0)
            {
                bool depthIncrementNeeded = false;

                if (qLeft.Count > 0)
                {
                    var currentLeft = qLeft.Dequeue();

                    if (currentLeft != null)
                    {
                        depthLeft++;
                        qLeft.Enqueue(currentLeft.left);
                        qRight.Enqueue(currentLeft.right);
                    }
                }

                if (qRight.Count > 0)
                {
                    var currentRight = qRight.Dequeue();

                    if (currentRight != null)
                    {
                        depthRight++;
                        qRight.Enqueue(currentRight.right);
                        qLeft.Enqueue(currentRight.left);
                    }
                }
            }

            return depthLeft > depthRight ? depthLeft : depthRight;
            */

            /** ITERATIVE SOLUTION BY GEEKS TO GEEKS **/
            // Base Case
            if (root == null)
                return 0;

            // Create an empty queue
            // for level order traversal
            Queue<TreeNode> q = new Queue<TreeNode>();

            // Enqueue Root and initialize height
            q.Enqueue(root);
            int height = 0;

            while (1 == 1)
            {
                // nodeCount (queue size) indicates
                // number of nodes at current level.
                int nodeCount = q.Count;
                if (nodeCount == 0)
                    return height;
                height++;

                // Dequeue all nodes of current
                // level and Enqueue all
                // nodes of next level
                while (nodeCount > 0)
                {
                    TreeNode newnode = q.Peek();
                    q.Dequeue();
                    if (newnode.left != null)
                        q.Enqueue(newnode.left);
                    if (newnode.right != null)
                        q.Enqueue(newnode.right);
                    nodeCount--;
                }
            }
        }

    }
}

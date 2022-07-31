using System.Collections;
using System.Data;
using System.Reflection.Metadata;
using DataStructuresPlayground.Domains.Graph;

namespace DataStructuresPlayground.Services.Graph
{
    public class GraphService<T>
    {
        #region Fields and Properties

        /// <summary>
        /// The graph used to perform the operations.
        /// </summary>
        public DSGraph<T> Graph { get; set; }

        public HashSet<GraphNode<T>> TrackedNodes { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public GraphService(DSGraph<T> graph)
        {
            Graph = graph;
            TrackedNodes = new HashSet<GraphNode<T>>();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GraphService() {}

        #endregion

        #region Methods

        /// <summary>
        /// Performs a depth-first search in the graph for a specific node.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public GraphNode<T>? DFSearchNode(T value, GraphNode<T>? root)
        {
            if (value == null) throw new ArgumentNullException("Value to search cannot be null.");
            
            root.Visited = true;
            TrackedNodes.Add(root);

            if (root?.Nodes == null) return null;

            foreach (var node in root.Nodes)
            {
                if (node.Visited) continue;

                var nodeFound = DFSearchNode(value, node);

                if (nodeFound != null)
                    return nodeFound;
            }
            
            return null;
        }

        /// <summary>
        /// Performs a breadth-first search in the graph for a specific node.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="root">The node to search. Usually, the root node.</param>
        /// <returns></returns>
        public GraphNode<T>? BFSearchNode(T value, GraphNode<T>? root)
        {
            Queue<GraphNode<T>?> nodesToSearch = new Queue<GraphNode<T>?>();
            HashSet<GraphNode<T>?> visitedNodes = new HashSet<GraphNode<T>?>();

            if (root.Value.Equals(value)) return root;

            // node is not what we want, so we mark it as visited.
            visitedNodes.Add(root);
            TrackedNodes.Add(root);
            nodesToSearch.Enqueue(root); //enqueue first node to search 

            while (nodesToSearch.Count > 0)
            {
                var currentNode = nodesToSearch.Dequeue();

                if (currentNode.Value.Equals(value)) return currentNode;

                if (currentNode.Nodes == null) continue;

                foreach (var neighbor in currentNode.Nodes)
                {
                    if (visitedNodes.Contains(neighbor)) continue;
                    
                    visitedNodes.Add(neighbor);
                    nodesToSearch.Enqueue(neighbor);
                }
            }

            return null;
        }

        #endregion
    }
}

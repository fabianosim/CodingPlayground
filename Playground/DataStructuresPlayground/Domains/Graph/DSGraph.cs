namespace DataStructuresPlayground.Domains.Graph
{
    public class DSGraph<T>
    {
        #region Fields and Properties

        /// <summary>
        /// The first node that starts a graph.
        /// </summary>
        public GraphNode<T> Node { get; set; }

        
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a graph starting with a node.
        /// </summary>
        /// <param name="node"></param>
        public DSGraph(GraphNode<T> node)
        {
            Node = node;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DSGraph() {}

        #endregion
    }
}

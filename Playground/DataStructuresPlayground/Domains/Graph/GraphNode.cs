using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPlayground.Domains.Graph
{
    /// <summary>
    /// Represents a Graph node.
    /// </summary>
    public class GraphNode<T>
    {
        #region Fields and Properties

        /// <summary>
        /// Holds the reference to the <see cref="T"/> value
        /// </summary>
        public T? Value { get; set; }

        /// <summary>
        /// The neighbor nodes to this graph.
        /// </summary>
        public GraphNode<T>[] Nodes { get; set; }

        /// <summary>
        /// Informs if the node is visited or not.
        /// </summary>
        public bool Visited { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a graph with the value.
        /// </summary>
        /// <param name="value"></param>
        public GraphNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Creates a graph with the value and the nodes.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="neighbors"></param>
        public GraphNode(T value, GraphNode<T>[] neighbors)
        {
            Value = value;
            Nodes = neighbors;
        }

        #endregion

        #region Methods
        
        #endregion
    }
}

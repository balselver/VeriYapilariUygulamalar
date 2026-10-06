using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Graph
{
    public class Edge<T, C> : IEdge<T>
        where C : IComparable
    {
        private object weight;

        public Edge(IGraphVertex<T> target, C Weight)
        {
            TargetVertex = target;
            this.weight = Weight;
        }

        public T TargetVertexKey => TargetVertex.Key;

        public IGraphVertex<T> TargetVertex { get; private set; }

        public W Weight<W>() where W : IComparable
        {
            return (W)weight;
        }
        public override string ToString()
        {
            return TargetVertexKey.ToString();     
        }
    }
}

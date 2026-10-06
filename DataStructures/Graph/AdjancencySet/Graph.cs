using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructures.Graph.AdjancencySet
{
    public class Graph<T> : IGraph<T>
    {
        private Dictionary<T, GraphVertex<T>> vertices;

        public bool isWeightedGraph => false;

        public int Count => vertices.Count;

        public IGraphVertex<T> ReferenceVertex =>
            //grafa ilk eklenen düğüm referans düğüm
            vertices[this.First()];

        public IEnumerable<IGraphVertex<T>> VertexAsEnumerable =>
            vertices.Select(x => x.Value);

        public Graph(IEnumerable<T> collection)
        {
            vertices = new Dictionary<T, GraphVertex<T>>();
            foreach (var item in collection)
            {
                AddVertex(item);
            }
        }

        public Graph()
        {
            vertices = new Dictionary<T, GraphVertex<T>>();
        }

        public void AddVertex(T key)
        {
            if (key == null)
                throw new ArgumentNullException();

            var newVertex = new GraphVertex<T>(key);
            vertices.Add(key, newVertex);           
        }

         IGraph<T> IGraph<T>.Clone()
        {
            return Clone();
        }

        public Graph<T> Clone()
        {
            var graph = new DataStructures
                .Graph
                .AdjancencySet
                .Graph<T>(); // default ctor ile vercises ifadesi newlendi
            foreach (var vertex in vertices)
                graph.AddVertex(vertex.Key);

            foreach (var vertex in vertices)
            {
                foreach (var edge in vertex.Value.Edges)                
                    graph.AddEdge(vertex.Value.Key, edge.Key);
                
            }
     
            return graph; //bu dönüş deepcopydir. tamamen yeni nesnedir
        }

        public bool ContainsVertex(T key)
        {
            return vertices.ContainsKey(key);
        }

        public IEnumerable<T> Edges(T key)
        {
            if (key == null)
                throw new ArgumentNullException();
            return vertices[key].Edges.Select(x => x.Key);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return vertices.Select(x =>x.Key).GetEnumerator();
        }

        public IGraphVertex<T> GetVertex(T key)
        {
            return vertices[key];
        }

        public bool HasEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("source or destination vertex is not int this graph.");

            return vertices[source].Edges.Contains(vertices[dest])//A dan B ye
                && vertices[dest].Edges.Contains(vertices[source]);//B den A ya
        }

        public void AddEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("source or destination vertex is not int this graph.");

            if (vertices[source].Edges.Contains(vertices[dest]) ||
                vertices[dest].Edges.Contains(vertices[source]))
                throw new Exception("The edge has been already define");

            vertices[source].Edges.Add(vertices[dest]);//A dan B ye
            vertices[dest].Edges.Add(vertices[source]);//B den A ya
            //vertices[source] ile elde edilen graph vertex ifadesi
        }

        public void RemoveEdge(T source, T dest)
        {
            if (source == null || dest == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(source) || !vertices.ContainsKey(dest))
                throw new ArgumentException("source or destination vertex is not int this graph.");

            if (!vertices[source].Edges.Contains(vertices[dest]) ||
                !vertices[dest].Edges.Contains(vertices[source]))
                throw new Exception("The edge does not exists.");

            vertices[source].Edges.Remove(vertices[dest]);
            vertices[dest].Edges.Remove(vertices[source]);
        }

        public void RemoveVertex(T key)
        {
            if (key == null)
                throw new ArgumentNullException();

            if (!vertices.ContainsKey(key))
                throw new ArgumentNullException("The vertex is not in this graph");

            foreach (var vertex in vertices[key].Edges)
                vertex.Edges.Remove(vertices[key]);

            vertices.Remove(key);            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class GraphVertex<T> : IGraphVertex<T>
        {
            public T Key { get; set; }
            public HashSet<GraphVertex<T>> Edges { get; private set; }
            public GraphVertex(T key)
            {
                Key = key;
                Edges = new HashSet<GraphVertex<T>>();
            }

            IEnumerable<IEdge<T>> IGraphVertex<T>.Edges =>
                Edges.Select(x => new Edge<T, int>(x, 1));

            public IEdge<T> GetEdge(IGraphVertex<T> targetVertex)
            {
                return new Edge<T, int>(targetVertex, 1);
            }

            public IEnumerator<T> GetEnumerator()
            {
                return Edges.Select(x => x.Key).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}

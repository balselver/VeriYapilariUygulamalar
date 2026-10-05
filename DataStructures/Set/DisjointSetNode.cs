using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Set
{
    public class DisjointSetNode<T>
    {
        public T Value { get; set; }
        public int Rank { get; set; }
        public DisjointSetNode<T> Parent { get; set; }
        public DisjointSetNode()
        {

        }
        public DisjointSetNode(T value)
        {
            //sadece değeri alır
            Value = value;
            Rank = 0;
        }
        public DisjointSetNode(T value, int rank) 
        {
            //hem değer hem de rankı alır
            Value = value;
            Rank = rank;
        }
        public override string ToString()
        {
            return $"{Value}";
        }
    }
}

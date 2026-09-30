using DataStructures.LinkedList.DoublyLinkedList;
using System;

namespace DataStructures.Queue
{
    internal class LinkedListQueue<T> : IQueue<T>
    {
        private readonly DoublyLinkedList<T> list = new DoublyLinkedList<T>();
        public int Count { get; private set; }
        public T DeQueue()
        {
            if (Count == 0)
                throw new Exception("Queue Empt!");
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }
        public void EnQueue(T Value)
        {
            if (Value == null)
                throw new ArgumentNullException();
            list.AddLast(Value);
            Count++;
        }
        public T Peek() => Count==0 
            ? throw new Exception("Queue Empt!")
            : list.Head.Value;
        /*
    {
        if (Count == 0)
            throw new Exception("Queue Empt!");
        return list.Head.Value;
    }*/

    }
}
using DataStructures.LinkedList.SinglyLinkedList;
using System;

namespace DataStructures.Stack
{
    public class LinkedListStack<T> : IStack<T>
    {
        private readonly SinglyLinkedList<T> list =
            new SinglyLinkedList<T>();
        
        public int Count { get; private set; }

        public T Peek()
        {
            if (Count == 0)
                throw new Exception("Empty stack !");
            return list.Head.Value;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new Exception("Empty stack !");
            var temp = list.RemoveFirst();
            Count--;
            return temp;
        }

        public void Push(T Value)
        {
            if (Value == null)
                throw new ArgumentNullException();

            list.AddFirst(Value);
            Count++;
        }
    }
}
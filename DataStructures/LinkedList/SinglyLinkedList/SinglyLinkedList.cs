using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList.SinglyLinkedList
{
    public class SinglyLinkedList<T> : IEnumerable<T>
    {
        public SinglyLinkedList()
        {

        }
        public SinglyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                this.AddFirst(item);
            }        
        }

        public SinglyLinkedListNode<T> Head { get; set; }
        private bool isHeadNull => Head == null ? true : false;

        public void AddFirst(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            newNode.Next = Head;
            Head = newNode;        
        }
        public void AddLast(T value)
        {
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            if (isHeadNull)
            {
                Head = newNode;
                return;
            }

            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        public void AddAfter(SinglyLinkedListNode<T> node, T value)
        {
            if (node == null)
            {
                throw new ArgumentException();
            }

            if (isHeadNull)
            {
                AddFirst(value);
                return;
            }
            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;
            while (current != null)
            {
                if (current.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list");
        }
        
        public void AddAfter(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            while (refNode!=null)
            {
                if (refNode == null || newNode == null)
                {
                    throw new ArgumentException();
                }
                var current = Head;
                while (current != null)
                {
                    if (current == refNode)
                    {
                        newNode.Next = current.Next;
                        current.Next = newNode;
                        return;
                    }
                    current = current.Next;
                }
                throw new ArgumentException("The reference node is not in this list");

            }            

        }

        public void AddBefore(SinglyLinkedListNode<T> node, T value)
        {
            if (node==null)
            {
                throw new ArgumentException();
            }

            //aranan düğümü listenin başıysa 
            if (Head != null && Head.Equals(node))
            {
                AddFirst(value);
                return;
            }

            var newNode = new SinglyLinkedListNode<T>(value);
            var current = Head;

            while (current != null && current.Next != null)
            {
                if (current.Next.Equals(node))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list");
        }

        public void AddBefore(SinglyLinkedListNode<T> refNode, SinglyLinkedListNode<T> newNode)
        {
            if (refNode == null ||newNode == null)
            {
                throw new ArgumentException();
            }

            var current = Head;

            if (Head != null && Head.Equals(refNode))
            {
                if (current.Next.Equals(refNode))
                {
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    return;
                }
                current = current.Next;
            }
            throw new ArgumentException("The reference node is not in this list");
        }

        public IEnumerator<T> GetEnumerator()
        {

            return new SinglyLinkedListEnumerator<T>(Head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T RemoveFirst()
        {
            if (isHeadNull)            
                throw new Exception("Nothing to remove");
            
            var firstValue = Head.Value;
            Head = Head.Next;
            return firstValue;
        }

        public T RemoveLast()
        {
            if (isHeadNull)
                throw new Exception("Underflow ! Nothing to remove");
            
            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            while (current.Next != null)
            {
                prev = current;
                current = current.Next;
            }
            var lastValue = prev.Next.Value;
            prev.Next = null;
            return lastValue;
        }

        public void Remove(T Value) 
        {
            if (isHeadNull)
                throw new Exception("Underflow ! Nothing to remove");
            if (Value==null)                            
                throw new ArgumentNullException();

            var current = Head;
            SinglyLinkedListNode<T> prev = null;
            do
            {
                if (current.Value.Equals(Value))
                {
                    //son eleman mı ? 
                    if (current.Next == null)
                    {
                        //tek eleman mı, head silinmek istenir
                        if (prev == null)
                        {
                            Head = null;
                            return;
                        }
                        //son eleman
                        else
                        {
                            prev.Next = null;
                            return;
                        }
                    }
                    else
                    {
                        //head 
                        if (prev == null)
                        {
                            Head = Head.Next;
                            return;
                        }
                        //ara düğüm
                        else
                        {
                            prev.Next = current.Next;
                            return;
                        }
                    }
                }
                prev = current;
                current = current.Next;

            } while (current != null);
            throw new ArgumentException("Listede bu eleman bulunamadı");

            
        }
        
    }
}

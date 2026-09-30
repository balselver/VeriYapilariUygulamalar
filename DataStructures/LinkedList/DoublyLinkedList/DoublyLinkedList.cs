using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.LinkedList.DoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable
    {
        public DoublyLinkedListNode<T> Head { get; set; }
        public DoublyLinkedListNode<T> Tail { get; set; }
        private bool isHeadNull => Head == null;
        private bool isTailNull => Tail == null;

        public DoublyLinkedList()
        {

        }
        public DoublyLinkedList(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                AddLast(item);
            }
        }
        public void AddFirst(T Value)
        {
            var newNode = new DoublyLinkedListNode<T>(Value);
            if (Head != null)
            {
                Head.Prev = newNode;
            }
            newNode.Next = Head;
            newNode.Prev = null;
            Head = newNode;

            if (Tail == null)
            {
                Tail = Head;
            }
        }
        public void AddLast(T Value)
        {
            if (Tail == null)
            {
                AddFirst(Value);
                return;
            }

            var newNode = new DoublyLinkedListNode<T>(Value);
            Tail.Next = newNode;
            newNode.Next = null;
            newNode.Prev = Tail;
            Tail = newNode;
            return;

        }
        public void AddAfter(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
                throw new ArgumentNullException();

            if (refNode == Head && refNode == Tail)
            {
                refNode.Next = newNode;
                refNode.Prev = null;

                newNode.Prev = refNode;
                newNode.Next = null;

                Head = refNode;
                Tail = newNode;
                return;
            }

            if (refNode != Tail)
            {
                newNode.Prev = refNode;
                newNode.Next = refNode.Next;
                refNode.Next.Prev = newNode;
                refNode.Next = newNode;
            }
            else
            {
                newNode.Prev = refNode;
                newNode.Next = null;
                refNode.Next = newNode;
                Tail = newNode;
            }

        }
        public void AddBefore(DoublyLinkedListNode<T> refNode, DoublyLinkedListNode<T> newNode)
        {
            if (refNode == null)
                throw new ArgumentNullException();

            if (refNode == Head && refNode == Tail)
            {
                refNode.Prev = newNode;
                refNode.Next = null;

                newNode.Next = refNode;
                newNode.Prev = null;

                Head = newNode;
                Tail = refNode;
                return;
            }
            if (refNode != Tail)
            {
                newNode.Next = refNode;
                refNode.Prev = newNode.Next;
                newNode.Prev = refNode.Prev;


            }
            else
            {
                newNode.Next = refNode;
                refNode.Next = null;
                refNode.Prev.Next = newNode;
                refNode.Prev = newNode;
            }


        }
        public T RemoveFirst()
        {
            if (isHeadNull)
                throw new Exception("Silinecek eleman yok");

            var temp = Head.Value;
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
            }
            return temp;
        }
        public T RemoveLast() 
        {
            if (isTailNull)
                throw new Exception(" empty list !");
            var temp = Tail.Value;
            if (Tail == Head)
            {
                Head = null;
                Tail = null;

            }
            else 
            {
                Tail.Prev.Next = null;
                Tail = Tail.Prev;
            }
            return temp;
        }
        public void Remove(T Value)
        {
            if (isHeadNull)
                throw new Exception("Empty list !");
            if (Head==Tail)
            {
                if (Head.Value.Equals(Value))
                {
                    RemoveFirst();
                }
                return;
            }
            var current = Head;
            while (current !=null)
            {
                if (current.Value.Equals(Value))
                {
                    if (current.Prev == null)
                    {
                        current.Next.Prev = null;
                        Head = current.Next;
                    }
                    else if (current.Next == null)
                    {
                        current.Prev.Next = null;
                        Tail = current.Prev;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    break;
                }
                current = current.Next;

            }
        }
        private List<DoublyLinkedListNode<T>> GetAllNodes()
        {
            var list = new List<DoublyLinkedListNode<T>>();
            var current = Head;
            while (current != null)
            {
                list.Add(current);
                current = current.Next;
            }
            return list;
        }
        public IEnumerator GetEnumerator()
        {
            return GetAllNodes().GetEnumerator();
        }
    }
}

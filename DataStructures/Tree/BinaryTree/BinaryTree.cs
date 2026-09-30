

using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Tree.BinaryTree
{    public class BinaryTree<T> where T : IComparable
    {
        public List<Node<T>> list { get; private set; }
        public BinaryTree()
        {
            list = new List<Node<T>>();
        }
        public List<Node<T>> InOrder(Node<T> root)
        {
            if (root!=null)
            {
                InOrder(root.Left);
                list.Add(root);
                InOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructures.Stack.Stack<Node<T>>();
            Node<T> currentNode = root;
            bool done = false;
            while (!done)
            {
                if (currentNode != null)
                {
                    S.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else 
                {
                    if (S.Count == 0)
                    {
                        done = true;
                    }
                    else
                    {
                        currentNode = S.Pop();
                        list.Add(currentNode);
                        currentNode = currentNode.Right;
                    }
                }
            }
            return list;
        }
        public List<Node<T>> PreOrder(Node<T> root)
        {
            if (!(root==null))
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> PreOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var S = new DataStructures.Stack.Stack<Node<T>>();
            if (root == null)
                return list;

            S.Push(root);
            while (!(S.Count==0))
            {
                var temp = S.Pop();
                list.Add(temp);

                if (temp.Right!=null)                
                    S.Push(temp);
                if (temp.Left!=null)                
                    S.Push(temp);               
                
            }
            return list;
        }
        public List<Node<T>> PostOrder(Node<T> root)
        {
            if (!(root==null))
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);
            }
            return list;
        }
        public List<Node<T>> LevelOrderNonRecursiveTraversal(Node<T> root)
        {
            var list = new List<Node<T>>();
            var Q = new DataStructures.Queue.Queue<Node<T>>();
            Q.EnQueue(root);
            while (Q.Count>0)
            {
                var temp = Q.DeQueue();
                list.Add(temp);
                if (temp.Left!=null)                
                    Q.EnQueue(temp.Left);
                if (temp.Right != null)
                    Q.EnQueue(temp.Right);                              
                
            }
            return list;
        }
        public void ClearList() => list.Clear();
    }
}

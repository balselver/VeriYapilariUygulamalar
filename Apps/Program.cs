using DataStructures.LinkedList.DoublyLinkedList;
using DataStructures.LinkedList.SinglyLinkedList;
using DataStructures.Stack;
using DataStructures.Tree.BinaryTree;
using DataStructures.Tree.BST;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Apps
{
    class Program
    {
        static void Main(string[] args)
        {           

            Console.ReadKey();
        }

        private static void DisjointSetApp()
        {
            var disjointSet = new DataStructures
                .Set
                .DisjointSet<int>(new int[] { 0, 1, 2, 3, 4, 5, 6 });

            disjointSet.Union(5, 6);
            disjointSet.Union(1, 2);
            disjointSet.Union(0, 2);

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine($"Find({i}) = {disjointSet.FindSet(i)}");
            }
        }
        private static void BİnaryHeapMAaxHeapMinHeap()
        {
            //Asendinf = MİnHeap
            //Descending = MaxHeap

            var heap = new
                DataStructures
                .Heap
                .BinaryHeap<int>(DataStructures.Shared.SortDirection.Ascending,
                new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });

            foreach (var item in heap)
            {
                Console.Write(item + "  ");
            }
        }
        private static void BinaryHeapMaxHeapApp()
        {
            var heap = new DataStructures
                .Heap
                .MaxHeap<int>(new int[] { 54, 45, 36, 27, 29, 18, 21, 11, 99 });

            Console.WriteLine($" {heap.DeleteMinMax()} : has been removed ");
            Console.WriteLine($" {heap.DeleteMinMax()} : has been removed ");
            Console.WriteLine($" {heap.DeleteMinMax()} : has been removed ");


            foreach (var item in heap)
            {
                Console.Write(item + "  ");
            }
        }
        private static void BinaryHeapMinHeapApp()
        {
            var heap = new DataStructures
                .Heap
                .MinHeap<int>(new int[] { 4, 1, 10, 8, 7, 5, 9, 3, 2 });

            Console.WriteLine(heap.DeleteMinMax() + " Has been removed");
            Console.WriteLine(heap.DeleteMinMax() + " Has been removed");
            Console.WriteLine(heap.DeleteMinMax() + " Has been removed");
            Console.WriteLine(heap.DeleteMinMax() + " Has been removed");
            Console.WriteLine(heap.DeleteMinMax() + " Has been removed");

            foreach (var item in heap)
            {
                Console.WriteLine(item);
            }
        }
        private static void BinaryTreeGetEnumerator()
        {
            var bst =
                new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99 });
            foreach (var node in bst)
            {
                Console.Write(node);
            }
        }
        private static void BinaryTreePathsApp()
        {
            var bst = new BST<int>(new int[] { 23, 16, 45, 3, 22, 37, 99, 100 });
            bst.Remove(bst.Root, 22);
            new BinaryTree<int>().PrintPaths(bst.Root);
        }
        private static void BinaryTreeNumberOfLeafsApp()
        {
            var bst =
                new BST<int>
                (new int[] { 23, 16, 45, 3, 22, 37, 99 });

            bst.Remove(bst.Root, 3); //3 yaprağını sil
            bst.Remove(bst.Root, 99); //99 yaprağını sil


            //yaprak sayısının hesaplanması
            Console.WriteLine($"Number of Leafs : " +
                $"{BinaryTree<int>.NumberOfLeafs(bst.Root)}");

            Console.WriteLine($"Number of full node : " +
                $"{BinaryTree<int>.NumberOfFullNodes(bst.Root)}");

            Console.WriteLine($"Number of half node : " +
                $"{BinaryTree<int>.NumberOfHalfNode(bst.Root)}");
        }
        private static void BinaryTreeDeepestApp()
        {
            var bt = new DataStructures
                .Tree
                .BinaryTree
                .BinaryTree<char>();

            bt.Root = new Node<char>('F');
            bt.Root.Left = new Node<char>('A');
            bt.Root.Right = new Node<char>('T');
            bt.Root.Left.Left = new Node<char>('D');

            var list = bt.LevelOrderNonRecursiveTraversal(bt.Root);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine($"Deepest Node   : {bt.DeepestNode(bt.Root)}");
            Console.WriteLine($"Deepest Node   : {bt.DeepestNode()}");
            Console.WriteLine($"Max Depth Node   : {BinaryTree<char>.MaxDepth(bt.Root)}");
        }
        private static void BinaryTreeMaxDepthApp()
        {
            var bst = new DataStructures
                .Tree
                .BST
                .BST<byte>(new byte[] { 60, 40, 70, 20, 45, 65, 85, 90 });

            var list = new DataStructures
                .Tree.BinaryTree.BinaryTree<byte>()
                .InOrder(bst.Root);

            foreach (var node in list)
            {
                Console.Write($"{node,-3} ");
            }
            Console.WriteLine();

            Console.WriteLine($"Min        : {bst.FindMin(bst.Root)}");
            Console.WriteLine($"Max        : {bst.FindMax(bst.Root)}");
            Console.WriteLine($"Depth      : " +
                $"{DataStructures.Tree.BinaryTree.BinaryTree<byte>.MaxDepth(bst.Root)}");
        }
        private static void BİnaryTreeRemoveApp()
        {
            var BST = new
                BST<int>(new List<int>()
                { 60,40,70,20,45,65,85 });
            var bt = new BinaryTree<int>();

            bt.InOrder(BST.Root)
               .ForEach(node => Console.Write($"{node,-3} "));

            BST.Remove(BST.Root, 20);
            BST.Remove(BST.Root, 40);
            BST.Remove(BST.Root, 60);

            bt.ClearList();

            Console.WriteLine();
            bt.InOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3} "));
        }
        private static void BinaryTreeApp()
        {
            var BST = new
                BST<int>(new int[]
                { 23, 16, 45, 3, 22, 37, 99 });

            var bt = new BinaryTree<int>();
            /*bt.PreOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3} "));

            Console.WriteLine();
            bt.PreOrderNonRecursiveTraversal(BST.Root)
                .ForEach(node => Console.Write($"{node,-3} "));
            */
            Console.WriteLine("\nlevel order traversal\n");

            bt.LevelOrderNonRecursiveTraversal(BST.Root)
                .ForEach(node => Console.Write($"{node,-3} "));
            /*
            bt.InOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3} "));

            Console.WriteLine();
            bt.InOrderNonRecursiveTraversal(BST.Root)
                .ForEach(node => Console.Write($"{node,-3} "));           

            bt.ClearList(); //nesne oluşturularak metotlar çağırıldığı için bu metotşa listenin temizlenmesi gerekir.
            */

            /*
            bt.ClearList();

            bt.PostOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3} "));
            */
            Console.WriteLine();
            Console.WriteLine($"Minimum Value : {BST.FindMin(BST.Root.Right)}");
            Console.WriteLine($"Maximum Value : {BST.FindMax(BST.Root.Left)}");

            var keyNode = BST.Find(BST.Root, 20);
            if (keyNode != null)
                Console.WriteLine($"" +
                $"{keyNode.Value} -" +
                $" Left : {keyNode.Left.Value} - " +
                $"Right : {keyNode.Right.Value}");
        }
        private static void QueueApp01()
        {
            var numbers = new int[] { 10, 20, 30 };
            var q1 = new DataStructures.Queue.Queue<int>();
            var q2 = new DataStructures
                .Queue
                .Queue<int>(DataStructures.Queue.QueueType.LinkedList);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
                q1.EnQueue(number);
                q2.EnQueue(number);
            }
            Console.WriteLine($"q1 count : {q1.Count}");
            Console.WriteLine($"q2 count : {q2.Count}");

            Console.WriteLine($"{q1.DeQueue()} has been removed from q1");
            Console.WriteLine($"{q2.DeQueue()} has been removed from q2");

            Console.WriteLine($"q1 peek : {q1.Peek()}");
            Console.WriteLine($"q2 peek : {q2.Peek()}");
        }
        private static void StackApp01()
        {
            var charset = new char[] { 'a', 'b', 'c', 'd', 'e' };
            var stack1 = new DataStructures.Stack.Stack<char>();
            var stack2 = new DataStructures.Stack.Stack<char>(StackType.LinkedList);

            foreach (var c in charset)
            {
                Console.WriteLine(c);
                stack1.Push(c);
                stack2.Push(c);
            }


            Console.WriteLine("\npeek");
            Console.WriteLine($"Stack 1 : {stack1.Peek()}");
            Console.WriteLine($"Stack 2 : {stack2.Peek()}");

            Console.WriteLine("\ncount");
            Console.WriteLine($"Stack 1 : {stack1.Count}");
            Console.WriteLine($"Stack 2 : {stack2.Count}");

            Console.WriteLine("\npop");
            Console.WriteLine($"Stack 1 : {stack1.Pop()} has been removed");
            Console.WriteLine($"Stack 2 : {stack2.Pop()} has been removed");
        }
        private static void DoublyLinkedListApp03()
        {
            var list = new DoublyLinkedList<int>(new int[] { 23, 44, 55, 61 });
            list.Remove(55);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void DoublyLinkedListApp02()
        {
            var list = new DoublyLinkedList<char>(new List<char>() { 'a', 'b', 'c', 'x', 'y' });

            Console.WriteLine($"{list.RemoveFirst()} has been removed from list");
            Console.WriteLine($"{list.RemoveLast()} has been removed from the list");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void DoublyLinkedListApp01()
        {
            var list = new DoublyLinkedList<int>();
            list.AddFirst(12);
            list.AddFirst(23);
            //23 12
            list.AddLast(44);
            list.AddLast(55);
            //23 12 44 55
            list.AddAfter(list.Head.Next,
                new DoublyLinkedListNode<int>(13));
            //23 12 13 44 55

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void SinglyLinkedListApp05()
        {
            var list = new SinglyLinkedList<int>(new int[] { 23, 44, 32, 55 });
            list.Remove(32);
            /*list.Remove(55);
            list.Remove(44);
            list.Remove(23);*/
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        private static void SinglyLinkedListApp04()
        {
            var rnd = new Random();
            var initial = Enumerable.Range(1, 5).OrderBy(x => rnd.Next()).ToList();
            var list = new SinglyLinkedList<int>(initial);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.RemoveFirst();
            list.RemoveFirst();

            Console.WriteLine($"{list.RemoveLast()} has been removed ");


            foreach (var item in list)
            {
                Console.Write(item);
            }
        }
        private static void SinglyLinkedListApp03()
        {
            // Language Integrated Query - LINQ
            var rnd = new Random();
            var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
            var linkedList = new SinglyLinkedList<int>(initial);

            var q = from item in linkedList
                    where item % 2 == 1
                    select item;
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
            linkedList.Where(x => x > 5)
                .ToList()
                .ForEach(x => Console.Write(x + " "));
        }
        private static void SinglyLinkedListApp02()
        {
            var arr = new char[] { 'a', 'b', 'c' };
            var list = new List<char>(arr);
            var clinkedList = new LinkedList<char>(arr);
            list.AddRange(new char[] { 'd', 'e', });

            var linkedList = new SinglyLinkedList<char>(list);

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            var charset = new List<char>(linkedList);
            foreach (var item in charset)
            {
                Console.Write(item);
            }
        }
        private static void SinglyLinkedListApp01()
        {
            var linkedList = new SinglyLinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            //3 2 1 baştan ekleme yapar O(1)

            linkedList.AddLast(4);
            linkedList.AddLast(5);
            //3 2 1 4 5 o(n)

            linkedList.AddAfter(linkedList.Head.Next, 32);
            linkedList.AddAfter(linkedList.Head.Next.Next, 33);
            //3 2 32 33 1 4 5 

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            var list = new LinkedList<int>();
            list.AddFirst(1);
            list.AddFirst(2);
            list.AddFirst(3);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        

    }
}

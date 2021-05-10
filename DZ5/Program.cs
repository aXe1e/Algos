using System;
using System.Collections.Generic;

namespace DZ5
{
    class Program
    {
        static Tree t;
        static void Main(string[] args)
        {
            t = new Tree();
            var arrTree = new int[12] { 15, 20, 30, 10, 9, 17, 13, 14, 12, 11, 3, 16 };
            for (int i = 0; i < arrTree.Length; i++)
            {
                t.AddItem(arrTree[i]);
            }
            t.PrintTree();
            Console.WriteLine("\nBFS:");
            BFS(12);
            Console.WriteLine("\nDFS:");
            DFS(16);
            Console.WriteLine("\n");
        }
        public static TreeNode BFS(int value)
        {
            var q = new Queue<TreeNode>();
            q.Enqueue(t.GetRoot());
            while (q.Count != 0)
            {
                var n = q.Dequeue();

                Console.Write(n.Value + " ");

                if (n.Value == value)
                {
                    return n;
                }
                if (n.LeftChild != null) q.Enqueue(n.LeftChild);
                if (n.RightChild != null) q.Enqueue(n.RightChild);
            }
            return null;
        }

        public static TreeNode DFS(int value)
        {
            var s = new Stack<TreeNode>();
            s.Push(t.GetRoot());
            while (s.Count != 0)
            {
                var n = s.Pop();

                Console.Write(n.Value + " ");

                if (n.Value == value)
                {
                    return n;
                }
                if (n.RightChild != null) s.Push(n.RightChild);
                if (n.LeftChild != null) s.Push(n.LeftChild);
                
            }
            return null;
        }
    }
}

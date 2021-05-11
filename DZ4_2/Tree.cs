using System;
using System.Collections.Generic;
using System.Text;

namespace DZ4_2
{
    public class Tree : ITree
    {
        private TreeNode Root { get; set; }    //Корень дерева
        public void AddItem(int value)
        {
            if (GetNodeByValue(value) != null)  //Если значение есть, то не добавляем
                return;
            var NewNode = new TreeNode(value);
            if (GetRoot() == null)   //Создаем корень, если нету
                Root = NewNode;         
            else    //Определяем куда добавить
            {
                var CurrNode = GetRoot();
                while (CurrNode != null)
                {
                    if (value < CurrNode.Value)
                    {
                        if (CurrNode.LeftChild == null)
                        {
                            CurrNode.LeftChild = NewNode;
                            return;
                        }
                        else
                            CurrNode = CurrNode.LeftChild;
                    }
                    else
                    {
                        if (CurrNode.RightChild == null)
                        {
                            CurrNode.RightChild = NewNode;
                            return;
                        }
                        else
                            CurrNode = CurrNode.RightChild;
                    }
                }                       
            }
        }
        public TreeNode GetNodeByValue(int value)
        {
            var CurrNode = GetRoot();
            while (CurrNode != null && CurrNode.Value != value)
            {
                if (value < CurrNode.Value)
                    CurrNode = CurrNode.LeftChild;
                else
                    CurrNode = CurrNode.RightChild;
            }
            return CurrNode;
        }
        private TreeNode GetParentByNode(TreeNode node)
        {
            if (GetRoot() == node)
                return null;
            
            var CurrNode = GetRoot();
           
            while (CurrNode != null && (CurrNode.LeftChild != node || CurrNode.RightChild != node))
            {
                if (CurrNode.LeftChild == node || CurrNode.RightChild == node)
                    return CurrNode;
                if (node.Value < CurrNode.Value)
                    CurrNode = CurrNode.LeftChild;
                else
                    CurrNode = CurrNode.RightChild;
            }
            return null;
        }
        private int minValue(TreeNode node)
        {
            int minv = node.Value;
            while (node.LeftChild != null)
            {
                node = node.LeftChild;
                if (node != null)
                    minv = node.Value;                
            }                
            return minv;
        }
        public TreeNode GetRoot()
        {
            return Root;
        }
        public void PrintTree()
        {
            Print(GetRoot());
        }
        private static void Print(TreeNode root, string textFormat = "(0)", int spacing = 1, int topMargin = 2, int leftMargin = 2)
        {
            if (root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.Value.ToString(textFormat) };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + spacing;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = leftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.LeftChild)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos - 1);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos + 1);
                    }
                }
                next = next.LeftChild ?? next.RightChild;
                for (; next == null; item = item.Parent)
                {
                    int top = rootTop + 2 * level;
                    Print(item.Text, top, item.StartPos);
                    if (item.Left != null)
                    {
                        Print("/", top + 1, item.Left.EndPos);
                        Print("_", top, item.Left.EndPos + 1, item.StartPos);
                    }
                    if (item.Right != null)
                    {
                        Print("_", top, item.EndPos, item.Right.StartPos - 1);
                        Print("\\", top + 1, item.Right.StartPos - 1);
                    }
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos + 1;
                        next = item.Parent.Node.RightChild;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos - 1;
                        else
                            item.Parent.StartPos += (item.StartPos - 1 - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }
        private static void Print(string s, int top, int left, int right = -1)
        {
            Console.SetCursorPosition(left, top);
            if (right < 0) right = left + s.Length;
            while (Console.CursorLeft < right) Console.Write(s);
        }
        public void RemoveItem(int value)
        {
            var node = GetNodeByValue(value);
            var parent = GetParentByNode(node);
            if (node == null)   //Элемент не найден, завершаем работу
                return;
            if (node.LeftChild == null && node.RightChild == null)  //Удаляем лист
            {
                if (parent.LeftChild == node)
                    parent.LeftChild = null;
                else
                    parent.RightChild = null;
                return;
            }
            if (node.LeftChild == null)   //если нет левого дочернего узла, то переносим оставшийся на место удаляемого
            {
                if (parent.LeftChild == node)
                    parent.LeftChild = node.RightChild;
                else
                    parent.RightChild = node.RightChild;
                return;
            }
            if (node.RightChild == null)   //если нет правого дочернего узла, то переносим оставшийся на место удаляемого
            {
                if (parent.LeftChild == node)
                    parent.LeftChild = node.LeftChild;
                else
                    parent.RightChild = node.LeftChild;
                return;
            }
            
            var NewNode = GetNodeByValue(minValue(node.RightChild));   //свободный узел с минимальным значением
            var ParentNewNode = GetParentByNode(NewNode);

            if (ParentNewNode.LeftChild == NewNode)
                ParentNewNode.LeftChild = null;
            else
                ParentNewNode.RightChild = null;
            
            NewNode.LeftChild = node.LeftChild;
            NewNode.RightChild = node.RightChild;
            if (parent == null)
            {
                Root = NewNode;
                return;
            }   
            if (parent.LeftChild == node)
                parent.LeftChild = NewNode;
            else
                parent.RightChild = NewNode;
        }
    }
}

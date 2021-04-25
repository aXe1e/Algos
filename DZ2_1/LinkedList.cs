using System;
using System.Collections.Generic;
using System.Text;

namespace DZ2_1
{
    public class LinkedList : ILinkedList
    {
        private Node FirstNode { get; set; }    //Начальная нода
        private Node LastNode { get; set; }     //Конечная нода
        private int CountNode { get; set; }     //Количество нод
        
        public void AddNode(int value)
        {
            var node = new Node { Value = value };

            if (FirstNode == null)  //Если нет нод, то добавляем первую
                FirstNode = node;
            else                    //Вставляем новую ноду в конец
            {
                LastNode.NextNode = node;
                node.PrevNode = LastNode;
            }
            LastNode = node;
            CountNode++;
        }
                
        public void AddNodeAfter(Node node, int value)
        {
            if (node != null)
            {
                var newNode = new Node { Value = value };
                var nextNode = node.NextNode;
                node.NextNode = newNode;
                newNode.PrevNode = node;

                nextNode.PrevNode = newNode;
                newNode.NextNode = nextNode;

                CountNode++;
            }
        }

        public Node FindNode(int searchValue)
        {
            var curNode = FirstNode;
            while (curNode != null)
            {
                if (curNode.Value == searchValue)
                    return curNode;
                curNode =  curNode.NextNode;
            }
            return null;
        }

        public Node GetByIndex(int index)   //Начинаем с 0 (как массив)
        {
            var curNode = FirstNode;
            int i = 0;
            while (i < index && curNode != null)
            {
                curNode = curNode.NextNode;
                i++;
            }
            return curNode;
        }

        public int GetCount()
        {
            return CountNode;
        }

        public void RemoveNode(int index)
        {
            var curNode = new Node();
            curNode = GetByIndex(index);
            if (curNode != null)
                RemoveNode(curNode);            
        }

        public void RemoveNode(Node node)
        {
            if (node != null)
            {
                var nextNode = node.NextNode;
                var prevNode = node.PrevNode;

                prevNode.NextNode = nextNode;
                nextNode.PrevNode = prevNode;
                CountNode--;
            }
        }

        public int[] ToArray()
        {
            var Arr = new int[GetCount()];
            for (int i = 0; i < GetCount(); i++)
            {
                Arr[i] = GetByIndex(i).Value;
            }
            return Arr;
        }
    }
}

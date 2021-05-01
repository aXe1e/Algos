using System;
using System.Collections.Generic;
using System.Text;

namespace DZ2_1
{
    
    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value);  // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
        Node GetByIndex(int index); // ищет элемент по порядковому номеру
        int[] ToArray();   //Преобразовываем в массив
    }
}

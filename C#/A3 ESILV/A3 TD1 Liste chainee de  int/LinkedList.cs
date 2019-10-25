using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3_POO_2019
{
    class LinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;
        public void AddHead(T data)
        {
            Node<T> tmp = new Node<T>(data);
            if (head == null)
            {
                head = tmp;
                tail = head;
            }
            else
            {
                tmp.next = head;
                head = tmp;               
            }           
        }
        public void AddQueue(T data)
        {
            Node<T> tmp = new Node<T>(data);
            if (head == null)
            {            
                 head = tmp;
                 tail = head;           
            }
            else
            {
                tail.next = tmp;
                tail = tmp;
            }
        }
        public void Affiche()
        {
            if (head != null) {
                Node<T> currNode = head;
                Console.Write(currNode.data + " ; ");
                while (currNode!=tail)
                {
                    currNode = currNode.next;
                    Console.Write(currNode.data + " ; ");

                }
                Console.WriteLine();
            }
        }
        public void Insert(T data, int pos)
        {
            if (pos == 0)
            {
                AddHead(data);
            }
            else
            {
                Node<T> tmp = new Node<T>(data);
                Node<T> prevNode = head;
                Node<T> currNode = head.next;
                for (int i = 1; i < pos; i++)
                {
                    prevNode = prevNode.next;
                    currNode = currNode.next;
                }
                prevNode.next = tmp;
                tmp.next = currNode;
            }
        }
    }
}

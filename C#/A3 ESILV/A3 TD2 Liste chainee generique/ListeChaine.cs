using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3_POO_liste_generique
{
    class ListeChaine<T>
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
            if (head != null)
            {
                Node<T> currNode = head;
                Console.Write(currNode.data + " ; ");
                while (currNode != tail)
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
        public void Remove(int pos)
        {
            if (head != null)
            {
                Node<T> currNode;
                currNode = head;
                while (currNode != tail && pos > 1)
                {
                    currNode = currNode.next;
                    pos--;
                }
                if (pos == 0)
                {
                    head = currNode.next;
                }
                else if (currNode.next == tail)
                {
                    tail = currNode;
                }
                else if (pos == 1)
                {
                    currNode.next = currNode.next.next;
                }
                else
                {
                    Console.WriteLine("Erreur dans remove, l'element n'a pas été retiré");
                }

            }
            else
            {
                Console.WriteLine("Erreur, la liste est deja vide");
            }
        }
        public Node<T> get(int i)
        {
            Node<T> currNode;
            currNode = head;
            if (head != null)
            {
                while (currNode != tail && i > 0)
                {
                    currNode = currNode.next;
                    i--;
                }
                if (i == 0)
                {
                    return currNode;
                }
                else
                {
                    Console.WriteLine("Erreur, index out of range, i= " + i);
                    return currNode;
                }
            }
            else
            {
                Console.WriteLine("Erreur, la liste est vide");
                return currNode;
            }
        }
        public int Count()
        {
            if (head != null)
            {
                Node<T> currNode = head;
                int retour = 1 ;
                while (currNode != tail)
                {
                    retour++;

                }
                return retour;
            }
            else
            {
                return 0;
            }
        }
    }
}
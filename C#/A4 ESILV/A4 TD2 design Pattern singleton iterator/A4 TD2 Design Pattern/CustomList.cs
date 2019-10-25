using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_TD2_Design_Pattern
{
    class CustomList<T> : Subject
    {
        public CustomNode<T> head;
        public CustomNode<T> tail;
        override public void Notify()
        {
            foreach (Observer observer in lstObservers)
            {
                observer.Update();
            }
        }
        public CustomList()
        {
            head = null;
            tail = null;
        }
        public T get(int index)
        {
            CustomNode<T> curNode = head;
            while (index > 0 && curNode != tail.next)
            {
                index--;
                curNode = curNode.next;
            }
            if (curNode == null)
            {
                Console.WriteLine("ERREUR CRITIQUE L'élément n'existe pas, le dernier élément de la liste en renvoyé");
                return tail.data;
            }
            return curNode.data;
        }
        public int count()
        {
            if (head == null)
            {
                return 0;
            }
            else
            {
                int result = 1;
                CustomNode<T> curNode = head;
                while (curNode != tail)
                {
                    result++;
                    curNode = curNode.next;
                }
                return result;
            }
        }
        public void add(T data)
        {
            if (head == null)
            {
                head = new CustomNode<T>(data);
                tail = head;
            }
            else if (tail == head)
            {
                tail = new CustomNode<T>(data);
                head.next = tail;
            }
            else
            {
                CustomNode<T> curNode = new CustomNode<T>(data);
                tail.next = curNode;
                tail = curNode;
            }
            Notify();
        }
        public void print()
        {
            if (head == null)
            {
                Console.WriteLine("La list est vide");
            }
            else
            {
                Console.WriteLine("Debut de la liste");
                CustomNode<T> curNode = head;
                while (curNode != tail)
                {
                    Console.WriteLine(curNode.data);
                    curNode = curNode.next;
                }
                Console.WriteLine(curNode.data);
                Console.WriteLine("fin de la liste");
            }
        }
        public void remove(int index)
        {
            {

                if (head == null)
                {
                    Console.WriteLine("La liste est deja vide");

                }
                else
                {
                    CustomNode<T> curNode = head;
                    while (index > 1 && curNode != tail.next)
                    {
                        index--;
                        curNode = curNode.next;
                    }
                    if (curNode == null)
                    {
                        Console.WriteLine("ERREUR CRITIQUE L'élément n'existe pas");
                    }
                    else if (head == tail)
                    {
                        head = null;
                    }
                    else if (curNode.next == tail)
                    {
                        Console.WriteLine("Cette donnée va etre supprimé " + curNode.next.data);
                        tail = curNode;
                        curNode.next = null;
                    }
                    else
                    {
                        Console.WriteLine("Cette donnée va etre supprimé " + curNode.next.data);
                        curNode.next = curNode.next.next;
                    }
                }

            }
            Notify();
        }
        public void change(int index, T data)
        {
            CustomNode<T> curNode = head;
            while (index > 0 && curNode != tail.next)
            {
                index--;
                curNode = curNode.next;
            }
            if (curNode == null)
            {
                Console.WriteLine("ERREUR CRITIQUE L'élément n'existe pas, l'élément est ajouté a la suite");
                add(data);
            }
            Console.WriteLine("L'élément data " + curNode.data + " de l'index " + index + " est remplacé par " + data);
            curNode.data = data;
            Notify();
        }

    }
}

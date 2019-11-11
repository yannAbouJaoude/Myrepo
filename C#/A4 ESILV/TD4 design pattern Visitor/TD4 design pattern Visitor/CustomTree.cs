using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_design_pattern_Visitor
{
    class CustomTree<T>
    {
        private List<Visitor<T>> whiteList;
        private Node<T> head;
        public CustomTree()
        {
            head = null;
            whiteList = new List<Visitor<T>>();
        }
        public void addVisitor(Visitor<T> a)
        {
            whiteList.Add(a);
        }
        public void removeVisitor(Visitor<T> a)
        {
            whiteList.Remove(a);
        }    
        private bool accept(Visitor<T> a)
        {
            if (whiteList.Contains(a))
            {
                return true;
            }
            return false;
        }
        public Node<T> get(int index, Visitor<T>alien)
        {

            if (accept(alien))
            {
                return get(index);
            }
            return null;
        }
        private Node<T> get(int index) {
            List<Node<T>> thislevel = new List<Node<T>>();
            thislevel.Add(head);
            int counter = -1;
            while (thislevel.Count != 0) {
                List<Node<T>> nextlevel = new List<Node<T>>();
                foreach (Node<T> node in thislevel) {
                    counter++;
                    if (index == counter)
                    {
                        return node;
                    }
                    if (node.next0 != null) {
                        nextlevel.Add(node.next0);
                    }

                    if (node.next1 != null)
                    {
                        nextlevel.Add(node.next1);
                    }
                }
                thislevel = nextlevel;
            }
            return null;
        }
        public Node<T> Add(T data)
        {
            if (head == null)
            {
                head = new Node<T>(data);
                return head;
            }
            List<Node<T>> thislevel = new List<Node<T>>();
            thislevel.Add(head);
            while (thislevel.Count != 0)
            {
                List<Node<T>> nextlevel = new List<Node<T>>();
                foreach (Node<T> node in thislevel)
                {
                    if (node.next0 != null)
                    {
                        nextlevel.Add(node.next0);
                    }
                    else
                    {
                        node.next0 = new Node<T>(data);
                        return node.next0;
                    }

                    if (node.next1 != null)
                    {
                        node.next1 = new Node<T>(data);
                        return node.next1;
                    }
                    else
                    {
                        node.next1 = new Node<T>(data);
                        return node.next1;
                    }
                }
                thislevel = nextlevel;
            }
            return null;
        }
        public int count()
        {
            return head.countChild();
        }

    }
}

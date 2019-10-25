using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3_POO_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercice5();
            Console.ReadKey();
        }

        static void Exercice1()
        {
            List<string> mots = new List<string>();
            string tmp = Console.ReadLine();
            while (tmp != ".") {
                mots.Add(tmp);
                tmp = Console.ReadLine();
            }
            for (int i = 0; i < mots.Count; i++)
            {
                Console.Write(mots[i] + " ");
            }
            Console.WriteLine(".");
        }
        static void Exercice2()
        {
            Stack<string> mots = new Stack<string>();
            string tmp = Console.ReadLine();
            while (tmp != ".")
            {
                mots.Push(tmp);
                tmp = Console.ReadLine();
            }
            exo2recur(mots);
            Console.WriteLine(".");
        }
        static void exo2recur(Stack<string> mots)
        {
            if (mots.Count > 0)
            {
                string tmp = mots.Pop();
                exo2recur(mots);
                Console.Write(tmp + " ");
            }
        }
        static void Exercice3()
        {
            Queue<string> mots = new Queue<string>();
            string tmp = Console.ReadLine();
            while (tmp != ".")
            {
                mots.Enqueue(tmp);
                tmp = Console.ReadLine();
            }
            while(mots.Count>0)
            {
                Console.Write(mots.Dequeue() + " ");
            }
            Console.WriteLine(".");
        }
        static void Exercice4()
        {
            Stack<int> nombres = new Stack<int>();
            string s = Console.ReadLine();
            int nb = 0;
            while (s != ".") { 
                if (int.TryParse(s, out nb))
                {
                    nombres.Push(nb);
                }
                else
                {
                    if (s == "+") { nombres.Push(nombres.Pop() + nombres.Pop()); }
                    else if (s == "-") { nombres.Push(nombres.Pop() - nombres.Pop()); }
                    else if (s == "*") { nombres.Push(nombres.Pop() * nombres.Pop()); }
                    else if (s == "/") {
                        int tmp = nombres.Pop();
                        nombres.Push(nombres.Pop() / 2);
                    }
                    Console.WriteLine(nombres.Peek());
                }
            s= Console.ReadLine();
            }
        }
        static void Exercice5()
        {
            LinkedList<int> a = new LinkedList<int>();
            a.AddHead(5);
            a.AddHead(6);
            a.AddQueue(7);
            a.Affiche();
            a.Insert(4, 1);
            a.Affiche();
            LinkedList<string> a1 = new LinkedList<string>();
            a1.AddHead("5");
            a1.AddHead("6");
            a1.AddQueue("7");
            a1.Affiche();
            a1.Insert("4", 1);
            a1.Affiche();
        }



    }
}

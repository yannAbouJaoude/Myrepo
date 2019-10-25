using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2_datascience
{
    class Program
    {
        static List<int>[] T = {
                new List<int>(new int[] {1,2,5 }),
                new List<int>(new int[] {1,3,5 }),
                new List<int>(new int[] {1,2 }),
                new List<int>(new int[] {1,2,3,4,5 }),
                new List<int>(new int[] {1,2,4,5 }),
                new List<int>(new int[] {2,3,5 }),
                new List<int>(new int[] {1,5 })
            };
        static void Main(string[] args)
        {
            List<List<elem>> result = Apriori(3);
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result[i].Count; j++)
                {
                    for (int k = 0; k < result[i][j].getList().Count; k++)
                    {
                        Console.Write(result[i][j].getList()[k] + " ");
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }       
        static List<List<elem>> Apriori(int epsilon)
        {
            List<elem> L1 = CreeL1(elementsUniques());
             List<elem> C1 = Prune(L1, epsilon);
           
            List<List<elem>> L = new List<List<elem>>();
            List<List<elem>> C = new List<List<elem>>();
            L.Add(L1);
            C.Add(C1);
            int k = 0;
            while (C[k].Count != 0)
            {
                k++;
                L.Add(Join(C[k - 1], C1));
                C.Add(Prune(L[k], epsilon));
            }
            return C;
        }
        static List<int> elementsUniques()
        {
            List<int> result = new List<int>();
            for (int i = 0; i < T.Length; i++)
            {
                for (int j = 0; j < T[i].Count; j++)
                {
                    if (!result.Contains(T[i][j]))
                    {
                        result.Add(T[i][j]);
                    }
                }
            }
            return result;
        }
        static List<elem> CreeL1(List<int> elementsUniques)
        {
            List<elem> L1 = new List<elem>();
            for (int i = 0; i < elementsUniques.Count; i++)
            {
                int somme = 0;
                for (int j = 0; j < T.Length; j++)
                {
                    if (T[j].Contains(elementsUniques[i]))
                    {
                        somme++;
                    }
                }
                List<int> b = new List<int>();
                b.Add(elementsUniques[i]);
                elem a = new elem(b, somme);
                L1.Add(a);
            }
            return L1;
        }
        static List<elem> Prune(List<elem> lk, int epsilon)
        {
            List<elem> Ck = new List<elem>();
            for (int i = lk.Count - 1; i >= 0; i--)
            {
                if (lk[i].getOccur() < epsilon)
                {
                    lk.RemoveAt(i);
                }
            }
            Ck = lk;
            return Ck;
        }
        static List<elem> Join(List<elem> Ck, List<elem> L1)
        {
            //on créé lk avec toute les combinaisons
            List<elem> Lk = new List<elem>();
            for (int i = 0; i < Ck.Count; i++)
            {
                for (int j = 0; j < L1.Count; j++)
                {                   
                    if (!Ck[i].getList().Contains(L1[j].getList()[0]))
                    {
                        elem tmp = new elem(Ck[i].getList());
                        tmp.getList().Add(L1[j].getList()[0]);
                        bool isInside = false;
                        for (int k = 0; k < Lk.Count; k++)
                        {
                            if (tmp.getList().All(Lk[k].getList().Contains))
                            {
                                isInside = true;
                            }
                        }
                        if (!isInside)
                        {
                            Lk.Add(tmp);
                        }
                    }
                }
            }
            // on retire les combinaisons impossibles
            for (int i = Lk.Count-1; i >= 0; i--)
            {
                bool oneOutside = false;
                for (int j = 0; j < Lk[i].getList().Count; j++)
                {
                    elem tmp = new elem(Lk[i].getList());
                    bool isInside = false;
                    tmp.getList().RemoveAt(j);
                    for (int k = 0; k < Lk.Count; k++)
                    {
                        if (tmp.getList().All(Lk[k].getList().Contains))
                        {
                            isInside = true;
                        }
                    }
                    if (!isInside)
                    {
                        oneOutside = true;
                    }
                }
                if (oneOutside)
                {
                    Lk.RemoveAt(i);
                }
            }
            for (int i = 0; i < Lk.Count; i++)
            {
                Lk[i].setOccur(T);
            }
            return Lk;
        }
    }
}

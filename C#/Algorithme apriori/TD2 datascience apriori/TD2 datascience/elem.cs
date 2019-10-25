using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2_datascience
{
    class elem
    {
        private List<int> list = new List<int>();
        private int occur;
        public elem(List<int>list,int occur)
        {
            this.occur = occur;
            for (int i = 0; i < list.Count; i++)
            {
                this.list.Add(list[i]);
            }           
        }
        public elem(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                this.list.Add(list[i]);
            }
        }
        public void setOccur(List<int>[] T)
        {
            occur = 0;
            for (int i = 0; i < T.Length; i++)
            {
                if (list.All(T[i].Contains))
                {
                    occur++;
                }
            }          
        }
        public int getOccur()
        {
            return occur;
        }
        public List<int> getList()
        {
            return list;
        }
    }
}

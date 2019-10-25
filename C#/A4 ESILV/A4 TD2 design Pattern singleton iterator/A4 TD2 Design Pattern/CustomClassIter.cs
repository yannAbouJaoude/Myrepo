using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_TD2_Design_Pattern
{
    class CustomListIter<T>
    {
        CustomList<T> t;
        int index;
        public CustomListIter(ref CustomList<T> s){
           t = s;
        }
        public void first()
        {
            index = 0;
        }
        public void next()
        {
            index++;
        }
        public bool isTheTail()
        {
             return index == t.count()-1;
        }
        public T currentItem()
        {
            return t.get(index);
        }
    }
}


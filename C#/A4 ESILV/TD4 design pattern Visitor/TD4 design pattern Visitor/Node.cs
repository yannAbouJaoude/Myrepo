using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_design_pattern_Visitor
{
    class Node<T>
    {
        public T data;
        public Node<T> next0;
        public Node<T> next1;

        public Node(T a)
        {
            data = a;
        }
        public int countChild()
        {
            return 1 +
                (next0 != null ? next0.countChild() : 0) +
                (next1 != null ? next1.countChild() : 0);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_TD2_Design_Pattern
{
    class CustomNode<T>
    {
        public T data;
        public CustomNode<T> next;

        public CustomNode(T a)
        {
            this.data = a;
        }
    }
}

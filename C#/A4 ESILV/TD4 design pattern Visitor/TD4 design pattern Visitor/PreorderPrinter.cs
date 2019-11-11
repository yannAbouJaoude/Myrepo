using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_design_pattern_Visitor
{
    class PreorderPrinter<T>:Visitor<T>
    {
        public PreorderPrinter() : base()
        {

        }
        protected override void rec(Node<T> root)
        {

            Console.Write(root.data);
            if (root.next0 != null)
            {
                rec(root.next0);
            }
            if (root.next1 != null)
            {
                rec(root.next1);
            }
        }
    }
}

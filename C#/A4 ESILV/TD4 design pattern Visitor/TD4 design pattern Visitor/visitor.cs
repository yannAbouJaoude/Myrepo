using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_design_pattern_Visitor
{
    abstract class Visitor<T>
    {
        protected Visitor()
        {

        }
        public void print(CustomTree<T> myTree) {
            try
            {
                rec(myTree.get(0, this));
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"{e.GetType().Name}: Ce visiteur n'a pas accès a cette arbre");
            }
        }
        protected abstract void rec(Node<T>root);
    }
}

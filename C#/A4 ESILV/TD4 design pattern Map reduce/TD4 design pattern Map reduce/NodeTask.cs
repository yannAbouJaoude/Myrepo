using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_design_pattern_Map_reduce
{
    abstract class NodeTask
    {
        public NodeTask(object data)
        {
            this.data = data;
        }

        public abstract void execute();

        protected object results;
        public object Results
        {
            get
            {
                return results;
            }
        }

        protected object data;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_design_pattern_Map_reduce
{
    class ClusterNode
    {
        public ClusterNode()
        {
            tasks = new List<NodeTask>();
        }

        public void execute()
        {
            foreach (NodeTask t in tasks)
                t.execute();
        }

        public List<object> Results
        {
            get
            {
                List<object> res = new List<object>();
                foreach (NodeTask t in tasks)
                    res.Add(t.Results);

                return res;
            }
        }

        private List<NodeTask> tasks;
        public List<NodeTask> Tasks
        {
            get
            {
                return tasks;
            }
            set
            {
                tasks = value;
            }
        }
    }
}

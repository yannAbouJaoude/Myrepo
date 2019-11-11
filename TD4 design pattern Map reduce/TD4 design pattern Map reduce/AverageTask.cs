using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_design_pattern_Map_reduce
{
    class AverageTask : NodeTask
    {
        private int n;
        public AverageTask(int[] matrix,int n) : base(matrix)
        {
            this.results = new Dictionary<int,double>();
            this.n = n;
        }
        public override void execute()
        {
            Dictionary<int, double> results = (Dictionary<int, double>)this.results;
            double average = 0;
            int[] row = (int[])this.data;
            int d = row.Length;
            foreach(int i in row)
            {
                average += i / d;
            }

            results[n] = average;
        }
    }
}

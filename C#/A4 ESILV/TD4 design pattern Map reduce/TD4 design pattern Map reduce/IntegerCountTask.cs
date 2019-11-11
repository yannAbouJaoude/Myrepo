using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_design_pattern_Map_reduce
{
    class IntegerCountTask : NodeTask
    {
        public IntegerCountTask(int[][] matrix) : base(matrix)
        {
            this.results = new Dictionary<int, int>();
        }

        public override void execute()
        {
            // Here we need to perform the integer counting
            int[][] matrix = (int[][])this.data;
            Dictionary<int, int> results = (Dictionary<int, int>)this.results;

            int rows = matrix.Length;
            int cols = matrix[0].Length;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int val = matrix[i][j];

                    if (results.ContainsKey(val))
                        results[val] = results[val] + 1;
                    else
                        results[val] = 1;
                }
            }
        }
}}

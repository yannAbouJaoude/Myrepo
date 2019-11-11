using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TD4_design_pattern_Map_reduce
{
    class Program
    {
        public static void Main()
        {
            /*
            int[][] matrix = new int[][] {
              new int[] {1, 1, 3, 5}, 
              new int[] {4, 5, 6},
              new int[] {7, 8, 9} };
            */
            Console.WriteLine("Generating random matrix...");
            int[][] matrix = GenerateRandomMatrix();
            Console.WriteLine("Generated.");

            Console.WriteLine("Doing MapReduce...");
            int rows = matrix.Length;
            ClusterNode[] nodes = new ClusterNode[rows];
            Thread[] t = new Thread[rows];

            exercice2(nodes, matrix, rows, t);
            Console.ReadKey();
        }

        private static void exercice2(ClusterNode[] nodes, int[][] matrix, int rows, Thread[] t)
        {
            // Map
            for (int i = 0; i < rows; i++)
            {
                int[] submatrix = matrix[i];
                nodes[i] = new ClusterNode();
                nodes[i].Tasks.Add(new AverageTask(submatrix, i));
                t[i] = new Thread(new ThreadStart(nodes[i].execute));
                t[i].Start();
            }

            // Here I need to wait all the threads to have ended
            foreach (Thread th in t)
                th.Join();

            // Here I am collecting all the results of each thread/node
            List<Dictionary<int, double>> results = new List<Dictionary<int, double>>();
            for (int i = 0; i < rows; i++)
                foreach (object d in nodes[i].Results)
                    results.Add((Dictionary<int, double>)d);

            // Reduce
            double final = MergeAverage(results, rows);

            Console.WriteLine("Voici la moyenne des valeurs du tableau " + final);

        }

        private static double MergeAverage(List<Dictionary<int, double>> dictionaries, int rows)
        {
            double result = 0;

            foreach (var dict in dictionaries)
                foreach (var x in dict)
                    result = result + (x.Value / rows);

            return result;
        }

        private static void exercice1(ClusterNode[] nodes, int[][] matrix, int rows, Thread[] t)
        {
            // Map
            for (int i = 0; i < rows; i++)
            {
                int[][] submatrix = { matrix[i] };
                nodes[i] = new ClusterNode();
                nodes[i].Tasks.Add(new IntegerCountTask(submatrix));
                t[i] = new Thread(new ThreadStart(nodes[i].execute));
                t[i].Start();
            }

            // Here I need to wait all the threads to have ended
            foreach (Thread th in t)
                th.Join();

            // Here I am collecting all the results of each thread/node
            List<Dictionary<int, int>> results = new List<Dictionary<int, int>>();
            for (int i = 0; i < rows; i++)
                foreach (object d in nodes[i].Results)
                    results.Add((Dictionary<int, int>)d);

            // Reduce
            Dictionary<int, int> final = MergeAndSum(results);

            // Print dictionary ordered by key  
            var list = final.Keys.ToList();
            list.Sort();

            // Loop through keys.
            foreach (var key in list)
            {
                Console.WriteLine("Key = {0}, Value = {1}", key, final[key]);
            }
        }

        private static Dictionary<int, int> MergeAndSum(List<Dictionary<int, int>> dictionaries)
        {
            var result = new Dictionary<int, int>();

            foreach (var dict in dictionaries)
                foreach (var x in dict)
                    if (result.ContainsKey(x.Key))
                        result[x.Key] = result[x.Key] + x.Value;
                    else
                        result[x.Key] = x.Value;

            return result;
        }

        private static int[][] GenerateRandomMatrix()
        {
            const int MAX_NUM = 1000;

            Random random = new Random();

            int rows = random.Next(0, MAX_NUM);
            int cols = random.Next(0, MAX_NUM);

            Console.WriteLine("Generating a matrix of size {0} x {1}", rows, cols);
            int[][] matrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
                for (int j = 0; j < cols; j++)
                    matrix[i][j] = random.Next(0, MAX_NUM);
            }

            return matrix;
        }
    }
}

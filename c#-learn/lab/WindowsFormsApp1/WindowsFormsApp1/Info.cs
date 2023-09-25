using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Info
    {
        public int[,] matrix { get; set; }
        public int[,] matrixOfDifferentPathes { get; set; }
        public int[] arrayOfIndexes { get; set; }
        public int pathLength { get; set; }

        public Info(int[,] matrix, int[,] matrixOfDifferentPathes, int[] arrayOfIndexes, int pathLength)
        {
            this.matrix = matrix;
            this.matrixOfDifferentPathes = matrixOfDifferentPathes;
            this.arrayOfIndexes = arrayOfIndexes;
            this.pathLength = pathLength;
        }

        public static void Fillmatrix(int[,] matrix)
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        int check = random.Next(0, 6);
                        if (0 <= check && check < 4)
                        {
                            matrix[i, j] = random.Next(10, 51);
                        }

                    }
                }
            }
        }
    }
}

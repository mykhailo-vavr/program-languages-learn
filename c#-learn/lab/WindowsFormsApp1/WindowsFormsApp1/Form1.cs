using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Dimention_TextChanged(object sender, EventArgs e)
        {
            if(Dimention.Text != String.Empty && initialNode.Text != String.Empty && terminalNode.Text != String.Empty)
            {
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label41.Text = string.Empty;
            label42.Text = string.Empty;
            res1.Text = string.Empty;
            res2.Text = string.Empty;
            shortestPath.Text = string.Empty;

            int dimention = Int32.Parse(Dimention.Text);
            int initNode = Int32.Parse(initialNode.Text);
            int termNode = Int32.Parse(terminalNode.Text);

            var matrix = new int[dimention, dimention];
            Info.Fillmatrix(matrix);
            var secondMatrix = (int[,])matrix.Clone();
            label42.Text += "Для паралельного виконання:\n";
            res2.Text += "Паралельне: \n";
            PrintParallelMatrix(matrix);
            DijkstraParallel(matrix);

            label41.Text += "Для послідовного виконання:\n";
            res1.Text += "Послідовне: \n";
            PrintMatrix(secondMatrix);
            Dijkstra(secondMatrix);

            shortestPath.Text += "Найкоротший шлях: ";
            var value = secondMatrix[initNode-1, termNode-1];
            shortestPath.Text += value.ToString();

            label41.Visible = true;
            label42.Visible = true;
            res1.Visible = true;
            res2.Visible = true;
            shortestPath.Visible = true;
        }

        public void DijkstraParallel(int[,] matrix)
        {
            var before = DateTime.Now;
            var resMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int p = 0; p < matrix.GetLength(0); p++)
            {
                var arrayOfIndexes = new int[matrix.GetLength(0)];
                var matrixOfDifferentPathes = new int[matrix.GetLength(0), matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrixOfDifferentPathes[0, j] = matrix[p, j];
                }

                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    Info info = new Info(matrix, matrixOfDifferentPathes, arrayOfIndexes, i);
                    Parallel.Invoke(() => ShortestPatForCurrentNode(info));
                }
                var shortestPath = new int[matrixOfDifferentPathes.GetLength(0)];
                for (int i = 0; i < matrixOfDifferentPathes.GetLength(0); i++)
                {
                    if (i != p)
                    {
                        int temp = 1000;
                        for (int j = 0; j < matrixOfDifferentPathes.GetLength(1); j++)
                        {
                            if (matrixOfDifferentPathes[j, i] != 0 && matrixOfDifferentPathes[j, i] < temp)
                                temp = matrixOfDifferentPathes[j, i];
                        }
                        if (temp == 1000)
                            temp = 0;
                        shortestPath[i] = temp;
                    }
                }
                for (int i = 0; i < shortestPath.Length; i++)
                {
                    Console.Write(shortestPath[i] + " ");
                    resMatrix[p, i] = shortestPath[i];
                }
            }
            var after = DateTime.Now;
            label42.Text += "Time:";
            label42.Text += after - before;
            label42.Text += "\n\n";
            PrintParallelMatrix(resMatrix);
            matrix = (int[,])resMatrix.Clone();
        }

        public void Dijkstra(int[,] matrix)
        {
            var before = DateTime.Now;
            var resMatrix = new int[matrix.GetLength(0), matrix.GetLength(1)];
            for (int p = 0; p < matrix.GetLength(0); p++)
            {
                var arrayOfIndexes = new int[matrix.GetLength(0)];
                var matrixOfDifferentPathes = new int[matrix.GetLength(0), matrix.GetLength(0)];
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrixOfDifferentPathes[0, j] = matrix[p, j];
                }

                for (int i = 0; i < matrix.GetLength(0) - 1; i++)
                {
                    Info info = new Info(matrix, matrixOfDifferentPathes, arrayOfIndexes, i);
                    ShortestPatForCurrentNode(info);
                }

                var shortestPath = new int[matrixOfDifferentPathes.GetLength(0)];
                for (int i = 0; i < matrixOfDifferentPathes.GetLength(0); i++)
                {
                    if (i != p)
                    {
                        int temp = 1000;
                        for (int j = 0; j < matrixOfDifferentPathes.GetLength(1); j++)
                        {
                            if (matrixOfDifferentPathes[j, i] != 0 && matrixOfDifferentPathes[j, i] < temp)
                                temp = matrixOfDifferentPathes[j, i];
                        }
                        if (temp == 1000)
                            temp = 0;
                        shortestPath[i] = temp;
                    }
                }
                for (int i = 0; i < shortestPath.Length; i++)
                {
                    Console.Write(shortestPath[i] + " ");
                    resMatrix[p, i] = shortestPath[i];
                }
            }
            var after = DateTime.Now;
            label41.Text += "Time:";
            label41.Text += after - before;
            label41.Text += "\n\n";
            PrintMatrix(resMatrix);
        }


        public void ShortestPatForCurrentNode(object obj)
        {
            Info info = (Info)obj;
            var matrix = info.matrix;
            var matrixOfDifferentPathes = info.matrixOfDifferentPathes;
            var arrayOfIndexes = info.arrayOfIndexes;
            var indexOfCurrentNode = info.pathLength;
            var tempVector = new int[matrix.GetLength(0)];
            int currentMinValue = 0;
            var indexOfCurrentMin = -1;
            for (int k = 0; k < matrix.GetLength(0); k++)
            {
                tempVector[k] = matrixOfDifferentPathes[indexOfCurrentNode, k];
            }

            bool chack = false;
            for (int j = 0; j < 4; j++)
            {
                if (tempVector[j] != 0)
                    chack = true;
            }

            if (chack != false)
            {
                currentMinValue = tempVector.Where(x => x > 0).Min(x => x);
                indexOfCurrentMin = Array.IndexOf(tempVector, currentMinValue);
                int uniqueMinValue = currentMinValue;

                if (arrayOfIndexes.Where(x => x != 0).Any())
                    uniqueMinValue = tempVector.Where(x => x > 0 && Array.IndexOf(tempVector, x) != arrayOfIndexes[indexOfCurrentMin]).Min(x => x);
                else if (currentMinValue != uniqueMinValue)
                    indexOfCurrentMin = Array.IndexOf(tempVector, uniqueMinValue);
           
                arrayOfIndexes[indexOfCurrentMin] = indexOfCurrentMin;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[indexOfCurrentMin, j] != 0)
                        matrixOfDifferentPathes[indexOfCurrentNode + 1, j] = matrix[indexOfCurrentMin, j] + matrixOfDifferentPathes[indexOfCurrentNode, indexOfCurrentMin];
                    else
                    {
                        if (j != indexOfCurrentMin)
                            matrixOfDifferentPathes[indexOfCurrentNode + 1, j] = matrixOfDifferentPathes[indexOfCurrentNode, j];
                    }
                }
                Thread.Sleep(1);
            }
        }

        public void PrintParallelMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        res2.Text += (matrix[i, j] + "  ");
                    else
                        res2.Text += (matrix[i, j] + " ");
                }
                res2.Text += "\n";
            }
            res2.Text += "\n\n";
        }

        public void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        res1.Text += (matrix[i, j] + "  ");
                    else
                        res1.Text += (matrix[i, j] + " ");
                }
                res1.Text += "\n";
            }
            res1.Text += "\n\n";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl is TextBox)
                {
                    (ctrl as TextBox).TextChanged += Dimention_TextChanged;
                }
            }
        }

        private void terminalNode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void res2_Click(object sender, EventArgs e)
        {

        }
    }
}

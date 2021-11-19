using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_console_app
{
    public class Matrix
    {
        private int[,] _matrix;
        int counter = 1;

        public Matrix(int size)
        {
           _matrix = new int[size,size];
           for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = counter;
                    counter++;
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                Console.WriteLine("   |   |   ");
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (j != _matrix.GetLength(1) - 1)
                    {
                        Console.Write($" {_matrix[i, j]} |");
                    }
                    else
                    {
                        Console.Write($" {_matrix[i, j]} ");
                    }
                }
                if (i != _matrix.GetLength(0) - 1)
                {
                    Console.WriteLine("\n___|___|___");
                }
                else
                {
                    Console.WriteLine("\n   |   |   ");
                }
            }
        }
    }
}

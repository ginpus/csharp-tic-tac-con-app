using System;
using System.Text.RegularExpressions;

namespace simple_console_app
{
    internal class Program
    {
        private static string[,] matrix =
            {
                {"1","2","3"},
                {"4","5","6"},
                {"7","8","9"}
            };

        private static bool gameNotOver = true;
        private static int counter = 1;
        private static int player;
        private static string marker;
        private static string rawSelector;
        private static int selector;
        private static bool round;
        private static int markerValue;
        private static bool intermediate;
        private static int diagonal;
        private static int diagonalOposite;
        private static int horizontal1;
        private static int horizontal2;
        private static int horizontal3;
        private static int vertical1;
        private static int vertical2;
        private static int vertical3;

        private static void Main(string[] args)
        {
            //Matrix matrix2 = new Matrix(3);

            while (gameNotOver)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    Console.WriteLine("   |   |   ");
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (j != matrix.GetLength(1) - 1)
                        {
                            Console.Write($" {matrix[i, j]} |");
                        }
                        else
                        {
                            Console.Write($" {matrix[i, j]} ");
                        }
                    }
                    if (i != matrix.GetLength(0) - 1)
                    {
                        Console.WriteLine("\n___|___|___");
                    }
                    else
                    {
                        Console.WriteLine("\n   |   |   ");
                    }
                }

                //matrix2.Print();

                Console.WriteLine();
                if (counter % 2 == 1)
                {
                    player = 1;
                    marker = "X";
                }
                else
                {
                    player = 2;
                    marker = "O";
                }
                do
                {
                    diagonal = 0;
                    diagonalOposite = 0;
                    horizontal1 = 0;
                    horizontal2 = 0;
                    horizontal3 = 0;
                    vertical1 = 0;
                    vertical2 = 0;
                    vertical3 = 0;
                    Console.Write($"Player {player}:");
                    rawSelector = Console.ReadLine();
                    int.TryParse(rawSelector, out selector);

                    if (selector >= 1 && selector <= 9) // checking if selector is within the possible range at all
                    {
                        foreach (var item in matrix)
                        {
                            int.TryParse(item, out markerValue);
                            if (markerValue == selector) // checking if selected value equals to value that is (still) existent in the matrix
                            {
                                intermediate = true;
                                break;
                            }
                            else
                            {
                                intermediate = false;
                            }
                        }
                        if (intermediate)
                        {
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    int.TryParse(matrix[i, j], out markerValue);
                                    if (selector == markerValue)
                                    {
                                        matrix[i, j] = marker;
                                        counter++;
                                        Console.Clear();
                                        round = false;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Selection is occupied. Press any key to retry");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid. Enter the value visible. Press any key to retry");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    if (counter >= (2 * matrix.GetLength(0)) - 1) // if there were 5 or more moves made, check if there is a winner
                    {
                        for (int i = 0; i < matrix.GetLength(0); i++)
                        {
                            if (marker == matrix[i, i])
                            {
                                diagonal++;
                            };
                            if (marker == matrix[i, matrix.GetLength(0) - 1 - i])
                            {
                                diagonalOposite++;
                            };
                            if (marker == matrix[0, i])
                            {
                                horizontal1++;
                            };
                            if (marker == matrix[1, i])
                            {
                                horizontal2++;
                            };
                            if (marker == matrix[2, i])
                            {
                                horizontal3++;
                            };
                            if (marker == matrix[i, 0])
                            {
                                vertical1++;
                            };
                            if (marker == matrix[i, 1])
                            {
                                vertical2++;
                            };
                            if (marker == matrix[i, 2])
                            {
                                vertical3++;
                            };
                        }
                        if (diagonal == 3 || diagonalOposite == 3 || horizontal1 == 3 || horizontal2 == 3 || horizontal3 == 3 || vertical1 == 3 || vertical2 == 3 || vertical3 == 3)
                        {
                            Console.Write($"Player {player} won!");
                            Console.ReadKey();
                            gameNotOver = false;
                        }
                        else if (counter == matrix.Length + 1)
                        {
                            Console.Write("It is a draw!");
                            Console.ReadKey();
                            gameNotOver = false;
                        }
                    }
                } while (round);
            }
        }
    }
}

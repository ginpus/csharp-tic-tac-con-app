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

            /*            string myString;
                        char myChar;
                        Console.WriteLine("Enter a string here:");
                        myString = Console.ReadLine();
                        Console.WriteLine("Enter a string here:");
                        myChar = Console.ReadLine()[0];
                        Console.WriteLine(myString.IndexOf(myChar));
                        Console.WriteLine();*/
            /*            double num1 = double.Parse(Console.ReadLine()) ;
                        double num2 = double.Parse(Console.ReadLine());
                        double result;
                        try
                        {
                            result = num1 / num2;
                            Console.WriteLine(result);
                        }
                        catch (Exception)
                        {
                            throw;
                        }*/
            /*            int score;
                        int sum = 0;
                        int counter = 0;

                        while (counter < 20) {
                        Console.WriteLine("enter the score from 0 to 20");
                        bool success = int.TryParse(Console.ReadLine(), out score);

                        if (!success && score < -1 && score > 20)
                        {
                            Console.WriteLine("Invalid score");
                                continue;
                        }
                        else if (score == -1)
                        {
                            break;
                        }
                            else
                            {
                                sum += score;
                                counter++;
                            }
                        }
                        Console.WriteLine($"Average is: {sum/counter}");
                        Console.WriteLine("this is the end");*/
            /*            Console.WriteLine("Enter a value: ");
                        var myValue = Console.ReadLine();
                        Console.WriteLine("Select the Data type to validate the input you have entered.");
                        Console.WriteLine("Press 1 for String");
                        Console.WriteLine("Press 2 for Integer");
                        Console.WriteLine("Press 3 for Boolean");
                        var selection = Console.ReadLine();
                        switch (selection)
                        {
                            case "1":
                                Console.WriteLine($"You have entered a value: {myValue}");
                                try
                                {
                                    var result = Regex.IsMatch(myValue, @"^[a-zA-Z-_\s]+$");
                                    if (result)
                                    {
                                        Console.WriteLine("It is a valid: String");
                                    }
                                    else
                                    {
                                        Console.WriteLine("It is an invalid: String");
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("It is an invalid: String") ;
                                }
                                break;

                            case "2":
                                try
                                {
                                    var result = int.Parse(myValue);
                                    Console.WriteLine("It is a valid: Integer");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("It is an invalid: Integer"); ;
                                }
                                break;

                            case "3":
                                try
                                {
                                    var result = bool.Parse(myValue);
                                    Console.WriteLine("It is a valid: Boolean");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("It is an invalid: Boolean"); ;
                                }
                                break;

                            default:
                                Console.WriteLine("No such selection");
                                break;
                        }*/
        }
    }
}
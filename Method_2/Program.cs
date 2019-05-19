using System;

namespace Laba2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            double[,] matrix = new double[,] { {  3.4, 1.1,  0.2, -1.2,   2},
                                               { -0.7, 3.3, -0.3,    2, 1.9},
                                               {  0.4, 0.3,  2.6,  0.2, -0.4},
                                               { -0.2, 0.6,  0.4,  1.7, -6.5}  };
            //Имеется диагональное преобладание

            ShowMatrix(matrix);

            StepTwo(matrix);   // Переносим все кроме нужных х 
            ShowMatrix(matrix);// в правую часть и делим на коэффициент

            StepThree(matrix); // Проверка сходимости
            StepFour(matrix);  // Считаем корни

        }

        public static void ShowMatrix(double[,] matrix)
        {
            Console.WriteLine("Текущая матрица:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(matrix[i, j]);
                    if (matrix[i, j] == matrix[i, i])
                        Console.Write("\t\t\t");
                    else
                        Console.Write("\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static double[,] StepTwo(double[,] matrix)  // Переносим все                                                 
        {                                                  // кроме нужных х                                                 
            for (int i = 0; i < 4; i++)                    // в правую часть 
            {                                              // и делим на коэффициент
                for (int j = 0; j < 5; j++)
                {
                    if (i != j)
                    {
                        matrix[i, j] /= matrix[i, i];
                        if (j != 4)
                            matrix[i, j] /= -1;
                    }

                }
                matrix[i, i] /= matrix[i, i];
            }

            return matrix;
        }

        public static void StepThree(double[,] matrix)  // Проверим сходимость
        {
            double G = 0;
            double gCurrent;

            for (int i = 0; i < 4; i++)
            {
                gCurrent = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (i != j)
                        gCurrent += Math.Abs(matrix[i, j]);
                }

                if (gCurrent > G)
                    G = gCurrent;
            }

            Console.Write("Сходимость = ");
            Console.Write(G);
            //Console.WriteLine("\n");

        }

        public static void StepFour(double[,] matrix)  // Считаем корни
        {
            double[,] result = new double[2, 4];
            result[0, 0] = matrix[0, 4];
            result[0, 1] = matrix[1, 4];
            result[0, 2] = matrix[2, 4];
            result[0, 3] = matrix[3, 4];

            result[1, 0] = 0;
            result[1, 0] = 0;
            result[1, 0] = 0;
            result[1, 0] = 0;

            bool end = true;

            while (end)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i != j)
                        {
                            result[1, i] = result[1, i] + matrix[i, j] * result[0, j];
                        }
                    }
                    result[1, i] += matrix[i, 4];
                }

                if (result[1, 0] - result[0, 0] <= 0.001 &&
                    result[1, 1] - result[0, 1] <= 0.001 &&
                    result[1, 2] - result[0, 2] <= 0.001 &&
                    result[1, 3] - result[0, 3] <= 0.001)
                    end = false;

                for (int i = 0; i < 4; i++)
                {
                    result[0, i] = result[1, i];
                    result[1, i] = 0;
                }

                //for (int i = 0; i < 4; i++)
                //{
                //    Console.Write(result[0, i]);
                //    Console.Write("\t");
                //}

                //Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
            // подстановка в 3 уранение
            Console.WriteLine("Подставим корни в 3 уравнение получим приблизительный результат {0}", 0.4 * result[0, 0] + 0.3 * result[0, 1] + 2.6 * result[0, 2] + 0.2 * result[0, 3]); 
        }
    }
}
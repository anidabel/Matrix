using System;

namespace Matrix
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("\n Для упрощения работы вывода матриц, они будут во многих примерах квадратными с фиксированной размерностью\n\n");
                Console.WriteLine("\n Задание матрицы A \n");
                int n = 4;
                Matrix A = new Matrix(new double[n, n]);
                A.SetRandMatr();
                A.Show();
                Console.WriteLine("\n Задание матрицы В\n");
                Matrix B = new Matrix(new double[n, n]);
                B.SetRandMatr();
                B.Show();
                Console.WriteLine("Сравнение матриц А и В");
                if (A == B)
                    Console.WriteLine("     Матрицы равны");
                else
                    Console.WriteLine("     Матрицы не равны");
                Console.WriteLine("Создадим матрицу С равную матрице А и сравним их");
                Matrix C = new Matrix(A);
                if (C == A)
                    Console.WriteLine("     Матрицы равны");
                else
                    Console.WriteLine("     Матрицы не равны");
                Console.WriteLine("Произведем различные проверки матрицы А, используя реализованные нами методы");
                if (A.Squared())
                    Console.WriteLine("     Матрица квадратная");
                else
                    Console.WriteLine("     Матрица не квадратная");
                if (A.Diagonal())
                    Console.WriteLine("     Матрица диагональная");
                else
                    Console.WriteLine("     Матрица не диагональная");
                if (A.Zero())
                    Console.WriteLine("     Матрица нулевая");
                else
                    Console.WriteLine("     Матрица не нулевая");
                if (A.One())
                    Console.WriteLine("     Матрица единичная");
                else
                    Console.WriteLine("     Матрица не единичная");
                if (A.Simmetr())
                    Console.WriteLine("     Матрица симметричная");
                else
                    Console.WriteLine("     Матрица не симметричная");
                if (A.VTr())
                    Console.WriteLine("     Матрица верхняя треугольная");
                else
                    Console.WriteLine("     Матрица не верхняя треугольная");
                if (A.NTr())
                    Console.WriteLine("     Матрица нижняя треугольная");
                else
                    Console.WriteLine("     Матрица не нижняя треугольная");
                Console.WriteLine("     Найдём сумму матриц А и В");
                (A + B).Show();
                Console.WriteLine("     Найдём произведение матриц А и В");
                (A * B).Show();
                Console.WriteLine("     Найдём разницу матриц А и В");
                (A - B).Show();
                Console.WriteLine("     Найдём произведение матрицы А на 2");
                (A * 2).Show();
                Console.WriteLine("     Найдём частное матрицы А и 5");
                (A / 5).Show();
                Console.WriteLine("\n\nПрограмма заврешила свою работу!\n\n");
            }
            catch
            {
                Console.WriteLine("Возникло исключение!");
            }

        }
    }
}

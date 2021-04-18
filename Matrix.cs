using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix
{
    public class Matrix
    {
        private int KolN;
        private int KolM;
        private double[,] mat;

        public void SetRandMatr()
        {
            Random rand = new Random();
            for (int i = 0; i < GetKolN; i++)
                for (int j = 0; j < GetKolN; j++)
                    mat[i, j] = rand.NextDouble();
        }
        public void SetKolN(int n)
        {
            KolN = n;
        }
        public void SetKolM(int m)
        {
            KolM = m;
        }
        public int GetKolN
        {
            get { return KolN; }
        }
        public int GetKolM
        {
            get { return KolM; }
        }
        public double GetElem(int i, int j)
        {
            return mat[i, j];
        }
        public Matrix(int n, int m)
        {
            this.KolN = n;
            this.KolM = m;
            this.mat = new double[n, m];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    mat[i, j] = 0.0;
        }
        public Matrix(double[,] matr)
        {
            this.KolN = matr.GetLength(0);
            this.KolM = matr.GetLength(1);
            this.mat = matr;
        }
        public Matrix(Matrix m)
        {
            KolN = m.GetKolN;
            KolM = m.GetKolM;
            mat = m.mat;
        }
        public double this[int n, int m]
        {
            get
            {
                if (n < 0 || n > KolN || m < 0 || m > KolM)
                    throw new Exception("Выход за границы матрицы");
                return mat[n, m];
            }
            // set { mat[n, m] = value; }
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (!Matrix.CompareSum(m1, m2))
                throw new Exception("Невозможно проссумировать матрицы");
            Matrix Res = new Matrix(m1.GetKolN, m1.GetKolM);
            for (int i = 0; i < m1.GetKolN; i++)
                for (int j = 0; j < m1.GetKolM; j++)
                    Res.mat[i, j] = m1[i, j] + m2[i, j];
            return Res;
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (!Matrix.CompareSum(m1, m2))
                throw new Exception("Невозможно проссумировать матрицы");
            Matrix Res = new Matrix(m1.GetKolN, m1.GetKolM);
            for (int i = 0; i < m1.GetKolN; i++)
                for (int j = 0; j < m1.GetKolM; j++)
                    Res.mat[i, j] = m1[i, j] - m2[i, j];
            return Res;
        }
        public static Matrix operator *(Matrix m, double d)
        {
            Matrix res = new Matrix(m.GetKolN, m.GetKolM);
            for (int i = 0; i < m.GetKolN; i++)
                for (int j = 0; j < m.GetKolM; j++)
                    res.mat[i, j] = m[i, j] * d;
            return res;
        }
        public static Matrix operator *(double d, Matrix m)
        {
            Matrix res = m * d;
            return res;
        }
        public static Matrix operator /(Matrix m, double d)
        {
            if (d == 0)
                throw new Exception("Деление на ноль");
            Matrix res = new Matrix(m.GetKolN, m.GetKolM);
            for (int i = 0; i < m.GetKolN; i++)
                for (int j = 0; j < m.GetKolM; j++)
                    res.mat[i, j] = m.mat[i, j] / d;
            return res;
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.GetKolM != m2.GetKolN)
                throw new Exception("Умножение матриц друг на друга невозможно");
            double tmp;
            Matrix res = new Matrix(m1.GetKolN, m2.GetKolM);
            for (int i = 0; i < m1.GetKolN; i++)
                for (int j = 0; j < m2.GetKolM; j++)
                {

                    tmp = res.mat[i, j];
                    for (int k = 0; k < res.GetKolN; k++)
                        tmp += m1[i, k] * m2[k, j];
                    res.mat[i, j] = tmp;
                }
            return res;
        }
        public static bool CompareSum(Matrix m1, Matrix m2)
        {
            if (m1.GetKolN == m2.GetKolN && m1.GetKolN == m2.GetKolM)
                return true;
            else
                return false;
        }
        public bool Squared() //квадратная
        {
            if (KolN == KolM)
                return true;
            else
                return false;
        }
        public bool Diagonal() //диагональная
        {
            if (!this.Squared())
                return false;
            for (int i = 0; i < KolN; i++)
                for (int j = 0; j < KolM; i++)
                    if (this[i, j] != 0 && i != j)
                        return false;
            return true;
        }
        public bool Zero()   //нулевая
        {
            for (int i = 0; i < KolN; i++)
                for (int j = 0; j < KolM; j++)
                    if (this[i, j] != 0)
                        return false;
            return true;
        }
        public bool One() //единичная
        {
            for (int i = 0; i < KolN; i++)
                for (int j = 0; j < KolM; j++)
                    if (this[i, j] != 1)
                        return false;
            return true;
        }
        public bool Simmetr()   //симметричная
        {
            if (!this.Squared())
                return false;
            for (int i = 0; i < KolN; i++)
                for (int j = 0; j < KolM; j++)
                    if (this[i, j] != this[j, i])
                        return false;
            return true;
        }
        public bool VTr()   //верхняя треугольная
        {
            if (!this.Squared())
                return false;
            for (int i = 1; i < KolN; i++)
                for (int j = 0; j < i; j++)
                    if (this[i, j] != 0)
                        return false;
            return true;
        }
        public bool NTr()     //нижняя треугольная
        {
            if (!this.Squared())
                return false;
            for (int i = 0; i < KolN - 1; i++)
                for (int j = i + 1; j < KolM; j++)
                    if (this[i, j] != 0)
                        return false;
            return true;
        }
        public static bool operator ==(Matrix m1, Matrix m2)  //сравнение на равенство 
        {
            if (m1.GetKolM != m2.GetKolM || m1.GetKolN != m2.GetKolN)
                return false;
            for (int i = 0; i < m1.GetKolN; i++)
                for (int j = 0; j < m1.GetKolM; j++)
                    if (m1[i, j] != m2[i, j])
                        return false;
            return true;
        }
        public static bool operator !=(Matrix m1, Matrix m2)   // не равенство
        {
            if (m1 == m2)
                return false;
            else
                return true;
        }
        public void Show()
        {
            for (int i = 0; i < KolN; i++)
            {
                for (int j = 0; j < KolM; j++)
                    Console.Write("\t" + this[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine("\n\n");
        }
    }
}

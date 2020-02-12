using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_Matrix
{
    class Matrix
    {

        public double[,] Values { get; set; }
        public int Rows { get; private set; }
		public int Columns { get; private set; }
		public readonly static Matrix NullMatrix = new Matrix(1, 1);


        public Matrix(double[,] data)
        {
            Rows = data.GetLength(0);
            Columns = data.GetLength(1);
            Values = new double[Rows, Columns];
            Values = (double[,])data.Clone();


        }
        public Matrix(int _Rows, int _Columns)
        {
            Rows = _Rows;
            Columns = _Columns;
            Values = new double[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Values[i, j] = 0;
                }
            }
        }
        public Matrix(int _Rows, int _Columns, int[] data)
        {
            if (data.Length != _Rows * _Columns)
            {
				throw new ArgumentException("Incorrect data, some values are missed");
			}

            Rows = _Rows;
            Columns = _Columns;
            Values = new double[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Values[i, j] = data[Columns * i + j];
                }
            }
        }
        public Matrix(string fileName)
        {
            string[] str = File.ReadAllLines(fileName);
            Rows = str.Length;
            string[] st = str[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Columns = st.Length;
            int ColPrev = Columns;

            Values = new double[Rows, Columns];
            for (int i = 0; i < Rows; i++)
            {
                if (Columns != ColPrev) { throw new ArgumentException("Incorrect data, some values are missed"); }
                st = str[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Columns = st.Length;
                for (int j = 0; j < Columns; j++)
                {
                    Values[i, j] = Convert.ToDouble(st[j]);
                }
                ColPrev = Columns;
            }
        }

        public void SaveToFile(string fileName)
        {
            string st = this.ToString();
            File.WriteAllText(fileName, st);
        }


        public override string ToString()
        {

            string str = "";
            if (this == null) return str;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    str += this[i, j].ToString() + "    ";
                }
                str += "\n";
            }
            return str;
        }
        public override bool Equals(object obj)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (this[i, j] != (obj as Matrix)[i, j])
                        return false;
                }
            }
            return true;
        }


        public static Matrix operator +(Matrix A, Matrix B)
        {
			if (A is null || B is null) throw new ArgumentNullException();
			Matrix C = new Matrix(A.Values);
            if (C.Rows != B.Rows || C.Columns != B.Columns)
            { MessageBox.Show("Sorry, we can`t add this matrix", "Incorrect matrix!"); return null; }

            for (int i = 0; i < C.Rows; i++)
            {
                for (int j = 0; j < C.Columns; j++)
                {
                    C[i, j] += B[i, j];
                }
            }
            return C;
        }

        public static Matrix operator -(Matrix A, Matrix B)
        {
			if (A is null || B is null) throw new ArgumentNullException();
			Matrix C = new Matrix(A.Values);
            if (C.Rows != B.Rows || C.Columns != B.Columns)
            { MessageBox.Show("Sorry, we can`t add this matrix", "Incorrect matrix!"); return null; }

            for (int i = 0; i < C.Rows; i++)
            {
                for (int j = 0; j < C.Columns; j++)
                {
                    C.Values[i, j] -= B.Values[i, j];
                }
            }
            return C;
        }

        public static Matrix operator *(Matrix A, int num)
        {
			if (A is null) throw new ArgumentNullException();
            Matrix C = new Matrix(A.Values);

            for (int i = 0; i < C.Rows; i++)
            {
                for (int j = 0; j < C.Columns; j++)
                {
                    C[i, j] *= num;
                }
            }
            return C;
        }

		public double this[int i, int j]
		{
			get
			{
				if (i < Rows && j < Columns && i > 0 && j > 0)
					return this.Values[i, j];
				else
					throw new IndexOutOfRangeException();
			}
			set
			{
				if (i < Rows && j < Columns && i > 0 && j > 0)
					this.Values[i, j] = value;
				else
					throw new IndexOutOfRangeException();
			}
		}
        public virtual Matrix AddMatrix(Matrix A)
        {
			if (A is null) throw new ArgumentNullException();
			if (Rows != A.Rows || Columns != A.Columns)
			     throw new ArgumentException("Wrong matrix size"); 

            Matrix B = new Matrix(A.Values);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    B[i, j] += Values[i, j];
                }
            }
            return B;
        }
        public virtual Matrix MinusMatrix(Matrix A)
        {
			if (A is null) throw new ArgumentNullException();
			if (Rows != A.Rows || Columns != A.Columns)
				throw new ArgumentException("Wrong matrix size"); 

			Matrix B = new Matrix(A.Values);
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    B[i, j] -= Values[i, j];
                }
            }
            return B;
        }
        public virtual Matrix MultipleTo(double C)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Values[i, j] *= C;
                }
            }
            return this;
        }
        /// <summary>
        /// Умножение матриц. Необходимо что бы размерность по Х 
        /// начальной матрицы совпадала с размерностью по У матрицЫ, на которую умножают.
        /// </summary>
        /// <param name="A">Матрица, на которую умножают</param>
        /// <returns></returns>
        public virtual Matrix MultipleMatrix(Matrix A)
        {
			if (A is null) throw new ArgumentNullException();
			if (Columns != A.Rows)
			{ throw new ArgumentException("Wrong matrix size"); }

			double sum = 0;
            Matrix C = new Matrix(Rows, A.Columns);
            for (int i = 0; i < Rows; i++)
            {

                for (int j = 0; j < A.Columns; j++)
                {
                    for (int p = 0; p < Columns; p++)
                    {
                        sum += Values[i, p] * A[p, j];
                    }
                    C[i, j] = sum;
                    sum = 0;
                }
            }
            return C;
        }

        public double Determinant()
        {

            if (Columns != Rows)
			{ throw new ArgumentException("Wrong matrix size"); }
			double det = 1;
            double EPS = 0.00000001;

            double[,] b1 = new double[1, Rows];

            for (int i = 0; i < Rows; ++i)
            {
                int k = i;
                for (int j = i + 1; j < Rows; ++j)
                {
                    if (Math.Abs(Values[j, i]) > Math.Abs(Values[k, i]))
                    {
                        k = j;
                    }
                }

                //если равенство выполняется то определитель приравниваем 0 и выходим из функции
                if (Math.Abs(Values[k, i]) < EPS)
                {
                    return det = 0;
                }
                //меняем местами a[i] и a[k]
                for (int j = 0; j < Rows; j++)
                {
                    b1[0, j] = Values[i, j];
                    Values[i, j] = Values[k, j];
                    Values[k, j] = b1[0, j];
                }

                if (i != k)
                    det = -det;

                det *= Values[i, i];
                for (int j = i + 1; j < Rows; ++j)
                    Values[i, j] /= Values[i, i];

                for (int j = 0; j < Rows; ++j)
                    if ((j != i) && (Math.Abs(Values[j, i]) > EPS))
                        for (k = i + 1; k < Rows; ++k)
                            Values[j, k] -= Values[i, k] * Values[j, i];
            }
            return det;
        }
    }
}

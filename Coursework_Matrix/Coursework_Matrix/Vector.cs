using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_Matrix
{
    class Vector : Matrix
    {
        public Vector(double[,] data) : base(data)
        {
        }

        public Vector(string fileName) : base(fileName)
        {
        }

        public Vector(int _Rows, int _Columns) : base(_Rows, _Columns)
        {
        }

        public Vector(int _Rows, int _Columns, int[] data) : base(_Rows, _Columns, data)
        {
        }

		//Переопределяем метод +, как добавление вектора к мн-ву векторов 
        public override Matrix AddMatrix(Matrix A)
        {
            if(A.Rows != Rows)
            { MessageBox.Show("Sorry, we can`t add this matrix", "Incorrect matrix!"); return null; }
            double[,] data = new double[Rows, Columns+A.Columns];
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (j < Columns)
                        data[i, j] = Values[i, j];
                    else
                        data[i, j] = A.Values[i, j-Columns];
                }
            }

            Matrix res = new Matrix(data);
               
            return res;
        }

    }
}

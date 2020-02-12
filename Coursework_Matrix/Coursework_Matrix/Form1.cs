using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework_Matrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
			//Берем значение из текстовых полей
            Int32.TryParse(textBoxX.Text, out N);
            Int32.TryParse(textBoxY.Text, out M);
            Int32.TryParse(textBoxX.Text, out N1);
            Int32.TryParse(textBoxY.Text, out M1);
			//Что бы нельзя было считать, пока матрицы еще не введены
            comboBox1.SelectedIndex = 0;
            buttonDo.Enabled = false;
            button4.Enabled = false;
        }
		// Для первой матрицы
        int N = 1;
        int M = 1;
		//Для второй матрицы
        int N1 = 1;
        int M1 = 1;
		//Индикаторы, что обе матрицы введены
        bool ready1, ready2;
		//Собственно матрицы
        Matrix mat1 = new Matrix(0, 0);
        Matrix mat2;
        private void textBoxN_TextChanged(object sender, EventArgs e)
        {

        }
		//Перечисление всех возможных команд
        enum Operation
        {
            Add = 0,
            Minus,
            MultTo,
            Mult,
            Det,
			AddVect
        }
		//Текущая команда
        int CurrentOperation = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
			//Если вычисляем определитель или умножаем на число, то нужна только одна матрица
                CurrentOperation = comboBox1.SelectedIndex;
            if (CurrentOperation == (int)Operation.MultTo || CurrentOperation == (int)Operation.Det)
            {
                if (textsB != null)
                {
                    foreach (System.Windows.Forms.TextBox b in textsB) if (b != null) b.Dispose();
                    textsB = null;
                }
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
			//Если умножить на число, то нужно текстовое поле
            if (CurrentOperation == (int)Operation.MultTo)
            {
                textNum = new TextBox();
                textNum.Name = "textNum";
                textNum.Location = new System.Drawing.Point(position, textsA[0].Location.Y);
                textNum.Height = 30;
                textNum.Width = 50;
                textNum.BringToFront();
                textNum.Text = "0";
                this.Controls.Add(textNum);
            }
			//Обнуляем, если поле не нужно
            else if (textNum != null)
            {
                if (textNum != null) textNum.Dispose();
                textsB = null;
            }
			//Если две матрицы, то сказать, что вторая не введена 
            if (textsB == null && panel1.Visible == true)
            {
                buttonDo.Enabled = false;
                button4.Enabled = false;
                ready2 = false;
            }
        }
        private TextBox[] textsA;
        private TextBox[] textsB;
        int position;
        int x = 0, y = 0;
        private TextBox[] DrawCells(int rows, int columns, int x0, TextBox[] texts)
        {

            if (texts != null)
            {   
                foreach (System.Windows.Forms.TextBox b in texts) if (b != null) b.Dispose();
            }
            int y0 = 180;
            int len = 30;
            x = 0; y = 0;
            int n = rows;
            int m = columns;
            texts = new TextBox[n*m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    x = x0 + len * j;
                    y = y0 + len * i;
                    int index = j + i * m;

                    texts[index] = new TextBox();
                    texts[index].Name = index.ToString();
                    texts[index].Location = new System.Drawing.Point(x, y);
                    texts[index].Height = len;
                    texts[index].Width = len;

                    texts[index].BringToFront();
                    texts[index].Tag = i + 1;
                    texts[index].Text = "0";
                    texts[index].BackgroundImageLayout = ImageLayout.Zoom;

                    this.Controls.Add(texts[index]);
                }

            }
            return texts;
        }

		//Переводим текстовые поля в массив, что бы использовать в инициализации матрицы
        double[,] TextsTo2Array( TextBox[] text, int n, int m)
        {
            double[,] data = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Double.TryParse(text[m * i + j].Text, out data[i, j]);
                }
            }    
            return data;

		}

		//Берем значение Н и М для первой
        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(textBoxX.Text, out N);
            if (N == 0) N = 1;
            ready1 = false;
            buttonDo.Enabled = false;
            button4.Enabled = false;
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(textBoxY.Text, out M);
            if (M == 0) M = 1;
            ready1 = false;
            buttonDo.Enabled = false;
            button4.Enabled = false;
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
			//Выбираем операцию, определяем матрицы, считаем


            switch (CurrentOperation)
            {
                case (int)Operation.Add:
                    mat1 = new Matrix(TextsTo2Array(textsA, N, M));
                    mat2 = new Matrix(TextsTo2Array(textsB, N1, M1));
                    mat1 = mat1.AddMatrix(mat2);
				    break;
                case (int)Operation.Minus:
                    mat1 = new Matrix(TextsTo2Array(textsA, N, M));
                    mat2 = new Matrix(TextsTo2Array(textsB, N1, M1));
                    mat1 = mat1.MinusMatrix(mat2);
                    break;
                case (int)Operation.Mult:
                    mat1 = new Matrix(TextsTo2Array(textsA, N, M));
                    mat2 = new Matrix(TextsTo2Array(textsB, N1, M1));
                    mat1 = mat1.MultipleMatrix(mat2);
                    break;
                case (int)Operation.MultTo:
                    double C;
                    Double.TryParse(textNum.Text, out C);
                    mat1 = new Matrix(TextsTo2Array(textsA, N, M));
                    mat1.MultipleTo(C);                    
                    break;
                case (int)Operation.Det:
                    mat1 = new Matrix(TextsTo2Array(textsA, N, M));
                    double det = mat1.Determinant();
                    if (mat1.Rows == mat1.Columns)
                        MessageBox.Show(det.ToString(), "Результат обчислень");
                    break;
				case (int)Operation.AddVect:
					mat1 = new Vector(TextsTo2Array(textsA, N, M));
					mat2 = new Vector(TextsTo2Array(textsB, N1, M1));
					mat1 = mat1.AddMatrix(mat2);
					break;
			}
            if(CurrentOperation != (int)Operation.Det && mat1 != null)
                 MessageBox.Show(mat1.ToString(), "Результат обчислень");
        }


        TextBox textNum;
		//Рисуем первую матрицу, если есть вторая, то перерисовываем вторую
        private void button1_Click_1(object sender, EventArgs e)
        {
            ready1 = true;

            textsA = DrawCells(N, M, 45, textsA);
            position = x + 60;
            if ((CurrentOperation != (int)Operation.MultTo || CurrentOperation != (int)Operation.Det) && textsB != null)
            { textsB = DrawCells(N1, M1, position, textsB); ready2 = true; }

            if (panel1.Visible == false) { buttonDo.Enabled = true; button4.Enabled = true; }
            else if (ready2) { buttonDo.Enabled = true; button4.Enabled = true; }

        }
		// Н и М для второй матрицы
        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(textBoxX1.Text, out N1);
            if (N1 == 0) N1 = 1;
            ready2 = false;
            buttonDo.Enabled = false;
            button4.Enabled = false;
        }

        private void textBoxY1_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(textBoxY1.Text, out M1);
            if (M1 == 0) M1 = 1;
            ready2 = false;
            buttonDo.Enabled = false;
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ;
        }
		//Рисуем вторую
		private void button3_Click(object sender, EventArgs e)
		{
			textsB = DrawCells(N1, M1, position, textsB);
			ready2 = true;
			if (ready1) { buttonDo.Enabled = true; button4.Enabled = true; }
		}

		//Загружаем первую матрицу из файла
		private void loadFirstToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            string name = openFileDialog1.FileName;
            mat1 = new Matrix(name);          
            textsA = DrawCells(mat1.Rows, mat1.Columns, 45, textsA);
            for (int i = 0; i < mat1.Rows; i++)
            {
                for (int j = 0; j < mat1.Columns; j++)
                {
                    textsA[j + i * mat1.Columns].Text = mat1.Values[i, j].ToString();
                }
            }

            ready1 = true;
            position = x + 60;
            if ((CurrentOperation != (int)Operation.MultTo || CurrentOperation != (int)Operation.Det) && textsB != null)
            { textsB = DrawCells(N1, M1, position, textsB); ready2 = true; }

            if (panel1.Visible == false) { buttonDo.Enabled = true; button4.Enabled = true; }
            else if (ready2) { buttonDo.Enabled = true; button4.Enabled = true; }
        }
		//Загружаем вторую матрицу из файла
        private void loadSecondToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            string name = openFileDialog1.FileName;
            mat2 = new Matrix(name);
            textsB = DrawCells(mat2.Rows, mat2.Columns, position, textsB);
            for (int i = 0; i < mat2.Rows; i++)
            {
                for (int j = 0; j < mat2.Columns; j++)
                {
                    textsB[j + i * mat2.Columns].Text = mat2.Values[i, j].ToString();
                }
            }
            ready2 = true;
            if (ready1) { buttonDo.Enabled = true; button4.Enabled = true; }
        }

		//Сохраняем первую
        private void saveFirstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(textsA == null) { MessageBox.Show("Спочатку введіть дані"); return; }
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".txt";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            string name = saveFileDialog1.FileName;
            mat1 = new Matrix(TextsTo2Array(textsA, N, M));
            mat1.SaveToFile(name);
        }
		//Сохраняем вторую
        private void saveSecondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textsB == null) { MessageBox.Show("Спочатку введіть дані"); return; }
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".txt";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
            string name = saveFileDialog1.FileName;
            mat2 = new Matrix(TextsTo2Array(textsB, N, M));
            mat2.SaveToFile(name);
        }

		//Заполняем матрицы случайно (что бы не нужно было постоянно что-то вводить)
        private void button4_Click(object sender, EventArgs e)
        {

            Random r = new Random();
            if (textsA != null)
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        x = r.Next(-5, 25);
                        textsA[j + i * M].Text = x.ToString();
                    }
                }
            if (textsB != null)
                for (int i = 0; i < N1; i++)
                {
                    for (int j = 0; j < M1; j++)
                    {
                        x = r.Next(-5, 25);
                        textsB[j + i * M1].Text = x.ToString();
                    }
                }

        }


    }
}

namespace Coursework_Matrix
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.textBoxY = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxX = new System.Windows.Forms.TextBox();
			this.buttonDo = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxX1 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxY1 = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.завантажитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.першуМатрицюToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.другуМатрицюToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.зберегтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.першуМатрицюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.другуМатрицюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxY
			// 
			this.textBoxY.Location = new System.Drawing.Point(328, 74);
			this.textBoxY.Name = "textBoxY";
			this.textBoxY.Size = new System.Drawing.Size(53, 28);
			this.textBoxY.TabIndex = 25;
			this.textBoxY.Text = "4";
			this.textBoxY.TextChanged += new System.EventHandler(this.textBoxY_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(301, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 24);
			this.label3.TabIndex = 24;
			this.label3.Text = "х";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 26);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(168, 24);
			this.label2.TabIndex = 22;
			this.label2.Text = "Доступні операції";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Скласти мартиці",
            "Відняти матриці",
            "Помножити на число",
            "Помножити матриці",
            "Визначник",
            "Додати стовбчик"});
			this.comboBox1.Location = new System.Drawing.Point(186, 26);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(195, 30);
			this.comboBox1.TabIndex = 21;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(11, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(223, 26);
			this.label1.TabIndex = 20;
			this.label1.Text = "Введіть розмір матриці:";
			// 
			// textBoxX
			// 
			this.textBoxX.Location = new System.Drawing.Point(241, 74);
			this.textBoxX.Name = "textBoxX";
			this.textBoxX.Size = new System.Drawing.Size(54, 28);
			this.textBoxX.TabIndex = 19;
			this.textBoxX.Text = "3";
			this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
			// 
			// buttonDo
			// 
			this.buttonDo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDo.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonDo.Location = new System.Drawing.Point(392, 386);
			this.buttonDo.Name = "buttonDo";
			this.buttonDo.Size = new System.Drawing.Size(164, 61);
			this.buttonDo.TabIndex = 18;
			this.buttonDo.Text = "Обчислити!";
			this.buttonDo.UseVisualStyleBackColor = true;
			this.buttonDo.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(9, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(284, 26);
			this.label4.TabIndex = 26;
			this.label4.Text = "Введіть розмір другої матриці:";
			// 
			// textBoxX1
			// 
			this.textBoxX1.Location = new System.Drawing.Point(302, 6);
			this.textBoxX1.Name = "textBoxX1";
			this.textBoxX1.Size = new System.Drawing.Size(48, 28);
			this.textBoxX1.TabIndex = 27;
			this.textBoxX1.Text = "3";
			this.textBoxX1.TextChanged += new System.EventHandler(this.textBoxX1_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(356, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(20, 24);
			this.label5.TabIndex = 28;
			this.label5.Text = "х";
			// 
			// textBoxY1
			// 
			this.textBoxY1.Location = new System.Drawing.Point(382, 6);
			this.textBoxY1.Name = "textBoxY1";
			this.textBoxY1.Size = new System.Drawing.Size(46, 28);
			this.textBoxY1.TabIndex = 29;
			this.textBoxY1.Text = "4";
			this.textBoxY1.TextChanged += new System.EventHandler(this.textBoxY1_TextChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.textBoxY1);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.textBoxX1);
			this.panel1.Location = new System.Drawing.Point(2, 112);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(515, 42);
			this.panel1.TabIndex = 30;
			this.panel1.Visible = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(448, 2);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(40, 37);
			this.button3.TabIndex = 32;
			this.button3.Text = "ok";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(399, 71);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(39, 35);
			this.button1.TabIndex = 31;
			this.button1.Text = "ok";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(392, 312);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(164, 57);
			this.button4.TabIndex = 32;
			this.button4.Text = "Заповнити випаково";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.завантажитиToolStripMenuItem,
            this.зберегтиToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(569, 28);
			this.menuStrip1.TabIndex = 34;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// завантажитиToolStripMenuItem
			// 
			this.завантажитиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.першуМатрицюToolStripMenuItem1,
            this.другуМатрицюToolStripMenuItem1});
			this.завантажитиToolStripMenuItem.Name = "завантажитиToolStripMenuItem";
			this.завантажитиToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
			this.завантажитиToolStripMenuItem.Text = "Завантажити";
			// 
			// першуМатрицюToolStripMenuItem1
			// 
			this.першуМатрицюToolStripMenuItem1.Name = "першуМатрицюToolStripMenuItem1";
			this.першуМатрицюToolStripMenuItem1.Size = new System.Drawing.Size(199, 26);
			this.першуМатрицюToolStripMenuItem1.Text = "Першу матрицю";
			this.першуМатрицюToolStripMenuItem1.Click += new System.EventHandler(this.loadFirstToolStripMenuItem1_Click);
			// 
			// другуМатрицюToolStripMenuItem1
			// 
			this.другуМатрицюToolStripMenuItem1.Name = "другуМатрицюToolStripMenuItem1";
			this.другуМатрицюToolStripMenuItem1.Size = new System.Drawing.Size(199, 26);
			this.другуМатрицюToolStripMenuItem1.Text = "Другу матрицю";
			this.другуМатрицюToolStripMenuItem1.Click += new System.EventHandler(this.loadSecondToolStripMenuItem1_Click);
			// 
			// зберегтиToolStripMenuItem
			// 
			this.зберегтиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.першуМатрицюToolStripMenuItem,
            this.другуМатрицюToolStripMenuItem});
			this.зберегтиToolStripMenuItem.Name = "зберегтиToolStripMenuItem";
			this.зберегтиToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
			this.зберегтиToolStripMenuItem.Text = "Зберегти";
			// 
			// першуМатрицюToolStripMenuItem
			// 
			this.першуМатрицюToolStripMenuItem.Name = "першуМатрицюToolStripMenuItem";
			this.першуМатрицюToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
			this.першуМатрицюToolStripMenuItem.Text = "Першу матрицю";
			this.першуМатрицюToolStripMenuItem.Click += new System.EventHandler(this.saveFirstToolStripMenuItem_Click);
			// 
			// другуМатрицюToolStripMenuItem
			// 
			this.другуМатрицюToolStripMenuItem.Name = "другуМатрицюToolStripMenuItem";
			this.другуМатрицюToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
			this.другуМатрицюToolStripMenuItem.Text = "Другу матрицю";
			this.другуМатрицюToolStripMenuItem.Click += new System.EventHandler(this.saveSecondToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(569, 459);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.textBoxY);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxX);
			this.Controls.Add(this.buttonDo);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(570, 206);
			this.Name = "Form1";
			this.Text = "Дії з матрицями";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Button buttonDo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxY1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem завантажитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem першуМатрицюToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem другуМатрицюToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem зберегтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem першуМатрицюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem другуМатрицюToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
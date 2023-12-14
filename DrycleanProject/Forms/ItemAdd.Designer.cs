namespace DrycleanProject.Forms
{
    partial class ItemAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            label4 = new Label();
            comboBox3 = new ComboBox();
            label5 = new Label();
            comboBox4 = new ComboBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 94);
            textBox1.MaxLength = 50;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(367, 23);
            textBox1.TabIndex = 1;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // button1
            // 
            button1.Location = new Point(12, 323);
            button1.Name = "button1";
            button1.Size = new Size(131, 61);
            button1.TabIndex = 3;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(248, 323);
            button2.Name = "button2";
            button2.Size = new Size(131, 61);
            button2.TabIndex = 4;
            button2.Text = "Выйти";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(175, 15);
            label1.TabIndex = 5;
            label1.Text = "Введите идентификатор заказа";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(193, 15);
            label2.TabIndex = 6;
            label2.Text = "Введите идентификатор предмета";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 136);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 7;
            label3.Text = "Введите тип вещи";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 35);
            comboBox1.MaxLength = 500;
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(367, 23);
            comboBox1.TabIndex = 8;
            comboBox1.KeyPress += textBox1_KeyPress;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Юбка", "Плащ", "Пальто", "Шорты", "Блуза", "Брюки", "Пиджак", "Поло", "Джемпер", "Комбинезон", "Бомбер" });
            comboBox2.Location = new Point(12, 154);
            comboBox2.MaxLength = 50;
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(367, 23);
            comboBox2.TabIndex = 9;
            comboBox2.KeyPress += textBox2_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 195);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 10;
            label4.Text = "Введите тип ткани";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Лён", "Шерсть", "Вискоза", "Джинс", "Хлопок", "Атлас" });
            comboBox3.Location = new Point(12, 213);
            comboBox3.MaxLength = 50;
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(367, 23);
            comboBox3.TabIndex = 11;
            comboBox3.KeyPress += textBox2_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 254);
            label5.Name = "label5";
            label5.Size = new Size(77, 15);
            label5.TabIndex = 12;
            label5.Text = "Введите цвет";
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Белый", "Коричневый", "Синий", "Красный", "Желтый", "Зелёный", "Голубой", "Бежевый", "Чёрный", "Розовый" });
            comboBox4.Location = new Point(12, 272);
            comboBox4.MaxLength = 50;
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(367, 23);
            comboBox4.TabIndex = 13;
            comboBox4.KeyPress += textBox2_KeyPress;
            // 
            // ItemAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 454);
            Controls.Add(comboBox4);
            Controls.Add(label5);
            Controls.Add(comboBox3);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "ItemAdd";
            Text = "Добавление предметов заказа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label4;
        private ComboBox comboBox3;
        private Label label5;
        private ComboBox comboBox4;
    }
}
namespace DrycleanProject.Forms
{
    partial class DeleteItems
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            comboBox2 = new ComboBox();
            label4 = new Label();
            comboBox3 = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(120, 296);
            button1.Name = "button1";
            button1.Size = new Size(163, 67);
            button1.TabIndex = 0;
            button1.Text = "Удалить строку";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(120, 428);
            button2.Name = "button2";
            button2.Size = new Size(163, 67);
            button2.TabIndex = 1;
            button2.Text = "Выход";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(120, 213);
            button3.Name = "button3";
            button3.Size = new Size(163, 67);
            button3.TabIndex = 2;
            button3.Text = "Изменить строку";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Юбка", "Плащ", "Пальто", "Шорты", "Блуза", "Брюки", "Пиджак", "Поло", "Джемпер", "Комбинезон", "Бомбер" });
            comboBox1.Location = new Point(12, 44);
            comboBox1.MaxLength = 50;
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(378, 23);
            comboBox1.TabIndex = 4;
            comboBox1.KeyPress += textBox2_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 26);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 6;
            label2.Text = "Тип вещи";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Лён", "Шерсть", "Вискоза", "Джинс", "Хлопок", "Атлас" });
            comboBox2.Location = new Point(9, 104);
            comboBox2.MaxLength = 50;
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(378, 23);
            comboBox2.TabIndex = 10;
            comboBox2.KeyPress += textBox2_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 86);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 11;
            label4.Text = "Тип ткани";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Белый", "Коричневый", "Синий", "Красный", "Желтый", "Зелёный", "Голубой", "Бежевый", "Чёрный", "Розовый" });
            comboBox3.Location = new Point(9, 168);
            comboBox3.MaxLength = 50;
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(380, 23);
            comboBox3.TabIndex = 12;
            comboBox3.KeyPress += textBox2_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 150);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 13;
            label5.Text = "Цвет";
            label5.UseMnemonic = false;
            // 
            // DeleteItems
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 507);
            Controls.Add(label5);
            Controls.Add(comboBox3);
            Controls.Add(label4);
            Controls.Add(comboBox2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "DeleteItems";
            Text = "Удаление/изменение записей предметов заказов";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Label label4;
        private ComboBox comboBox3;
        private Label label5;
    }
}
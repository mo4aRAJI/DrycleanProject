namespace DrycleanProject.Forms
{
    partial class DeleteOrders
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
            comboBox2 = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            comboBox3 = new ComboBox();
            label4 = new Label();
            comboBox4 = new ComboBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(214, 348);
            button1.Name = "button1";
            button1.Size = new Size(163, 67);
            button1.TabIndex = 0;
            button1.Text = "Удалить строку";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(115, 431);
            button2.Name = "button2";
            button2.Size = new Size(163, 67);
            button2.TabIndex = 1;
            button2.Text = "Выход";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(10, 348);
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
            comboBox1.Location = new Point(12, 43);
            comboBox1.MaxLength = 50;
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(365, 23);
            comboBox1.TabIndex = 3;
            comboBox1.KeyPress += textBox2_KeyPress;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Принят в обработку", "Выполняется", "Готов" });
            comboBox2.Location = new Point(12, 102);
            comboBox2.MaxLength = 150;
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(365, 23);
            comboBox2.TabIndex = 4;
            comboBox2.KeyPress += textBox2_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 25);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 5;
            label1.Text = "ФИО сотрудника";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 84);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 6;
            label2.Text = "ФИО клиента";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 279);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 8;
            label3.Text = "Скидка (в процентах)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(10, 297);
            textBox1.MaxLength = 2;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(365, 23);
            textBox1.TabIndex = 9;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Принят в обработку", "Выполняется", "Готов" });
            comboBox3.Location = new Point(12, 162);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(365, 23);
            comboBox3.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(10, 144);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 11;
            label4.Text = "Адрес";
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Принят в обработку", "Выполняется", "Готов" });
            comboBox4.Location = new Point(10, 226);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(365, 23);
            comboBox4.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(10, 208);
            label5.Name = "label5";
            label5.Size = new Size(80, 15);
            label5.TabIndex = 13;
            label5.Text = "Статус заказа";
            label5.UseMnemonic = false;
            // 
            // DeleteOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 507);
            Controls.Add(label5);
            Controls.Add(comboBox4);
            Controls.Add(label4);
            Controls.Add(comboBox3);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "DeleteOrders";
            Text = "Удаление/изменение записей заказов";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private ComboBox comboBox3;
        private Label label4;
        private ComboBox comboBox4;
        private Label label5;
    }
}
namespace DrycleanProject.Forms
{
    partial class DeleteClient
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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(115, 294);
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
            button3.Location = new Point(115, 208);
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
            comboBox2.Location = new Point(12, 102);
            comboBox2.MaxLength = 11;
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(365, 23);
            comboBox2.TabIndex = 4;
            comboBox2.KeyPress += textBox1_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 25);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 5;
            label1.Text = "ФИО клиента";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 84);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 6;
            label2.Text = "Номер телефона";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 147);
            label3.Name = "label3";
            label3.Size = new Size(124, 15);
            label3.TabIndex = 8;
            label3.Text = "Скидка (в процентах)";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 165);
            textBox1.MaxLength = 2;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(365, 23);
            textBox1.TabIndex = 9;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // DeleteClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 507);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "DeleteClient";
            Text = "Удаление/изменение данных клиентов";
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
    }
}
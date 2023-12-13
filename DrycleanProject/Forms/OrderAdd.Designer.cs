namespace DrycleanProject.Forms
{
    partial class OrderAdd
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 337);
            button1.Name = "button1";
            button1.Size = new Size(131, 61);
            button1.TabIndex = 3;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(248, 337);
            button2.Name = "button2";
            button2.Size = new Size(131, 61);
            button2.TabIndex = 4;
            button2.Text = "Выйти";
            button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 2;
            label1.Text = "Идентификатор заказа";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 172);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 3;
            label2.Text = "Адрес филиала";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 234);
            label3.Name = "label3";
            label3.Size = new Size(100, 15);
            label3.TabIndex = 4;
            label3.Text = "Стоимость услуг";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 190);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(367, 23);
            comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(367, 23);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 252);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(367, 23);
            textBox2.TabIndex = 9;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 80);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(367, 23);
            comboBox2.TabIndex = 10;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(12, 134);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(367, 23);
            comboBox3.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 60);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 12;
            label4.Text = "Клиент";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 113);
            label5.Name = "label5";
            label5.Size = new Size(151, 15);
            label5.TabIndex = 13;
            label5.Text = "Ответственный сотрудник";
            // 
            // OrderAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 421);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "OrderAdd";
            Text = "Добавление заказа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label4;
        private Label label5;
    }
}
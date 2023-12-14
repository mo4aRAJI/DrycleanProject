namespace DrycleanProject.Forms
{
    partial class ViewAdd
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
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 302);
            button1.Name = "button1";
            button1.Size = new Size(131, 61);
            button1.TabIndex = 3;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(248, 302);
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
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 2;
            label1.Text = "Идентификатор заказа";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 188);
            label2.Name = "label2";
            label2.Size = new Size(92, 15);
            label2.TabIndex = 3;
            label2.Text = "Адрес филиала";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 206);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(367, 23);
            comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(367, 23);
            textBox1.TabIndex = 8;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(12, 93);
            comboBox2.MaxLength = 10;
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(367, 23);
            comboBox2.TabIndex = 10;
            comboBox2.KeyPress += textBox1_KeyPress;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(12, 147);
            comboBox3.MaxLength = 50;
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(367, 23);
            comboBox3.TabIndex = 11;
            comboBox3.KeyPress += textBox2_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 75);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 12;
            label4.Text = "Клиент";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 129);
            label5.Name = "label5";
            label5.Size = new Size(151, 15);
            label5.TabIndex = 13;
            label5.Text = "Ответственный сотрудник";
            // 
            // ViewAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 421);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "ViewAdd";
            Text = "Добавление заказа";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox textBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private Label label4;
        private Label label5;
    }
}
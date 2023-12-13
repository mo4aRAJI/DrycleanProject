namespace DrycleanProject
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button4 = new Button();
            label1 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(101, 87);
            button4.Name = "button4";
            button4.Size = new Size(184, 66);
            button4.TabIndex = 3;
            button4.Text = "Просмотр и редактирование таблиц";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Symbol", 21.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(80, 18);
            label1.Name = "label1";
            label1.Size = new Size(234, 40);
            label1.TabIndex = 4;
            label1.Text = "ХИМЧИСТКА";
            // 
            // button1
            // 
            button1.Location = new Point(101, 172);
            button1.Name = "button1";
            button1.Size = new Size(184, 66);
            button1.TabIndex = 5;
            button1.Text = "Выход";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 415);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(button4);
            Name = "Main";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button4;
        private Label label1;
        private Button button1;
    }
}
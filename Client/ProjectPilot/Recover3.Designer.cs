namespace forgotPass3
{
    partial class Recover3
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
            panel1 = new Panel();
            label1 = new Label();
            button1 = new Button();
            panel2 = new Panel();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(330, 188);
            panel1.Name = "panel1";
            panel1.Size = new Size(633, 383);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(142, 81);
            label1.Name = "label1";
            label1.Size = new Size(335, 92);
            label1.TabIndex = 8;
            label1.Text = "Successfully changed\r\npassword!";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 194, 255);
            button1.Font = new Font("Segoe UI", 12F);
            button1.ForeColor = Color.White;
            button1.Location = new Point(154, 269);
            button1.Name = "button1";
            button1.Size = new Size(309, 62);
            button1.TabIndex = 7;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(-8, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1377, 86);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Lucida Sans Unicode", 28.2F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(20, 9);
            label2.Name = "label2";
            label2.Size = new Size(282, 57);
            label2.TabIndex = 3;
            label2.Text = "ProjectPilot";
            // 
            // Recover3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(231, 231, 231);
            ClientSize = new Size(1361, 698);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Recover3";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Button button1;
        private Label label2;
    }
}

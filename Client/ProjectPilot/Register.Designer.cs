namespace register
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            splitContainer1 = new SplitContainer();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            textBox3 = new TextBox();
            label5 = new Label();
            button3 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(checkBox2);
            splitContainer1.Panel1.Controls.Add(checkBox1);
            splitContainer1.Panel1.Controls.Add(textBox3);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(textBox2);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(label2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(231, 231, 231);
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Size = new Size(1343, 683);
            splitContainer1.SplitterDistance = 664;
            splitContainer1.TabIndex = 0;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 10F);
            checkBox2.Location = new Point(68, 469);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(403, 27);
            checkBox2.TabIndex = 24;
            checkBox2.Text = "I agree to have my data sold to literally anyone *";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 10F);
            checkBox1.Location = new Point(68, 436);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(391, 27);
            checkBox1.TabIndex = 23;
            checkBox1.Text = "I have read and accepted the terms of service *";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 10F);
            textBox3.Location = new Point(68, 372);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(417, 30);
            textBox3.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Lucida Console", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(68, 344);
            label5.Name = "label5";
            label5.Size = new Size(117, 25);
            label5.TabIndex = 21;
            label5.Text = "Email: ";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 194, 255);
            button3.Font = new Font("Lucida Sans Unicode", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(215, 543);
            button3.Name = "button3";
            button3.Size = new Size(207, 58);
            button3.TabIndex = 20;
            button3.Text = "Create one";
            button3.UseMnemonic = false;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10F);
            textBox2.Location = new Point(68, 282);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(417, 30);
            textBox2.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(68, 254);
            label4.Name = "label4";
            label4.Size = new Size(162, 25);
            label4.TabIndex = 15;
            label4.Text = "Password: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Console", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(68, 176);
            label3.Name = "label3";
            label3.Size = new Size(162, 25);
            label3.TabIndex = 14;
            label3.Text = "Username: ";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(68, 204);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(417, 30);
            textBox1.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Lucida Sans Unicode", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(39, 106);
            label2.Name = "label2";
            label2.Size = new Size(318, 28);
            label2.TabIndex = 3;
            label2.Text = "Project handling made easy";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans Unicode", 40.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 25);
            label1.Name = "label1";
            label1.Size = new Size(397, 81);
            label1.TabIndex = 1;
            label1.Text = "ProjectPilot";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(117, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(467, 487);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1343, 683);
            Controls.Add(splitContainer1);
            Name = "Register";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button button3;
        private TextBox textBox2;
        private Label label4;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private TextBox textBox3;
        private Label label5;
    }
}

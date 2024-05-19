
namespace ProjectPilot
{
    partial class CreateProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProject));
            panel1 = new Panel();
            button1 = new Button();
            label2 = new Label();
            splitContainer1 = new SplitContainer();
            panel3 = new Panel();
            button3 = new Button();
            textBox3 = new TextBox();
            label7 = new Label();
            button2 = new Button();
            panel2 = new Panel();
            checkedListBox1 = new CheckedListBox();
            label6 = new Label();
            richTextBox1 = new RichTextBox();
            label5 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1320, 76);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(1248, 9);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(57, 59);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Lucida Sans Unicode", 28.2F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(18, 16);
            label2.Name = "label2";
            label2.Size = new Size(226, 45);
            label2.TabIndex = 4;
            label2.Text = "ProjectPilot";
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(-4, 82);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(richTextBox1);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(textBox2);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Size = new Size(1323, 632);
            splitContainer1.SplitterDistance = 288;
            splitContainer1.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(button3);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label7);
            panel3.Location = new Point(648, 152);
            panel3.Name = "panel3";
            panel3.Size = new Size(297, 58);
            panel3.TabIndex = 9;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 194, 255);
            button3.Font = new Font("Segoe UI", 15F);
            button3.ForeColor = Color.White;
            button3.ImageAlign = ContentAlignment.TopCenter;
            button3.Location = new Point(240, 9);
            button3.Name = "button3";
            button3.Size = new Size(42, 42);
            button3.TabIndex = 12;
            button3.Text = "+";
            button3.TextAlign = ContentAlignment.TopCenter;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(7, 25);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(224, 23);
            textBox3.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(7, 6);
            label7.Name = "label7";
            label7.Size = new Size(147, 19);
            label7.TabIndex = 10;
            label7.Text = "add user via username";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(0, 194, 255);
            button2.Font = new Font("Segoe UI", 15F);
            button2.ForeColor = Color.White;
            button2.Location = new Point(648, 489);
            button2.Name = "button2";
            button2.Size = new Size(297, 71);
            button2.TabIndex = 8;
            button2.Text = "CREATE PROJECT";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(checkedListBox1);
            panel2.Location = new Point(648, 152);
            panel2.Name = "panel2";
            panel2.Size = new Size(297, 316);
            panel2.TabIndex = 7;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(16, 73);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(261, 220);
            checkedListBox1.TabIndex = 0;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 15F);
            label6.Location = new Point(643, 120);
            label6.Name = "label6";
            label6.Size = new Size(158, 28);
            label6.TabIndex = 6;
            label6.Text = "add participants:";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(55, 220);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(500, 340);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(50, 189);
            label5.Name = "label5";
            label5.Size = new Size(181, 28);
            label5.TabIndex = 4;
            label5.Text = "project description:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(55, 154);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(500, 23);
            textBox2.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(50, 120);
            label4.Name = "label4";
            label4.Size = new Size(131, 28);
            label4.TabIndex = 2;
            label4.Text = "project name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 35F);
            label3.Location = new Point(32, 32);
            label3.Name = "label3";
            label3.Size = new Size(321, 62);
            label3.TabIndex = 1;
            label3.Text = "Create project";
            // 
            // CreateProject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 705);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "CreateProject";
            Text = "Form1";
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label2;
        private SplitContainer splitContainer1;
        private Label label4;
        private Label label3;
        private TextBox textBox2;
        private Label label5;
        private RichTextBox richTextBox1;
        private Label label6;
        private Button button2;
        private Panel panel2;
        private Panel panel3;
        private TextBox textBox3;
        private Label label7;
        private Button button3;
        private CheckedListBox checkedListBox1;
    }
}
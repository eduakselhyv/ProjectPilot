namespace ProjectPilot
{
    partial class ProjectInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectInfo));
            splitContainer1 = new SplitContainer();
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            label1 = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            label4 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            button1 = new Button();
            label2 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(-4, 76);
            splitContainer1.Margin = new Padding(3, 2, 3, 2);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.White;
            splitContainer1.Panel1.Controls.Add(listBox1);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.White;
            splitContainer1.Panel2.Controls.Add(button4);
            splitContainer1.Panel2.Controls.Add(button3);
            splitContainer1.Panel2.Controls.Add(button2);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Size = new Size(1323, 632);
            splitContainer1.SplitterDistance = 288;
            splitContainer1.TabIndex = 3;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(28, 73);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(231, 499);
            listBox1.TabIndex = 2;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(28, 45);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(231, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 28);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Search for projects:";
            // 
            // button4
            // 
            button4.Location = new Point(282, 111);
            button4.Name = "button4";
            button4.Size = new Size(154, 38);
            button4.TabIndex = 5;
            button4.Text = "Requirements";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(134, 111);
            button3.Name = "button3";
            button3.Size = new Size(149, 38);
            button3.TabIndex = 4;
            button3.Text = "Tasks Manager";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(37, 111);
            button2.Name = "button2";
            button2.Size = new Size(98, 38);
            button2.TabIndex = 3;
            button2.Text = "Info";
            button2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(37, 148);
            panel2.Name = "panel2";
            panel2.Size = new Size(633, 385);
            panel2.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(12, 317);
            label4.Name = "label4";
            label4.Size = new Size(117, 28);
            label4.TabIndex = 6;
            label4.Text = "Participants:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 35F);
            label3.Location = new Point(35, 37);
            label3.Name = "label3";
            label3.Size = new Size(309, 62);
            label3.TabIndex = 1;
            label3.Text = "project_name";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(-1, -4);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1320, 76);
            panel1.TabIndex = 2;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(14, 346);
            label5.Name = "label5";
            label5.Size = new Size(91, 19);
            label5.TabIndex = 6;
            label5.Text = "project_name";
            // 
            // ProjectInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 705);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Name = "ProjectInfo";
            Text = "Form1";
            Load += ProjectInfo_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ListBox listBox1;
        private TextBox textBox1;
        private Label label1;
        private Label label3;
        private Panel panel1;
        private Button button1;
        private Label label2;
        private Panel panel2;
        private Button button3;
        private Button button2;
        private Button button4;
        private Label label4;
        private Label label5;
    }
}
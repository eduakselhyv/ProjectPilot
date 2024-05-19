namespace ProjectPilot
{
    partial class ProjectEditor
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
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            label3 = new Label();
            comboBox1 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 2;
            label2.Text = "Name:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(265, 23);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.Location = new Point(12, 53);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 4;
            label1.Text = "Description:";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 71);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(265, 96);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 170);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 6;
            label3.Text = "Status:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "active", "deactivated" });
            comboBox1.Location = new Point(12, 188);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 7;
            comboBox1.Text = "Please select one";
            // 
            // button1
            // 
            button1.Location = new Point(10, 221);
            button1.Name = "button1";
            button1.Size = new Size(267, 47);
            button1.TabIndex = 8;
            button1.Text = "Accept";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ProjectEditor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 280);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(label3);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Name = "ProjectEditor";
            Text = "Editing project";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private RichTextBox richTextBox1;
        private Label label3;
        private ComboBox comboBox1;
        private Button button1;
    }
}
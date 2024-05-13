using forgotPassword;
using mainPage1;
using register;
using System.Net.Http;

namespace ProjectPilot
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            splitContainer1 = new SplitContainer();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label6 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
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
            splitContainer1.Panel1.BackColor = Color.Transparent;
            splitContainer1.Panel1.Controls.Add(button3);
            splitContainer1.Panel1.Controls.Add(button2);
            splitContainer1.Panel1.Controls.Add(button1);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(textBox2);
            splitContainer1.Panel1.Controls.Add(label4);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(label2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(231, 231, 231);
            splitContainer1.Panel2.Controls.Add(pictureBox2);
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Size = new Size(1315, 705);
            splitContainer1.SplitterDistance = 635;
            splitContainer1.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(0, 194, 255);
            button3.Font = new Font("Lucida Sans Unicode", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(152, 530);
            button3.Name = "button3";
            button3.Size = new Size(207, 58);
            button3.TabIndex = 12;
            button3.Text = "Log In";
            button3.UseMnemonic = false;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(227, 435);
            button2.Name = "button2";
            button2.Size = new Size(101, 26);
            button2.TabIndex = 11;
            button2.Text = "Create one";
            button2.UseMnemonic = false;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(64, 64, 64);
            button1.Location = new Point(318, 372);
            button1.Name = "button1";
            button1.Size = new Size(152, 29);
            button1.TabIndex = 10;
            button1.Text = "Forgot password?";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Lucida Sans Unicode", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(53, 439);
            label6.Name = "label6";
            label6.Size = new Size(177, 18);
            label6.TabIndex = 9;
            label6.Text = "Don't have an account?";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10F);
            textBox2.Location = new Point(53, 402);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(417, 30);
            textBox2.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Lucida Console", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(53, 376);
            label4.Name = "label4";
            label4.Size = new Size(162, 25);
            label4.TabIndex = 6;
            label4.Text = "Password: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Lucida Console", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(53, 263);
            label3.Name = "label3";
            label3.Size = new Size(162, 25);
            label3.TabIndex = 5;
            label3.Text = "Username: ";
            label3.Click += label3_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(53, 291);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(417, 30);
            textBox1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lucida Sans Unicode", 40.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 40);
            label1.Name = "label1";
            label1.Size = new Size(397, 81);
            label1.TabIndex = 0;
            label1.Text = "ProjectPilot";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Lucida Sans Unicode", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(53, 129);
            label2.Name = "label2";
            label2.Size = new Size(318, 28);
            label2.TabIndex = 2;
            label2.Text = "Project handling made easy";
            label2.Click += label2_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(103, 101);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(471, 503);
            pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(0, 0);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            ClientSize = new Size(1315, 705);
            Controls.Add(splitContainer1);
            Name = "Login";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recover1 recover1 = new Recover1();
            recover1.Show();
        }

        async private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            bool success = true;

            if (username != "" && password != "")
            {
                if (success)
                {
                    MessageBox.Show("Success!");
                    MainPage mainpage = new MainPage();
                    mainpage.Show();
                    this.Close();
                }
            } 
            else
            {
                MessageBox.Show("Please fill in both inputs!");
            }
        }
    }
}

using ProjectPilot;

namespace forgotPass3
{
    public partial class Recover3 : Form
    {
        public Recover3()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Close();
        }
    }
}

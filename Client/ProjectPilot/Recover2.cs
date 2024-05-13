using forgotPass3;

namespace forgotPass2
{
    public partial class Recover2 : Form
    {
        public Recover2()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Recover3 recover3 = new Recover3();
            recover3.Show();
            this.Close();
        }
    }
}

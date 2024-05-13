using mainPage1;

namespace register
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        async private void button3_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Please fill in both inputs!");
                return;
            }
            if (!checkBox2.Checked)
            {
                MessageBox.Show("Please check both checkboxes!");
                return;
            }
            else if (!checkBox1.Checked)
            {
                MessageBox.Show("You didn't accept the Terms and Conditions, but that's fine as long as you accepted the second checkbox!");
            }
            // Add username and password into the request body
            var formContent = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                });

            // Create a new HttpClient to handle the login request
            HttpClient httpClient = new HttpClient();

            // Send a Post request to the specified url with the body after it
            HttpResponseMessage response = await httpClient.PostAsync("http://localhost:5000?requestType=register", formContent);

            // Get the response
            string responseData = await response.Content.ReadAsStringAsync();

            // Show response
            MessageBox.Show(responseData);

            // If the statuscode is successful (succesfully logged in)
            if (response.IsSuccessStatusCode)
            {
                // This is not part of the request
                this.Close();
            }
        }
    }
}
